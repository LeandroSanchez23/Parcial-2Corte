
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Contracts;
using Infraestructura;
using Infraestructura.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace InterfazUsuario
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

            services.AddDbContext<BancoContext>
                         (opt => opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BancoParcial;Trusted_Connection=True;MultipleActiveResultSets=true"));

            ///Inyección de dependencia Especifica
            services.AddScoped<IUnitOfWork, UnitOfWork>(); //Se Instancia un peticion
            services.AddScoped<IDbContext, BancoContext>(); //Se Instancia un peticion
            services.AddControllers();


            #region SwaggerOpen Api
            //Register the Swagger services
           /* services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Task API",
                    Description = "Task API - ASP.NET Core Web API",
                    TermsOfService = new Uri("https://cla.dotnetfoundation.org/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Unicesar",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/borisgr04/CrudNgDotNetCore3"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licencia dotnet foundation",
                        Url = new Uri("https://www.byasystems.co/license"),
                    }
                });
            });*/

            #endregion
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
            /*
            #region Activar SwaggerUI
            app.UseSwagger();
            app.UseSwaggerUI
                options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Signus Prespuesto v1");
                }
            );
            #endregion
            */
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

    
        }
    }
}
