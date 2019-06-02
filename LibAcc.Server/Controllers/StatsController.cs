using System;
using System.Linq;
using System.Threading.Tasks;
using LibAcc.Abstractions;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibAcc.Server.Controllers
{
    [Route("api/Stats")]
    public class StatsController : Controller
    {
        private readonly ICrudService<Book> _bookCrudService;
        private readonly ICrudService<Customer> _customerCrudService;
        private readonly ICrudService<RentOrder> _rentOrderCrudService;

        public StatsController
        (
            ICrudService<Book> bookCrudService,
            ICrudService<Customer> customerCrudService,
            ICrudService<RentOrder> rentOrderCrudService
            
        )
        {
            _bookCrudService = bookCrudService;
            _customerCrudService = customerCrudService;
            _rentOrderCrudService = rentOrderCrudService;
        }

        [HttpGet("")]
        public async Task<Stats> GetAll()
        {
            return new Stats
            {
                TotalBooks = (await _bookCrudService.GetAll()).Count(),
                TotalCustomers = (await _customerCrudService.GetAll()).Count(),
                TotalLateRents = (await _rentOrderCrudService.GetAll())
                    .Count(x => x.OrderDate.AddDays(x.OrderDays) < DateTime.Now && x.ReturnDate != default)
            };
        }
    }
}
