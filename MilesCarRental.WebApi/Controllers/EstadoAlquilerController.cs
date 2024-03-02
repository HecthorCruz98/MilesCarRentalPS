using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.EstadoAlquiler.Commands.CreateEstadoAlquiler;
using MilesCarRental.Application.Features.EstadoAlquiler.Commands.UpdateEstadoAlquiler;
using MilesCarRental.Application.Features.TipoDocumento.Commands.CreateTipoDocumento;
using MilesCarRental.Application.Features.TipoDocumento.Commands.UpdateTipoDocumento;
using MilesCarRental.Application.Features.TipoDocumento.Queries.ListTipoDocuemnto;
using MilesCarRental.Application.Models.Cliente;
using MilesCarRental.Application.Models.EstadoAlquiler;
using System.Net;

namespace MilesCarRental.WebApi.Controllers
{
    /// <summary>
    /// Controlador para los esatdos de alquiler
    /// </summary>
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class EstadoAlquilerController : ControllerBase
    {
        /// <summary>
        /// Definicion de variables para el constructor
        /// </summary>
        IConfiguration _configuration;
        private readonly ILogger<EstadoAlquilerController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public EstadoAlquilerController(ILogger<EstadoAlquilerController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        /// <summary>
        /// Metodo de listar estados de alquiler
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetEstadoAlquiler")]
        public async Task<ActionResult<IEnumerable<EstadoAlquilerVm>>> GetEstadoAlquiler(int? Id)
        {
            var query = await _mediator.Send(new ListTipoDocumentoQuery(Id));
            return Ok(query);
        }
        /// <summary>
        /// Metodo registrar estados de alquiler
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost("CreateEstadoAlquiler")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateEstadoAlquiler([FromBody] CreateEstadoAlquilerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        /// <summary>
        /// Metodo actualizar estados de alquiler
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateEstadoAlquiler")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateEstadoAlquiler([FromBody] UpdateEstadoAlquilerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
