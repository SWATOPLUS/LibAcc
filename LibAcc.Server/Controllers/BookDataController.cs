using System.Threading.Tasks;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibAcc.Server.Controllers
{
    [Route("api/Data/Book")]
    public class BookDataController : Controller
    {
        private readonly ICrudService<Book> _crudService;

        public BookDataController
        (
            ICrudService<Book> crudService
        )
        {
            _crudService = crudService;
        }

        [HttpGet("Get/{id}")]
        public Task<Book> Get(int id)
        {
            return _crudService.Get(id);
        }

        [HttpGet("")]
        public Task<Book[]> GetAll()
        {
            return _crudService.GetAll();
        }

        [HttpPost("")]
        public Task<Book> AddOrUpdate([FromBody] Book entity)
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
