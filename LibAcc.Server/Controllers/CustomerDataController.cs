using System.Threading.Tasks;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibAcc.Server.Controllers
{
    [Route("api/Data/Customer")]
    public class CustomerDataController : Controller
    {
        private readonly ICrudService<Customer> _crudService;

        public CustomerDataController
        (
            ICrudService<Customer> crudService
        )
        {
            _crudService = crudService;
        }

        [HttpGet("Get/{id}")]
        public Task<Customer> Get(int id)
        {
            return _crudService.Get(id);
        }

        [HttpGet("")]
        public Task<Customer[]> GetAll()
        {
            return _crudService.GetAll();
        }

        [HttpPost("")]
        public Task<Customer> AddOrUpdate([FromBody] Customer entity)
        {
            return _crudService.AddOrUpdate(entity);
        }

        [HttpGet("Delete/{id}")]
        public Task Delete(int id)
        {
            return _crudService.Delete(id);
        }
    }
}
