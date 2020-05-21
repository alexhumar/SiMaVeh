using SiMaVeh.Domain.DataSeed.Fixtures.Interfaces;
using SiMaVeh.Domain.DataSeed.Interfaces;
using SiMaVeh.Domain.Models;
using System.Collections.Generic;

namespace SiMaVeh.Domain.DataSeed
{
    /// <summary>
    /// Seeder de Pais
    /// </summary>
    public class PaisSeeder : ISeeder<Pais, long>
    {
        private readonly IFixturePais fixturePais;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fixturePais"></param>
        public PaisSeeder(IFixturePais fixturePais)
        {
            this.fixturePais = fixturePais;
        }

        /// <summary>
        /// Genera los Paises default
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetSeeds()
        {
            var result = new List<object>();

            foreach (var paisFixture in fixturePais.GetPaises())
            {
                result.Add(new
                {
                    Id = paisFixture.Key,
                    Nombre = paisFixture.Value
                });
            }

            return result;
        }
    }
}
