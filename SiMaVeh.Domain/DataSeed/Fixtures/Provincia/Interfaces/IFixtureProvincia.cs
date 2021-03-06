﻿using SiMaVeh.Domain.DataSeed.Models;
using System.Collections.Generic;

namespace SiMaVeh.Domain.DataSeed.Fixtures.Provincia.Interfaces
{
    /// <summary>
    /// Interfaz de FixtureProvincia
    /// </summary>
    public interface IFixtureProvincia
    {
        /// <summary>
        /// Get Provincias
        /// </summary>
        /// <returns></returns>
        IDictionary<long, List<DatosEntidad>> GetProvincias();
    }
}
