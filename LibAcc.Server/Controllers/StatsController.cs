using System;
using System.Linq;
using System.Threading.Tasks;
using LibAcc.Abstractions;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibAcc.Server.Controllers
{
    [Route("api/Stats")]
    public class StatsController : Controller
    {
        private readonly MainDbContext _dbContext;

        public StatsController
        (
            MainDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        [HttpGet("")]
        public async Task<Stats> GetAll()
        {
            return new Stats
            {
                TotalBooks = await _dbContext.Books.CountAsync(),
                TotalCustomers = await _dbContext.Customers.CountAsync(),
                TotalLateRents = await _dbContext.RentOrders
                    .Where(x=> x.OrderDate.AddDays(x.OrderDays) < DateTime.Now)
                    .CountAsync()
            };
        }
    }
}
