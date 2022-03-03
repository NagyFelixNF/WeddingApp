using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingAppApi.Data;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WeddingAppApi.Models;
using AutoMapper;
using WeddingAppApi.DataObjects;

namespace WeddingAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreparationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PreparationController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private string GetUserFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            string jti = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;
            return jti;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preparation>>> GetAllTodo()
        {
            string WeddingId = GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            return await _context.Preparations.Where(x => x.WeddingId == Int32.Parse(WeddingId)).ToListAsync();
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<MainPreparationOutputObject>> AddMainTodo(MainPreparationInputObject PreparationInput)
        {
            string WeddingId = GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            Preparation Preparation = _mapper.Map<Preparation>(PreparationInput);
            Preparation.Wedding = await _context.Weddings.FindAsync(Int32.Parse(WeddingId));
            await _context.Preparations.AddAsync(Preparation);
            await _context.SaveChangesAsync();
            return _mapper.Map<MainPreparationOutputObject>(Preparation);
        }
    }
}