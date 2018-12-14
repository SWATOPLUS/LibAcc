using System.Threading.Tasks;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibAcc.Server.Controllers
{
    [Route("api/Data/RentOrder")]
    public class RentOrderDataController : Controller
    {
        private readonly ICrudService<RentOrder> _crudService;

        public RentOrderDataController
        (
            ICrudService<RentOrder> crudService
        )
        {
            _crudService = crudService;
        }

        [HttpGet("Get/{id}")]
        public Task<RentOrder> Get(int id)
        {
            return _crudService.Get(id);
        }

        [HttpGet("")]
        public Task<RentOrder[]> GetAll()
        {
            return _crudService.GetAll();
        }

        [HttpPost("")]
        public Task<RentOrder> AddOrUpdate([FromBody] RentOrder entity)
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
