using SiMaVeh.Domain.DataSeed.Fixtures.Interfaces;
using SiMaVeh.Domain.DataSeed.Fixtures.Partido.Loaders;
using System.Collections.Generic;

namespace SiMaVeh.Domain.DataSeed.Fixtures.Provincia
{
    /// <summary>
    /// Provider de Loaders de Provincia
    /// </summary>
    public class ProvinciaLoadersProvider : IProvinciaLoadersProvider
    {
        private readonly IFixturePais fixturePais;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fixturePais"></param>
        public ProvinciaLoadersProvider(IFixturePais fixturePais)
        {
            this.fixturePais = fixturePais;
        }

        /// <summary>
        /// Retorna los providers de loaders de provincias
        /// </summary>
        /// <returns></returns>
        public List<IFixtureItemKeyValueLoader<long, long, string>> GetLoaders()
        {
            return new List<IFixtureItemKeyValueLoader<long, long, string>>
            {
                new ArgentinaLoader(fixturePais),
                new UruguayLoader(fixturePais),
            };
        }
    }
}
