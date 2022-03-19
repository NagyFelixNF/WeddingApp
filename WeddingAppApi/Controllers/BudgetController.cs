using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingAppApi.Data;
using WeddingAppApi.DataObjects;
using WeddingAppApi.Models;

namespace WeddingAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BudgetController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Budget>> GetBudget()
        {
            string WeddingId = Helpers.Helpers.GetUserFromToken(await HttpContext.GetTokenAsync("access_token"));
            Budget budget = await _context.Budget.Where(x => x.WeddingId == Int32.Parse(WeddingId)).Include(x => x.Categories).ThenInclude(x => x.Spendings).FirstOrDefaultAsync();
            if(budget == default)
            {
                budget = new Budget();
                budget.WeddingId = Int32.Parse(WeddingId);
                budget.budget= 1000;
                budget.Categories = new List<Category>();
                await _context.Budget.AddAsync(budget);
                await _context.SaveChangesAsync();
            }
            return budget;
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult<Budget>> UpdateBudgetTotal(int id,Budget budgetcost)
        {
            Budget budget = await _context.Budget.FindAsync(id);
            budget.budget = budgetcost.budget;
            await _context.SaveChangesAsync();
            return budget;
        }

        [Authorize]
        [HttpPost("{id}")]
        public async Task<ActionResult<CategoryOutputObject>> AddNewCategory(int id,Category category)
        {
            Category newCategory = category;
            newCategory.BudgetId = id;
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryOutputObject>(newCategory);
        }
        [Authorize]
        [HttpPost("spending/{id}")]
        public async Task<ActionResult<Spending>> AddNewSpending(int id,Spending spending)
        {
            Spending newSpending = spending;
            newSpending.CategoryId = id;
            await _context.Spendings.AddAsync(newSpending);
            await _context.SaveChangesAsync();
            return newSpending;
        }
    }
}