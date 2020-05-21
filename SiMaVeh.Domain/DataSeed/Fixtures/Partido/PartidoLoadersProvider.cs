using SiMaVeh.Domain.DataSeed.Fixtures.Interfaces;
using SiMaVeh.Domain.DataSeed.Fixtures.Partido.Loaders;
using System.Collections.Generic;

namespace SiMaVeh.Domain.DataSeed.Fixtures.Partido
{
    /// <summary>
    /// Provider de Loaders de Partido
    /// </summary>
    public class PartidoLoadersProvider : IPartidoLoadersProvider
    {
        private readonly IFixtureProvincia fixtureProvincia;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fixtureProvincia"></param>
        public PartidoLoadersProvider(IFixtureProvincia fixtureProvincia)
        {
            this.fixtureProvincia = fixtureProvincia;
        }

        /// <summary>
        /// Retorna los providers de loaders de partidos
        /// </summary>
        /// <returns></returns>
        public List<IFixtureItemKeyValueLoader<long, long, string>> GetLoaders()
        {
            return new List<IFixtureItemKeyValueLoader<long, long, string>>
            {
                new BuenosAiresLoader(fixtureProvincia),
                new CatamarcaLoader(fixtureProvincia),
                new ChacoLoader(fixtureProvincia),
                new ChubutLoader(fixtureProvincia),
                new CordobaLoader(fixtureProvincia),
                new CorrientesLoader(fixtureProvincia),
                new EntreRiosLoader(fixtureProvincia),
                new FormosaLoader(fixtureProvincia),
                new JujuyLoader(fixtureProvincia),
                new LaPampaLoader(fixtureProvincia),
                new LaRiojaLoader(fixtureProvincia),
                new MendozaLoader(fixtureProvincia),
                new MisionesLoader(fixtureProvincia),
                new NeuquenLoader(fixtureProvincia),
                new RioNegroLoader(fixtureProvincia),
                new SaltaLoader(fixtureProvincia),
                new SanJuanLoader(fixtureProvincia),
                new SanLuisLoader(fixtureProvincia),
                new SantaCruzLoader(fixtureProvincia),
                new SantaFeLoader(fixtureProvincia),
                new SantiagoDelEsteroLoader(fixtureProvincia),
                new TierraDelFuegoLoader(fixtureProvincia),
                new TucumanLoader(fixtureProvincia)
            };
        }
    }
}
