using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingAppApi.Data;
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
    public class EventController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EventController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventOutputObject>>> GetAllEvent()
        {
            string WeddingId = Helpers.Helpers.GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            List<Event> Events = await _context.Events.Where(x => x.WeddingId == Int32.Parse(WeddingId)).ToListAsync();
            return _mapper.Map<List<EventOutputObject>>(Events);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<EventOutputObject>> AddEvent(Event Event)
        {
            string WeddingId = Helpers.Helpers.GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            Event.WeddingId = Int32.Parse(WeddingId);
            await _context.Events.AddAsync(Event);
            await _context.SaveChangesAsync();
            return _mapper.Map<EventOutputObject>(Event);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult<EventOutputObject>> UpdateEvent(int id, Event UpdatedEvent)
        {
            Event Event = await _context.Events.FindAsync(id);
            Event.Title = UpdatedEvent.Title;
            Event.Hour = UpdatedEvent.Hour;
            Event.Minute = UpdatedEvent.Minute;
            await _context.SaveChangesAsync();
            return _mapper.Map<EventOutputObject>(Event);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEvent(int id)
        {
            Event Event = await _context.Events.FindAsync(id);
            _context.Events.Remove(Event);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}