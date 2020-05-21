using FluentValidation.AspNetCore;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SiMaVeh.Api.DependencyInjection.Registration;
using SiMaVeh.DataAccess.DependencyInjection;
using SiMaVeh.DataAccess.Model;

namespace SiMaVeh
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SiMaVehContext>(opt => opt
                .UseLazyLoadingProxies()
                .UseMySql(connection,
                          o =>
                          {
                              o.EnableRetryOnFailure(); //Esto es para reintentar automaticamente comandos fallidos a la BD. Lo habilite a raiz del uso de Migrations.
                              o.MigrationsAssembly(typeof(SiMaVehContext).Assembly.FullName);
                          }));
            services.AddOData();
            services.AddMvc(options =>
                {
                    // add custom binder to beginning of collection
                    // options.ModelBinderProviders.Insert(0, new ProvinciaEntityBinderProvider());

                    //TODO: Esto es para habilitar el soporte legacy para IRouter. Habria que ver como reemplazarlo!
                    options.EnableEndpointRouting = false;
                })
                .AddFluentValidation();

            SiMaVehDIRegistrator.RegisterDI(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapODataServiceRoute("odata", "simaveh", MyModelBuilder.getEdmModel());
                //Work-around for issue #1175
                routeBuilder.EnableDependencyInjection();
            });

            //Esto es para poder inyectar el DataSeeder en SiMaVehContext. No me quedo otra.
            DataSeederProvider.ServiceProvider = app.ApplicationServices;

            //Esto es para que se actualice la BD mediante migrations cuando arranca la Api. No es lo ideal,
            //pero como no es un modelo grande, esta bien.
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var siMaVehContext = scope.ServiceProvider.GetService<SiMaVehContext>();
                siMaVehContext.Database.Migrate();
            }
        }
    }
}
