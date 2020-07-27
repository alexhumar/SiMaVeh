﻿using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SiMaVeh.Api.Constants;
using SiMaVeh.Api.Controllers.Parametrization.Interfaces;
using SiMaVeh.DataAccess.Constants;
using SiMaVeh.Domain.Constants;
using SiMaVeh.Domain.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SiMaVeh.Api.Controllers
{
    /// <summary>
    /// Modelos Vehiculo Controller
    /// </summary>
    public class ModelosVehiculoController : GenericController<ModeloVehiculo, long>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters"></param>
        public ModelosVehiculoController(IControllerParameter parameters)
            : base(parameters)
        {
        }

        #region properties

        /// <summary>
        /// Obtiene el aceite recomendado del modelo vehiculo
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Aceite recomendado del modelo vehiculo</returns>
        /// <response code="200"></response>
        [EnableQuery]
        public async Task<IActionResult> GetAceiteRecomendado([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.AceiteRecomendado);
        }

        /// <summary>
        /// Obtiene el equipamiento airbag del modelo vehiculo
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Equipamiento airbag del modelo vehiculo</returns>
        /// <response code="200"></response>
        [EnableQuery]
        public async Task<IActionResult> GetAirbags([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Airbags);
        }

        /// <summary>
        /// Obtiene la fuente de energia recomendada del modelo vehiculo
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Fuente de energia del modelo vehiculo</returns>
        /// <response code="200"></response>
        [EnableQuery]
        public async Task<IActionResult> GetFuenteEnergiaRecomendada([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.FuenteEnergiaRecomendada);
        }

        /// <summary>
        /// Obtiene el grupo modelo del modelo vehiculo
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Grupo modelo del modelo vehiculo</returns>
        /// <response code="200"></response>
        [EnableQuery]
        public async Task<IActionResult> GetGrupoModelo([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.GrupoModelo);
        }

        /// <summary>
        /// Obtiene las presiones de neumaticos recomendada del modelo vehiculo
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Presiones de neumaticos recomendada del modelo vehiculo</returns>
        /// <response code="200"></response>
        [EnableQuery(PageSize = QueryConstants.PageSize)]
        public async Task<IActionResult> GetPresionesNeumaticosRecomendadas([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.PresionesNeumaticosRecomendadas);
        }

        /// <summary>
        /// Obtiene los repuestos recomendados del modelo vehiculo
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Repuestos recomendados del modelo vehiculo</returns>
        /// <response code="200"></response>
        [EnableQuery(PageSize = QueryConstants.PageSize)]
        public async Task<IActionResult> GetRepuestosRecomendados([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.RepuestosRecomendados);
        }

        /// <summary>
        /// Obtiene el tipo de fuente de energia del modelo vehiculo
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Tipo de fuente de energia del modelo vehiculo</returns>
        /// <response code="200"></response>
        [EnableQuery]
        public async Task<IActionResult> GetTipoFuenteEnergia([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.TipoFuenteEnergia);
        }

        /// <summary>
        /// Obtiene la version del modelo vehiculo
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Version del modelo vehiculo</returns>
        /// <response code="200"></response>
        [EnableQuery]
        public async Task<IActionResult> GetVersion([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Version);
        }

        /// <summary>
        /// Modifica el tipo fuente energia asociado a la fuente energia.
        /// O modifica la marca asociada a la fuente energia.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="navigationProperty"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpConstants.Post, HttpConstants.Put)]
        public async Task<IActionResult> CreateRef([FromODataUri] long key, string navigationProperty, [FromBody] Uri link)
        {
            var resultado = HttpStatusCode.NotImplemented;
            var grupoModeloTypeName = entityTypeGetter.GetTypeAsString<GrupoModelo, long>();
            var tipoFuenteEnergiaTypeName = entityTypeGetter.GetTypeAsString<TipoFuenteEnergia, long>();

            if (navigationProperty.Equals(grupoModeloTypeName))
            {
                resultado = await relatedEntityChanger.TryChangeRelatedEntityAsync<ModeloVehiculo, long, GrupoModelo, long>(Request, key, link);
            }
            else if (navigationProperty.Equals(EntityProperty.AceiteRecomendado))
            {
                resultado = await relatedEntityChanger.TryChangeRelatedEntityAsync<ModeloVehiculo, long, Aceite, long>(Request, key, link);
            }
            else if (navigationProperty.Equals(EntityProperty.Airbags))
            {
                resultado = await relatedEntityChanger.TryChangeRelatedEntityAsync<ModeloVehiculo, long, EquipamientoAirbags, string>(Request, key, link);
            }
            else if (navigationProperty.Equals(tipoFuenteEnergiaTypeName))
            {
                resultado = await relatedEntityChanger.TryChangeRelatedEntityAsync<ModeloVehiculo, long, TipoFuenteEnergia, long>(Request, key, link);
            }
            else if (navigationProperty.Equals(EntityProperty.FuenteEnergiaRecomendada))
            {
                resultado = await relatedEntityChanger.TryChangeRelatedEntityAsync<ModeloVehiculo, long, FuenteEnergia, long>(Request, key, link);
            }
            else if (navigationProperty.Equals(EntityProperty.RepuestosRecomendados))
            {
                resultado = await relatedEntityAdder.TryAddRelatedEntityAsync<ModeloVehiculo, long, Repuesto, long>(Request, key, link);
            }
            else if (navigationProperty.Equals(EntityProperty.PresionesNeumaticosRecomendadas))
            {
                resultado = await relatedEntityAdder.TryAddRelatedEntityAsync<ModeloVehiculo, long, PresionNeumatico, long>(Request, key, link);
            }

            return ResultFromHttpStatusCode(resultado);
        }

        /// <summary>
        /// Borra la referencia de un repuesto en la coleccion de repuestos recomendados.
        /// O borra la referencia de una presion de neumatico en la coleccion de presiones de neumaticos recomendadas.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="relatedKey"></param>
        /// <param name="navigationProperty"></param>
        /// <returns></returns>
        public override async Task<IActionResult> DeleteRef([FromODataUri] long key, [FromODataUri] string relatedKey, string navigationProperty)
        {
            var resultado = HttpStatusCode.NotImplemented;

            //TODO: revisar PresionesNeumaticosRecomendadas ya que deberia ser many to many

            if (navigationProperty.Equals(EntityProperty.RepuestosRecomendados))
            {
                resultado = await relatedEntityRemover.TryRemoveRelatedEntityAsync<ModeloVehiculo, long, Repuesto, long>(Request, key, Convert.ToInt64(relatedKey));
            }
            else if (navigationProperty.Equals(EntityProperty.PresionesNeumaticosRecomendadas))
            {
                resultado = await relatedEntityRemover.TryRemoveRelatedEntityAsync<ModeloVehiculo, long, PresionNeumatico, long>(Request, key, Convert.ToInt64(relatedKey));
            }

            return ResultFromHttpStatusCode(resultado);
        }

        #endregion
    }
}