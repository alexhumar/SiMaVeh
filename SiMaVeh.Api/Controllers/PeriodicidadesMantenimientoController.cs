﻿using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SiMaVeh.Api.Constants;
using SiMaVeh.Api.Controllers.Parametrization.Interfaces;
using SiMaVeh.Domain.Constants;
using SiMaVeh.Domain.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SiMaVeh.Api.Controllers
{
    /// <summary>
    /// Periodicidades Mantenimiento Controller
    /// </summary>
    public class PeriodicidadesMantenimientoController : GenericController<PeriodicidadMantenimiento, long>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters"></param>
        public PeriodicidadesMantenimientoController(IControllerParameter parameters)
            : base(parameters)
        {
        }

        #region properties

        /// <summary>
        /// Obtiene los anios de la periodicidad mantenimiento
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Anios de la periodicidad mantenimiento</returns>
        /// <response code="200"></response>
        public async Task<IActionResult> GetAnios([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Anios);
        }

        /// <summary>
        /// Obtiene los dias de la periodicidad mantenimiento
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Dias de la periodicidad mantenimiento</returns>
        /// <response code="200"></response>
        public async Task<IActionResult> GetDias([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Dias);
        }

        /// <summary>
        /// Obtiene si la periodicidad mantenimiento es default
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Si la periodicidad mantenimiento es default</returns>
        /// <response code="200"></response>
        public async Task<IActionResult> GetEsDefault([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.EsDefault);
        }

        /// <summary>
        /// Obtiene los kilometros de la periodicidad mantenimiento
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Kilometros de la periodicidad mantenimiento</returns>
        /// <response code="200"></response>
        public async Task<IActionResult> GetKilometros([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Kilometros);
        }

        /// <summary>
        /// Obtiene los meses de la periodicidad mantenimiento
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Meses de la periodicidad mantenimiento</returns>
        /// <response code="200"></response>
        public async Task<IActionResult> GetMeses([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Meses);
        }

        /// <summary>
        /// Obtiene el modelo vehiculo de la periodicidad mantenimiento
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Modelo vehiculo de la periodicidad mantenimiento</returns>
        /// <response code="200"></response>
        [EnableQuery]
        public async Task<IActionResult> GetModeloVehiculo([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.ModeloVehiculo);
        }

        /// <summary>
        /// Obtiene el repuesto de la periodicidad mantenimiento
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Repuesto de la periodicidad mantenimiento</returns>
        /// <response code="200"></response>
        [EnableQuery]
        public async Task<IActionResult> GetTargetMantenimiento([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.TargetMantenimiento);
        }

        /// <summary>
        /// Modifica el modelo vehiculo asociado a la periodicidad mantenimiento.
        /// O modifica el repuesto asociado a la periodicidad mantenimiento.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="navigationProperty"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpConstants.Post, HttpConstants.Put)]
        public async Task<IActionResult> CreateRef([FromODataUri] long key, string navigationProperty, [FromBody] Uri link)
        {
            var resultado = HttpStatusCode.NotImplemented;
            var modeloVehiculoTypeName = entityTypeGetter.GetTypeAsString<ModeloVehiculo, long>();

            if (navigationProperty.Equals(modeloVehiculoTypeName))
            {
                resultado = await relatedEntityChanger.TryChangeRelatedEntityAsync<PeriodicidadMantenimiento, long, ModeloVehiculo, long>(Request, link, key);
            }
            else if (navigationProperty.Equals(EntityProperty.TargetMantenimiento))
            {
                resultado = await relatedEntityChanger.TryChangeRelatedEntityAsync<PeriodicidadMantenimiento, long, Repuesto, long>(Request, link, key);
            }

            return ResultFromHttpStatusCode(resultado);
        }

        #endregion
    }
}