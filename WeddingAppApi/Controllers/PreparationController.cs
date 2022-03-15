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
        public async Task<ActionResult<IEnumerable<MainPreparationOutputObject>>> GetAllTodo()
        {
            string WeddingId = GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            List<Preparation> Preparations = await _context.Preparations.Where(x => x.WeddingId == Int32.Parse(WeddingId)).Include(x => x.SubPreparations).ToListAsync();
            foreach (var item in  Preparations)
            {
                item.SubPreparations.Reverse();
            }
            Preparations.Reverse();
            return _mapper.Map<List<MainPreparationOutputObject>>(Preparations);
        }

        //add some error handling
        
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

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult<MainPreparationOutputObject>> UpdateMainTodo(int id,MainPreparationInputObject PreparationInput)
        {
            //FirstorDefault could be chaind with .include
            var Preparation = await _context.Preparations.FindAsync(id);
            Preparation.Title = PreparationInput.Title;
            Preparation.Completed = PreparationInput.Completed;
            await _context.SaveChangesAsync();
            return _mapper.Map<MainPreparationOutputObject>(Preparation);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteMainTodo(int id)
        {
            var Preparation = await _context.Preparations.FindAsync(id);
            _context.Preparations.Remove(Preparation);
            await _context.SaveChangesAsync();
            return true;
        }

        [Authorize]
        [HttpPost("sub/{id}")]
        public async Task<ActionResult<MainPreparationOutputObject>> AddSubTodo(int id, MainPreparationInputObject PreparationInput)
        {
            Preparation Preparation = await _context.Preparations.FindAsync(id);
            SubPreparation SubPreparation = _mapper.Map<SubPreparation>(PreparationInput);
            SubPreparation.Preparation = Preparation;
            await _context.SubPreparations.AddAsync(SubPreparation);
            await _context.SaveChangesAsync();
            return _mapper.Map<MainPreparationOutputObject>(SubPreparation);
        }

        [Authorize]
        [HttpPatch("sub/{id}")]
        public async Task<ActionResult<MainPreparationOutputObject>> UpdateSubTodo(int id,MainPreparationInputObject PreparationInput)
        {
            //FirstorDefault could be chaind with .include
            var SubPreparation = await _context.SubPreparations.FindAsync(id);
            SubPreparation.Title = PreparationInput.Title;
            SubPreparation.Completed = PreparationInput.Completed;
            await _context.SaveChangesAsync();
            return _mapper.Map<MainPreparationOutputObject>(SubPreparation);
        }

        [Authorize]
        [HttpDelete("sub/{id}")]
        public async Task<ActionResult<bool>> DeleteSubTodo(int id)
        {
            var Preparation = await _context.SubPreparations.FindAsync(id);
            _context.SubPreparations.Remove(Preparation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}