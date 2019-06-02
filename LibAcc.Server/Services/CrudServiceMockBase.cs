using System.Collections.Generic;
using System.Threading.Tasks;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using Microsoft.EntityFrameworkCore;

namespace LibAcc.Server.Services
{
    public class CrudServiceMockBase<T> : ICrudService<T>
    {
        private List<T> _items;

        public CrudServiceMockBase()
        {
            _items = new List<T>();
        }

        public CrudServiceMockBase(IEnumerable<T> items)
        {
            _items = new List<T>(items);
        }

        public Task<T> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T[]> GetAll()
        {
            return Task.FromResult(_items.ToArray());
        }

        public Task<T> AddOrUpdate(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
