using SiMaVeh.Domain.DataSeed.Fixtures.Interfaces;
using System.Collections.Generic;

namespace SiMaVeh.Domain.DataSeed.Fixtures.Partido
{
    /// <summary>
    /// Fixture con informacion de Provincias
    /// </summary>
    public class FixturePartido : IFixturePartido
    {
        private readonly IPartidoLoadersProvider partidoLoadersProvider;
        private Dictionary<long, Dictionary<long, string>> partidos;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partidoLoadersProvider"></param>
        public FixturePartido(IPartidoLoadersProvider partidoLoadersProvider)
        {
            this.partidoLoadersProvider = partidoLoadersProvider;

            Initialize();
        }

        /// <summary>
        /// Get Provincias
        /// </summary>
        /// <returns></returns>
        public Dictionary<long, Dictionary<long, string>> GetPartidos()
        {
            return partidos;
        }

        private void Initialize()
        {
            partidos = new Dictionary<long, Dictionary<long, string>>();

            foreach (var loader in partidoLoadersProvider.GetLoaders())
            {
                loader.Load(partidos);
            }
        }
    }
}
