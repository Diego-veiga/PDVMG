using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;

namespace WebApplication2
{
    public class Startup
    {
        IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {

          var builder = new ConfigurationBuilder().AddJsonFile("Config.json");
            Configuration = builder.Build();


        }
        public void ConfigureServices(IServiceCollection services)
        {
            var conn = Configuration.GetConnectionString("PDVMG");
            services.AddDbContext<PDVMGContext>(option => option.UseLazyLoadingProxies()
            .UseSqlServer(conn, m => m.MigrationsAssembly("WebApplication2")));

            services.AddMvcCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
