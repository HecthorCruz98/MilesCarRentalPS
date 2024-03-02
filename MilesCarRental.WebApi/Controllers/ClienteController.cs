using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Cliente.Commands.CreateCliente;
using MilesCarRental.Application.Features.Cliente.Commands.UpdateCliente;
using MilesCarRental.Application.Features.Cliente.Queries.ListCliente;
using MilesCarRental.Application.Models.Cliente;
using System.Net;

namespace MilesCarRental.WebApi.Controllers
{
    /// <summary>
    /// Controlador para los clientes
    /// </summary>
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        /// <summary>
        /// Definicion de variables para el constructor
        /// </summary>
        IConfiguration _configuration;
        private readonly ILogger<ClienteController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public ClienteController(ILogger<ClienteController> logger, IConfiguration configuration, IMediator mediator)
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
        [HttpGet("GetCliente")]
        public async Task<ActionResult<IEnumerable<ClienteVm>>> GetCliente(int? Id)
        {
            var query = await _mediator.Send(new ListClienteQuery(Id));
            return Ok(query);
        }
        /// <summary>
        /// Metodo registrar clientes
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost("CreateCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCliente([FromBody] CreateClienteCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        /// <summary>
        /// Metodo actualizar clientes
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateCliente([FromBody] UpdateClienteCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
