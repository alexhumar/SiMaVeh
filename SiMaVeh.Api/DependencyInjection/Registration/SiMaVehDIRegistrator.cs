using Microsoft.Extensions.DependencyInjection;
using SiMaVeh.Api.Controllers.Parametrization;
using SiMaVeh.DataAccess.DataSeed;
using SiMaVeh.Domain.BusinessLogic.Entities.Interfaces;
using SiMaVeh.Domain.DataSeed;
using SiMaVeh.Domain.DataSeed.Fixtures;
using SiMaVeh.Domain.DataSeed.Fixtures.Interfaces;
using SiMaVeh.Domain.DataSeed.Fixtures.Partido;
using SiMaVeh.Domain.DataSeed.Fixtures.Provincia;
using SiMaVeh.Domain.DataSeed.Interfaces;
using SiMaVeh.Domain.Models;
using SiMaVeh.Helpers;

namespace SiMaVeh.Api.DependencyInjection.Registration
{
    public class SiMaVehDIRegistrator
    {
        public static void RegisterDI(IServiceCollection services)
        {
            services.AddScoped<IEntityGetter, EntityGetter>();
            services.AddScoped<IControllerParameter, ControllerParameter>();

            #region dataseed

            services.AddScoped<IPaisLoadersProvider, PaisLoadersProvider>();
            services.AddScoped<IProvinciaLoadersProvider, ProvinciaLoadersProvider>();
            services.AddScoped<IPartidoLoadersProvider, PartidoLoadersProvider>();
            services.AddScoped<IFixturePais, FixturePais>();
            services.AddScoped<IFixtureProvincia, FixtureProvincia>();
            services.AddScoped<IFixturePartido, FixturePartido>();
            services.AddScoped<ISeeder<Pais, long>, PaisSeeder>();
            services.AddScoped<ISeeder<Provincia, long>, ProvinciaSeeder>();
            services.AddScoped<ISeeder<Partido, long>, PartidoSeeder>();
            services.AddScoped<IDataSeeder, DataSeeder>();

            #endregion

            #region validators

            ValidatorRegistrator.RegisterValidators(services);

            #endregion
        }
    }
}
