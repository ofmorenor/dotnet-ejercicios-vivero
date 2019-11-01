using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Facturas.Data;
using Facturas.Domain;


// referenciamos Facturas.Data y Facturas.Domain con: dotnet add reference

namespace Facturas.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. 
        //Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // agregamos el DbContext al servicio. Para usar debemos importar EntityFramework
            services.AddDbContext<FacturaContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionMain"))
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // configuramos los endpoints
            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller}/{action}/{id:int}",
                   defaults: new { controller = "WheatherForecast", action = "get" }
                );
               endpoints.MapControllerRoute(
                   name: "api",
                   pattern: "{controller}/{action}/{id:int}"
                );
            });
        }
    }
}
