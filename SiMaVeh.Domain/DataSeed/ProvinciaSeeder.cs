using SiMaVeh.Domain.DataSeed.Fixtures.Interfaces;
using SiMaVeh.Domain.DataSeed.Interfaces;
using SiMaVeh.Domain.Models;
using System.Collections.Generic;

namespace SiMaVeh.Domain.DataSeed
{
    /// <summary>
    /// Seeder de Provincia
    /// </summary>
    public class ProvinciaSeeder : ISeeder<Provincia, long>
    {
        private readonly IFixtureProvincia fixtureProvincia;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fixtureProvincia"></param>
        public ProvinciaSeeder(IFixtureProvincia fixtureProvincia)
        {
            this.fixtureProvincia = fixtureProvincia;
        }

        /// <summary>
        /// Genera las Provincias default
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetSeeds()
        {
            var result = new List<object>();

            //TODO - por limitaciones de EFCore en torno a DataSeed, y para no ensuciar el modelo con 
            //definiciones de FKs, se utilizan tipos anonimos para cargar las entidades y poder especificar la 
            //shadow property que EFCore utiliza a nivel interno (por ejemplo, PaisId en Provincia).
            //Seguir el tema para ver si en algun momento se soluciona.
            foreach (var provinciasPorPais in fixtureProvincia.GetProvincias())
            {
                var idPais = provinciasPorPais.Key;

                foreach (var provincia in provinciasPorPais.Value)
                {
                    result.Add(new
                    {
                        Id = provincia.Key,
                        Nombre = provincia.Value,
                        PaisId = idPais
                    });
                }
            }

            return result;
        }
    }
}
