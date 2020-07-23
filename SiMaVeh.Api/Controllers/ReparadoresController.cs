﻿using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SiMaVeh.Api.Constants;
using SiMaVeh.Api.Controllers.Parametrization.Interfaces;
using SiMaVeh.DataAccess.Constants;
using SiMaVeh.Domain.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SiMaVeh.Api.Controllers
{
    /// <summary>
    /// Reparadores Controller
    /// </summary>
    public class ReparadoresController : GenericController<Reparador, long>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters"></param>
        public ReparadoresController(IControllerParameter parameters)
            : base(parameters)
        {
        }

        #region properties

        /// <summary>
        /// Obtiene el apellido del reparador
        /// </summary>
        /// <returns>Apellido del reparador</returns>
        /// <response code="200"></response>
        public async Task<IActionResult> GetApellido([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Apellido);
        }

        /// <summary>
        /// Obtiene las entidades reparadoras del reparador
        /// </summary>
        /// <returns>Entidades reparadoras del reparador</returns>
        /// <response code="200"></response>
        [EnableQuery(PageSize = QueryConstants.PageSize)]
        public async Task<IActionResult> GetEntidadesReparadoras([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.EntidadesReparadoras);
        }

        /// <summary>
        /// Obtiene el nombre del reparador
        /// </summary>
        /// <returns>Nombre del reparador</returns>
        /// <response code="200"></response>
        public async Task<IActionResult> GetNombre([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Nombre);
        }

        /// <summary>
        /// Obtiene el numero de documento del reparador
        /// </summary>
        /// <returns>Numero de documento del reparador</returns>
        /// <response code="200"></response>
        public async Task<IActionResult> GetNumeroDocumento([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.NumeroDocumento);
        }

        /// <summary>
        /// Obtiene los telefonos del reparador
        /// </summary>
        /// <returns>Telefonos del reparador</returns>
        /// <response code="200"></response>
        [EnableQuery(PageSize = QueryConstants.PageSize)]
        public async Task<IActionResult> GetTelefonos([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Telefonos);
        }

        /// <summary>
        /// Obtiene el tipo de documento del reparador
        /// </summary>
        /// <returns>Tipo de documento del reparador</returns>
        /// <response code="200"></response>
        [EnableQuery]
        public async Task<IActionResult> GetTipoDocumento([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.TipoDocumento);
        }

        /// <summary>
        /// Asocia un vehiculo existente en la coleccion de vehiculos del usuario.
        /// O asocia un telefono existente en la coleccion de telefonos del usuario.
        /// O modifica el tipo documento asociado al usuario.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="navigationProperty"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpConstants.Post, HttpConstants.Put)]
        public async Task<IActionResult> CreateRef([FromODataUri] long key, string navigationProperty, [FromBody] Uri link)
        {
            var resultado = HttpStatusCode.NotImplemented;
            var entidadReparadorCollectionName = entityTypeGetter.GetCollectionNameAsString<EntidadReparadora, long>();
            var tipoDocumentoTypeName = entityTypeGetter.GetTypeAsString<TipoDocumento, long>();
            var telefonoCollectionName = entityTypeGetter.GetCollectionNameAsString<Telefono, long>();

            if (navigationProperty.Equals(entidadReparadorCollectionName))
            {
                resultado = await relatedEntityAdder.TryAddRelatedEntityAsync<Reparador, long, EntidadReparadora, long>(Request, link, key);
            }
            else if (navigationProperty.Equals(telefonoCollectionName))
            {
                resultado = await relatedEntityAdder.TryAddRelatedEntityAsync<Persona, long, Telefono, long>(Request, link, key);
            }
            else if (navigationProperty.Equals(tipoDocumentoTypeName))
            {
                resultado = await relatedEntityChanger.TryChangeRelatedEntityAsync<Persona, long, TipoDocumento, long>(Request, link, key);
            }

            return ResultFromHttpStatusCode(resultado);
        }

        #endregion
    }
}