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
    public class VendorController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public VendorController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorOutputObject>>> GetAllVendor()
        {
            string WeddingId = Helpers.Helpers.GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            List<Vendor> Vendors = await _context.Vendors.Where(x => x.WeddingId == Int32.Parse(WeddingId)).ToListAsync();
            return _mapper.Map<List<VendorOutputObject>>(Vendors);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VendorOutputObject>> AddVendor(Vendor Vendor)
        {
            string WeddingId = Helpers.Helpers.GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            Vendor.WeddingId = Int32.Parse(WeddingId);
            await _context.Vendors.AddAsync(Vendor);
            await _context.SaveChangesAsync();
            return _mapper.Map<VendorOutputObject>(Vendor);
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult<VendorOutputObject>> UpdateVendor(int id, Vendor UpdatedVendor)
        {
            Vendor Vendor = await _context.Vendors.FindAsync(id);
            Vendor.Name = UpdatedVendor.Name;
            Vendor.Category = UpdatedVendor.Category;
            Vendor.Description = UpdatedVendor.Description;
            Vendor.Email = UpdatedVendor.Email;
            Vendor.Telnumber = UpdatedVendor.Telnumber;
            await _context.SaveChangesAsync();
            return _mapper.Map<VendorOutputObject>(Vendor);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteVendor(int id)
        {
            Vendor Vendor = await _context.Vendors.FindAsync(id);
            _context.Vendors.Remove(Vendor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}