using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingAppApi.Data;
using WeddingAppApi.Models;

namespace WeddingAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        
        }
        [Authorize]
        [HttpGet]
        public async Task< ActionResult<IEnumerable<AppUser>>> GetUser()
        {
            string token =  await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var jti = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;
            Console.WriteLine("[Test] -> " + jti);
            //works fineee :)
            return await _context.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserById(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }
    }
}