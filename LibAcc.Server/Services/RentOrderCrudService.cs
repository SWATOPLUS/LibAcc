using System.Threading.Tasks;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.EntityFrameworkCore;

namespace LibAcc.Server.Services
{
    public class RentOrderCrudService : ICrudService<RentOrder>
    {
        private readonly MainDbContext _dbContext;

        public RentOrderCrudService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RentOrder> AddOrUpdate(RentOrder entity)
        {
            if (entity.RentOrderId == 0)
            {
                _dbContext.Add(entity);
            }
            else
            {
                _dbContext.RentOrders.Update(entity);
            }

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            _dbContext.RentOrders.Remove(new RentOrder { RentOrderId = id});
            await _dbContext.SaveChangesAsync();
        }

        public Task<RentOrder> Get(int id)
        {
            return _dbContext.RentOrders.FirstOrDefaultAsync(x => x.RentOrderId == id);
        }

        public Task<RentOrder[]> GetAll()
        {
            return _dbContext.RentOrders.ToArrayAsync();
        }
    }
}
