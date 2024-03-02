using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Cliente.Commands.CreateCliente;
using MilesCarRental.Application.Features.Cliente.Commands.UpdateCliente;
using MilesCarRental.Application.Features.Cliente.Queries.ListCliente;
using MilesCarRental.Application.Features.TipoDocumento.Commands.CreateTipoDocumento;
using MilesCarRental.Application.Features.TipoDocumento.Commands.UpdateTipoDocumento;
using MilesCarRental.Application.Features.TipoDocumento.Queries.ListTipoDocuemnto;
using MilesCarRental.Application.Models.Cliente;
using MilesCarRental.Application.Models.TipoDocumento;
using System.Net;

namespace MilesCarRental.WebApi.Controllers
{
    /// <summary>
    /// Controlador para los tipos de documento
    /// </summary>
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TipoDocumentoController : ControllerBase
    {
        /// <summary>
        /// Definicion de variables para el constructor
        /// </summary>
        IConfiguration _configuration;
        private readonly ILogger<TipoDocumentoController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public TipoDocumentoController(ILogger<TipoDocumentoController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        /// <summary>
        /// Metodo de listar clientes
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetTipoDocumento")]
        public async Task<ActionResult<IEnumerable<TipoDocumentoVm>>> GetTipoDocumento(int? Id)
        {
            var query = await _mediator.Send(new ListTipoDocumentoQuery(Id));
            return Ok(query);
        }
        /// <summary>
        /// Metodo registrar clientes
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost("CreateTipoDocumento")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateTipoDocumento([FromBody] CreateTipoDocumentoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        /// <summary>
        /// Metodo actualizar clientes
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateTipoDocumento")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateTipoDocumento([FromBody] UpdateTipoDocumentoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
