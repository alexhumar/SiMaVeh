﻿using SiMaVeh.Domain.DataSeed.Models;
using SiMaVeh.Domain.Enums;
using System.Collections.Generic;

namespace SiMaVeh.Domain.DataSeed.Fixtures.Builders.Interfaces
{
    /// <summary>
    /// Interfaz de Datos Entidad Builder
    /// </summary>
    public interface IDatosEntidadBuilder
    {
        /// <summary>
        /// Build datos entidad general
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        DatosEntidad Build(long id, string nombre, string descripcion = null);

        /// <summary>
        /// Build datos moneda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        DatosMoneda Build(string id, string nombre);

        /// <summary>
        /// Build datos marca
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="categorias"></param>
        /// <returns></returns>
        DatosMarca Build(long id, string nombre, IEnumerable<DatosEntidad> categorias);

        /// <summary>
        /// Build datos ubicacion pieza
        /// </summary>
        /// <param name="izquierda"></param>
        /// <param name="superior"></param>
        /// <returns></returns>
        DatosUbicacionPieza Build(bool izquierda, bool superior);

        /// <summary>
        /// Build datos equipamiento airbags
        /// </summary>
        /// <param name="conductor"></param>
        /// <param name="acompanante"></param>
        /// <param name="delanteroIzquierdo"></param>
        /// <param name="delanteroDerecho"></param>
        /// <param name="traseroIzquierdo"></param>
        /// <param name="traseroDerecho"></param>
        /// <returns></returns>
        DatosEquipamientoAirbags Build(bool conductor, bool acompanante, TipoAirbagLateral delanteroIzquierdo,
            TipoAirbagLateral delanteroDerecho, TipoAirbagLateral traseroIzquierdo, TipoAirbagLateral traseroDerecho);

        /// <summary>
        /// Build datos fuente energia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="marca"></param>
        /// <param name="tipoFuenteEnergia"></param>
        /// <returns></returns>
        DatosFuenteEnergia Build(long id, string nombre, DatosMarca marca, DatosEntidad tipoFuenteEnergia);
    }
}
