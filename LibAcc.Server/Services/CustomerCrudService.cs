using System.Threading.Tasks;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.EntityFrameworkCore;

namespace LibAcc.Server.Services
{
    public class CustomerCrudService : ICrudService<Customer>
    {
        private readonly MainDbContext _dbContext;

        public CustomerCrudService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddOrUpdate(Customer entity)
        {
            if (entity.CustomerId == 0)
            {
                _dbContext.Add(entity);
            }
            else
            {
                _dbContext.Customers.Update(entity);
            }

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            _dbContext.Customers.Remove(new Customer { CustomerId = id});
            await _dbContext.SaveChangesAsync();
        }

        public Task<Customer> Get(int id)
        {
            return _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public Task<Customer[]> GetAll()
        {
            return _dbContext.Customers.ToArrayAsync();
        }
    }
}
