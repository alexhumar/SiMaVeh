using SiMaVeh.Domain.DataSeed.Fixtures.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SiMaVeh.Domain.DataSeed.Fixtures
{
    /// <summary>
    /// Fixture con informacion de Paises
    /// </summary>
    public class FixturePais : IFixturePais
    {
        private readonly IPaisLoadersProvider paisLoadersProvider;
        private Dictionary<long, string> paises;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paisLoadersProvider"></param>
        public FixturePais(IPaisLoadersProvider paisLoadersProvider)
        {
            this.paisLoadersProvider = paisLoadersProvider;

            Initialize();
        }

        /// <summary>
        /// Get Paises
        /// </summary>
        /// <returns></returns>
        public Dictionary<long, string> GetPaises()
        {
            return paises;
        }

        /// <summary>
        /// Find by Nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public KeyValuePair<long, string>? FindByNombre(string nombre)
        {
            return paises.FirstOrDefault(p => p.Value == nombre);
        }

        private void Initialize()
        {
            paises = new Dictionary<long, string>();

            foreach (var loader in paisLoadersProvider.GetLoaders())
            {
                loader.Load(paises);
            }
        }
    }
}
