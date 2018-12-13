using System.Net.Http;
using System.Threading.Tasks;
using LibAcc.Abstractions.Services;
using Microsoft.AspNetCore.Blazor;

namespace LibAcc.Client.Services
{
    public class CrudService<T> : ICrudService<T>
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CrudService(HttpClient httpClient, string serviceUrl, string entity = null)
        {
            _httpClient = httpClient;
            _baseUrl = $"{serviceUrl}/{entity ?? typeof(T).Name}";

        }

        public Task<T> AddOrUpdate(T entity)
        {
            return _httpClient.PostJsonAsync<T>(_baseUrl, entity);
        }

        public Task Delete(int id)
        {
            return _httpClient.DeleteAsync($"{_baseUrl}/Delete/{id}");
        }

        public Task<T> Get(int id)
        {
            return _httpClient.GetJsonAsync<T>($"{_baseUrl}/Get/{id}");
        }

        public Task<T[]> GetAll()
        {
            return _httpClient.GetJsonAsync<T[]>(_baseUrl);
        }
    }
}
