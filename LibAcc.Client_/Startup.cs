using System.Net.Http;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using LibAcc.Client.Services;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LibAcc.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICrudService<Book>>(context =>
                new CrudService<Book>(context.GetService<HttpClient>(), "api/Data"));

            services.AddSingleton<ICrudService<Customer>>(context =>
                new CrudService<Customer>(context.GetService<HttpClient>(), "api/Data"));

            services.AddSingleton<ICrudService<RentOrder>>(context =>
                new CrudService<RentOrder>(context.GetService<HttpClient>(), "api/Data"));
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
