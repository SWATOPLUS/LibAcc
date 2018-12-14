using System.Threading.Tasks;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.EntityFrameworkCore;

namespace LibAcc.Server.Services
{
    public class BookCrudService : ICrudService<Book>
    {
        private readonly MainDbContext _dbContext;

        public BookCrudService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Book> AddOrUpdate(Book entity)
        {
            if (entity.BookId == 0)
            {
                _dbContext.Add(entity);
            }
            else
            {
                _dbContext.Books.Update(entity);
            }

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            _dbContext.Books.Remove(new Book {BookId = id});
            await _dbContext.SaveChangesAsync();
        }

        public Task<Book> Get(int id)
        {
            return _dbContext.Books.FirstOrDefaultAsync(x => x.BookId == id);
        }

        public Task<Book[]> GetAll()
        {
            return _dbContext.Books.ToArrayAsync();
        }
    }
}
