using ApiRestCrudAlfa.EmployeeData;
using ApiRestCrudAlfa.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;//Para Establecer el uso de SQL SERVER CON Entity
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;//Necesario para utilizar listas
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCrudAlfa
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //IMportante añadir la base de datos en startup (SERVER)
            services.AddDbContextPool<EmployeeContext>(options => options.UseSqlServer
            (
                Configuration.GetConnectionString("EmployeeContextConecctionString")
            )); //Pasamos la conexion de la base de datos

            //Añadir controladores a usar
            //services.AddSingleton<IEmployeeData,MockEmployeeData>();
            services.AddScoped<IEmployeeData,SqlEmployeeData>(); //Usara el SqlEmployeeData 
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
