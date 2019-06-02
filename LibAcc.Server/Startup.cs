using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Mime;
using LibAcc.Abstractions.Models;
using LibAcc.Abstractions.Services;
using LibAcc.Server.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;

namespace LibAcc.Server
{
    public class Startup
    {
        public const bool InMemoryMode = true;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
            
            var dbConnString = configuration.GetValue<string>("mainDbConnString");

            services.AddDbContext<MainDbContext>(o => o.UseSqlServer(dbConnString));

            services.AddMvc();

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });


            if (InMemoryMode)
            {
                services.AddSingleton<ICrudService<Book>>(new BookCrudServiceMock());
                services.AddSingleton<ICrudService<Customer>>(new CustomerCrudServiceMock());
                services.AddSingleton<ICrudService<RentOrder>>(new RentOrderCrudServiceMock());
            }
            else
            {
                services.AddScoped<ICrudService<Book>>(context => new BookCrudService(context.GetService<MainDbContext>()));
                services.AddScoped<ICrudService<Customer>>(context => new CustomerCrudService(context.GetService<MainDbContext>()));
                services.AddScoped<ICrudService<RentOrder>>(context => new RentOrderCrudService(context.GetService<MainDbContext>()));
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            });

            app.UseBlazor<Client.Startup>();
        }
    }
}
