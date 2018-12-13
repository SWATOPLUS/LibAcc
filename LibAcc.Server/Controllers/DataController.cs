using System.Threading.Tasks;
using System.Web;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibAcc.Server.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        private readonly ICrudService<Book> _bookCrudService;

        public DataController(ICrudService<Book> bookCrudService)
        {
            _bookCrudService = bookCrudService;
        }

        [HttpGet("Book/Get/{id}")]
        public Task<Book> GetBook(int id)
        {
            return _bookCrudService.Get(id);
        }

        [HttpGet("Book")]
        public Task<Book[]> GetAllBooks()
        {
            return _bookCrudService.GetAll();
        }

        [HttpPost("Book")]
        public Task<Book> AddOrUpdateBook([FromBody] Book entity)
        {
            return _bookCrudService.AddOrUpdate(entity);
        }

        [HttpGet("Book/Delete/{id}")]
        public Task DeleteBook(int id)
        {
            return _bookCrudService.Delete(id);
        }
    }
}
