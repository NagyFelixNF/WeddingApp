using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingAppApi.Data;
using WeddingAppApi.DataObjects;
using WeddingAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GuestController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestOutputObject>>> GetAllTodo()
        {
            string WeddingId = Helpers.Helpers.GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            List<Guest> guests = await _context.Guests.Where(x => x.WeddingId == Int32.Parse(WeddingId)).Include(x=> x.Invitations).ToListAsync();
            if(guests.Count() == 0)
            {
                Guest Bride = new Guest();
                Guest Groom = new Guest();
                Bride.Category="Bride";
                Groom.Category="Groom";
                Bride.Comment = Bride.Diet = Bride.Side = Bride.Name = Groom.Comment = Groom.Diet = Groom.Side = Groom.Name = "";
                Bride.WeddingId = Groom.WeddingId = Int32.Parse(WeddingId);
                Bride.Response = Groom.Response = GuestResponse.AcceptedBoth;
                await _context.Guests.AddAsync(Bride);
                await _context.Guests.AddAsync(Groom);
                await _context.SaveChangesAsync();
                guests = await _context.Guests.Where(x => x.WeddingId == Int32.Parse(WeddingId)).ToListAsync();
            }
            return _mapper.Map<List<GuestOutputObject>>(guests);
        }

        [Authorize]
        [HttpPost()]
        public async Task<ActionResult<GuestOutputObject>> GetAllTodo(Guest guest)
        {
            if(guest.Invitations != null)
            {
                Invitation inv = await _context.Invitations.FindAsync(guest.Invitations[0].Id);
                guest.Invitations = null;
                guest.Invitations = new List<Invitation>();
                guest.Invitations.Add(inv);
            }
            Guest Guest = guest;
            Guest.WeddingId = Int32.Parse(Helpers.Helpers.GetUserFromToken(await HttpContext.GetTokenAsync("access_token")));
            await _context.Guests.AddAsync(Guest);
            await _context.SaveChangesAsync();
            return _mapper.Map<GuestOutputObject>(Guest);
        }

        [Authorize]
        [HttpGet("wedding")]
        public async Task<ActionResult<string>> GetWeddingId()
        {
            string WeddingId = Helpers.Helpers.GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            return WeddingId;
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult<GuestOutputObject>> GetAllTodo(int id,Guest guest)
        {
            Guest Guest = await _context.Guests.FindAsync(id);
            Guest.Name = guest.Name;
            Guest.Diet = guest.Diet;
            Guest.Comment = guest.Comment;
            Guest.Response = guest.Response;
            await _context.SaveChangesAsync();
            return _mapper.Map<GuestOutputObject>(Guest);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> GetAllTodo(int id)
        {
            Guest guest = await _context.Guests.FindAsync(id);
            //TODO:Handle groom/bride
            _context.Invitations.RemoveRange(await _context.Invitations.Where(x => x.GuestId == guest.Id).ToListAsync());
            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost("invitation")]
        public async Task<ActionResult<Boolean>> GetAllTodo(Invitation inv)
        {
            Invitation invitation = inv;
            if(invitation.GuestId != null)
            {
                Guest guest = await _context.Guests.FindAsync(invitation.GuestId);
                guest.Response = inv.Response;
                guest.Comment = inv.Comment;
                guest.Diet = inv.Diet;
            }
            await _context.Invitations.AddAsync(invitation);
            await _context.SaveChangesAsync();
            return true;
        }

        [Authorize]
        [HttpGet("invitation")]
        public async Task<ActionResult<IEnumerable<InvitationObject>>> GetAllInvitation()
        {
            string WeddingId = Helpers.Helpers.GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            List<Invitation> invitations = await _context.Invitations.Where(x => x.WeddingId == Int32.Parse(WeddingId) && x.GuestId == null).ToListAsync();
            return _mapper.Map<List<InvitationObject>>(invitations);
        }

        [Authorize]
        [HttpPatch("invitation/{id}")]
        public async Task<ActionResult<GuestOutputObject>> AddInvitationToGuest(int id,Guest guest)
        {
            Guest Guest = await _context.Guests.FindAsync(id);
            Guest.Name = guest.Name;
            Guest.Diet = guest.Diet;
            Guest.Comment = guest.Comment;
            Guest.Response = guest.Response;
            await _context.SaveChangesAsync();
            return _mapper.Map<GuestOutputObject>(Guest);
        }
    }
}