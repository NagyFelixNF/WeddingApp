using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingAppApi.DataObjects;
using WeddingAppApi.Data;
using WeddingAppApi.Interfaces;
using WeddingAppApi.Models;

namespace WeddingAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService) 
        {
            _tokenService = tokenService;
            _context = context;

        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserObject>> Regiser(RegisterObject registerData)
        {

            if(await UserExist(registerData.Email)) return BadRequest("Username is already taken!");
            
            using var hmac = new HMACSHA512();
            var wedding = new Wedding
            {
                Preparations = new List<Preparation>(),
            };
             await _context.Weddings.AddAsync(wedding);
            var user = new AppUser
            {
                UserName = registerData.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerData.Password)),
                PasswordSalt = hmac.Key,
                Wedding = wedding
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new UserObject
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserObject>> Login(LoginObject LoginData)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == LoginData.Email.ToLower());
            if (user == null) return Unauthorized("Invalid username!");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(LoginData.Password));

            for (int i = 0; i < ComputedHash.Length; i++)
            {
                if (ComputedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password!");
            }

            return new UserObject
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExist(string Username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == Username.ToLower());
        }
    }
}