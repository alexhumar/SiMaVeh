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
    /// Marcas Controller
    /// </summary>
    public class MarcasController : GenericController<Marca, long>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters"></param>
        public MarcasController(IControllerParameter parameters)
            : base(parameters)
        {
        }

        #region properties

        /// <summary>
        /// Obtiene las categorías de la marca
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Categoria de la marca</returns>
        /// <response code="200"></response>
        [EnableQuery(PageSize = QueryConstants.PageSize)]
        public async Task<IActionResult> GetCategorias([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Categorias);
        }

        /// <summary>
        /// Obtiene el nombre de la marca
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Nombre de la marca</returns>
        /// <response code="200"></response>
        public async Task<IActionResult> GetNombre([FromODataUri] long key)
        {
            var entity = await repository.FindAsync(key);

            return entity == null ? NotFound() : (IActionResult)Ok(entity.Nombre);
        }

        /// <summary>
        /// Asocia una categoria de marca existente en la coleccion de categorias de la marca.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="navigationProperty"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        [AcceptVerbs("POST", "PUT")]
        public async Task<IActionResult> CreateRef([FromODataUri] long key, string navigationProperty, [FromBody] Uri link)
        {
            if (link == null)
            {
                return BadRequest();
            }

            var marca = await repository.FindAsync(key);
            if (marca == null)
            {
                return NotFound();
            }

            var categoriaMarcaCollectionName = entityTypeGetter.GetCollectionNameAsString<CategoriaMarca, long>();

            if (navigationProperty.Equals(categoriaMarcaCollectionName))
            {
                if (!Request.Method.Equals(HttpConstants.Post))
                {
                    return BadRequest();
                }

                var categoriaMarca = await relatedEntityGetter.TryGetEntityFromRelatedLink<CategoriaMarca, long>(link);
                if (categoriaMarca == null)
                {
                    return NotFound();
                }

                marca.Agregar(categoriaMarca);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotImplemented);
            }

            await repository.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        #endregion
    }
}