﻿using System.Collections.Generic;

namespace SiMaVeh.Domain.DataSeed.Fixtures.Interfaces
{
    /// <summary>
    /// Interfaz para cargar un item a un diccionario y subdiccionario
    /// </summary>
    /// <typeparam name="TIdBeParent"></typeparam>
    /// <typeparam name="TIdBeChild"></typeparam>
    /// <typeparam name="TValueBe"></typeparam>
    public interface IFixtureItemKeyValueLoader<TIdBeParent, TIdBeChild, TValueBe>
    {
        /// <summary>
        /// Metodo que carga un item en un diccionario y subdiccionario
        /// </summary>
        /// <param name="dictionary"></param>
        void Load(Dictionary<TIdBeParent, Dictionary<TIdBeChild, TValueBe>> dictionary);
    }
}
