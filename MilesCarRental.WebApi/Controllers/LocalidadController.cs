using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Cliente.Commands.CreateCliente;
using MilesCarRental.Application.Features.Cliente.Commands.UpdateCliente;
using MilesCarRental.Application.Features.Cliente.Queries.ListCliente;
using MilesCarRental.Application.Features.Localidad.Commands.CreateLocalidad;
using MilesCarRental.Application.Features.Localidad.Commands.UpdateLocalidad;
using MilesCarRental.Application.Features.Localidad.Queries.ListLocalidad;
using MilesCarRental.Application.Models.Cliente;
using MilesCarRental.Application.Models.Localidad;
using System.Net;

namespace MilesCarRental.WebApi.Controllers
{
    /// <summary>
    /// Controlador para las localidades
    /// </summary>
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class LocalidadController : ControllerBase
    {
        /// <summary>
        /// Definicion de variables para el constructor
        /// </summary>
        IConfiguration _configuration;
        private readonly ILogger<LocalidadController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public LocalidadController(ILogger<LocalidadController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        /// <summary>
        /// Metodo de listar localidades
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetLocalidad")]
        public async Task<ActionResult<IEnumerable<LocalidadVm>>> GetLocalidad(int? Id)
        {
            var query = await _mediator.Send(new ListLocalidadQuery(Id));
            return Ok(query);
        }
        /// <summary>
        /// Metodo registrar localidades
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost("CreateLocalidad")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateLocalidad([FromBody] CreateLocalidadCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        /// <summary>
        /// Metodo actualizar localidades
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateLocalidad")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateLocalidad([FromBody] UpdateLocalidadCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
