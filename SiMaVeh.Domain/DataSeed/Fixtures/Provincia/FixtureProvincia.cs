using SiMaVeh.Domain.DataSeed.Fixtures.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SiMaVeh.Domain.DataSeed.Fixtures.Provincia
{
    /// <summary>
    /// Fixture con informacion de Provincias
    /// </summary>
    public class FixtureProvincia : IFixtureProvincia
    {
        private readonly IProvinciaLoadersProvider provinciaLoadersProvider;
        private Dictionary<long, Dictionary<long, string>> provincias;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="provinciaLoadersProvider"></param>
        public FixtureProvincia(IProvinciaLoadersProvider provinciaLoadersProvider)
        {
            this.provinciaLoadersProvider = provinciaLoadersProvider;

            Initialize();
        }

        /// <summary>
        /// Get Provincias
        /// </summary>
        /// <returns></returns>
        public Dictionary<long, Dictionary<long, string>> GetProvincias()
        {
            return provincias;
        }

        /// <summary>
        /// Find by Nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public KeyValuePair<long, string>? FindByNombre(string nombre)
        {
            KeyValuePair<long, string>? result = null;

            foreach (var provinciasPais in provincias)
            {
                KeyValuePair<long, string>? provincia = provinciasPais.Value.FirstOrDefault(v => v.Value == nombre);

                if (provincia != null)
                {
                    result = provincia;
                    break;
                }
            }

            return result;
        }

        private void Initialize()
        {
            provincias = new Dictionary<long, Dictionary<long, string>>();

            foreach (var loader in provinciaLoadersProvider.GetLoaders())
            {
                loader.Load(provincias);
            }
        }
    }
}
