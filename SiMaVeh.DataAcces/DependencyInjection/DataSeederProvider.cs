using Microsoft.Extensions.DependencyInjection;
using SiMaVeh.DataAccess.DataSeed;
using System;

namespace SiMaVeh.DataAccess.DependencyInjection
{
    /// <summary>
    /// Clase especifica, a modo de excepcion, para poder utilizar
    /// el DataSeeder en SiMaVehContext con inyeccion de dependencias.
    /// </summary>
    public class DataSeederProvider
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IDataSeeder GetDataSeeder()
        {
            return ServiceProvider.GetService<IDataSeeder>();
        }
    }
}
