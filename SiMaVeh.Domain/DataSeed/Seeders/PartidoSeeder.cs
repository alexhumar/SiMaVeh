﻿using SiMaVeh.Domain.DataSeed.Fixtures.Partido;
using SiMaVeh.Domain.DataSeed.Fixtures.Partido.Interfaces;
using SiMaVeh.Domain.DataSeed.Interfaces;
using SiMaVeh.Domain.Models;
using System.Collections.Generic;

namespace SiMaVeh.Domain.DataSeed.Seeders
{
    /// <summary>
    /// Seeder de Partido
    /// </summary>
    public class PartidoSeeder : ISeeder<Partido, long>
    {
        private readonly IFixturePartido fixturePartido;

        /// <summary>
        /// Constructor
        /// </summary>
        public PartidoSeeder()
        {
            fixturePartido = new FixturePartido();
        }

        /// <summary>
        /// Genera los Partidos default
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetSeeds()
        {
            var result = new List<object>();

            foreach (var partidosPorProvincia in fixturePartido.GetPartidos())
            {
                var idProvincia = partidosPorProvincia.Key;

                foreach (var partido in partidosPorProvincia.Value)
                {
                    result.Add(new
                    {
                        Id = partido.Key,
                        Nombre = partido.Value,
                        ProvinciaId = idProvincia
                    });
                }
            }

            return result;
        }
    }
}
