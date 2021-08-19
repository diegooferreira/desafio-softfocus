using DesafioSoftFocus.Api.Models;
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
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _appService;

        public EventoController(IEventoService appService)
        {
            _appService = appService;
        }

        /// <remarks>
        /// Obtém todos os eventos
        /// </remarks>
        /// <returns></returns>        
        [HttpGet]
        [Route("getAll")]
        [ProducesResponseType(200, Type = typeof(List<Evento>))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _appService.GetAll());
        }
    }
}
