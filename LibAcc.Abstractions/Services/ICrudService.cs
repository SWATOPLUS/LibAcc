using System.Threading.Tasks;

namespace LibAcc.Abstractions.Services
{
    public interface ICrudService<T>
    {
        Task<T> Get(int id);

        Task<T[]> GetAll();

        Task<T> AddOrUpdate(T entity);

        Task Delete(int id);
    }
}