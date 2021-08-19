using DesafioSoftFocus.Api.Controllers.Base;
using DesafioSoftFocus.Api.Models;
using DesafioSoftFocus.Api.Models.Request;
using DesafioSoftFocus.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Controllers
{
    [Route("api/comunicacaoperda")]
    [AllowAnonymous]
    public class ComunicacaoPerdaController : BaseController
    {
        private readonly IComunicacaoPerdaService _appService;

        public ComunicacaoPerdaController(IComunicacaoPerdaService appService)
        {
            _appService = appService;
        }

        /// <remarks>
        /// Obtém todos os comunicados
        /// </remarks>
        /// <returns></returns>        
        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(200, Type = typeof(List<ComunicacaoPerda>))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _appService.GetAll());
            }
            catch (Exception ex)
            {
                return HandleBaseExceptionResponse(ex);
            }
        }

        /// <remarks>
        /// Obtém um comunicado por id
        /// </remarks>
        /// <returns></returns>        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200, Type = typeof(ComunicacaoPerda))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _appService.Get(id));
            }
            catch (Exception ex)
            {
                return HandleBaseExceptionResponse(ex);
            }
        }

        /// <remarks>
        /// Obtém comunicados por cpf
        /// </remarks>
        /// <returns></returns>        
        [HttpGet]
        [Route("getByCpf/{cpf}")]
        [ProducesResponseType(200, Type = typeof(List<ComunicacaoPerda>))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            try
            {
                return Ok(await _appService.GetByCpf(cpf));
            }
            catch (Exception ex)
            {
                return HandleBaseExceptionResponse(ex);
            }
        }

        /// <remarks>
        /// Obtém comunicados no raio de 10km, com mesma data e eventos diferentes
        /// </remarks>
        /// <returns></returns>        
        [HttpPost]
        [Route("PostComunicacaoPerdaExistente")]
        [ProducesResponseType(200, Type = typeof(List<ComunicacaoPerda>))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> PostComunicacaoPerdaExistente(GetComunicacaoPerdaExistenteRequest requestData)
        {
            try
            {
                return Ok(await _appService.GetComunicacaoPerdaExistente(requestData));
            }
            catch (Exception ex)
            {
                return HandleBaseExceptionResponse(ex);
            }
        }

        /// <remarks>
        /// Inclui um comunicado de perda
        /// </remarks>
        /// <returns></returns>        
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(int))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Post(PostComunicacaoPerdaRequest requestData)
        {
            try
            {
                return Ok(await _appService.Insert(requestData));
            }
            catch (Exception ex)
            {
                return HandleBaseExceptionResponse(ex);
            }
        }

        /// <remarks>
        /// Atualiza comunicado de perda
        /// </remarks>
        /// <returns></returns>        
        [HttpPut("{id:int}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Put(int id, PutComunicacaoPerdaRequest requestData)
        {
            try
            {
                await _appService.Update(id, requestData);

                return Ok();

            }
            catch (Exception ex)
            {
                return HandleBaseExceptionResponse(ex);
            }
        }

        /// <remarks>
        /// Remove comunicado de perda
        /// </remarks>
        /// <returns></returns>        
        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _appService.Delete(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return HandleBaseExceptionResponse(ex);
            }
        }
    }
}
