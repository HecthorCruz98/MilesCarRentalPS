using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Carro.Commands.CreateCarro;
using MilesCarRental.Application.Features.Carro.Commands.UpdateCarro;
using MilesCarRental.Application.Features.Carro.Queries.ListCarro;
using MilesCarRental.Application.Features.Carro.Queries.ListCarroAllVm;
using MilesCarRental.Application.Features.Cliente.Commands.CreateCliente;
using MilesCarRental.Application.Features.Cliente.Commands.UpdateCliente;
using MilesCarRental.Application.Features.Cliente.Queries.ListCliente;
using MilesCarRental.Application.Models.Carro;
using MilesCarRental.Application.Models.Cliente;
using System.Net;

namespace MilesCarRental.WebApi.Controllers
{
    /// <summary>
    /// Controlador para los carros
    /// </summary>
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CarroController : ControllerBase
    {
        /// <summary>
        /// Definicion de variables para el constructor
        /// </summary>
        IConfiguration _configuration;
        private readonly ILogger<CarroController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public CarroController(ILogger<CarroController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        /// <summary>
        /// Metodo de listar carros
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetCarro")]
        public async Task<ActionResult<IEnumerable<CarroVm>>> GetCarro(int? Id)
        {
            var query = await _mediator.Send(new ListCarroQuery(Id));
            return Ok(query);
        }
        /// <summary>
        /// Metodo de listar carros con los siguientes parametros
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="IdLocalidadRecogida"></param>
        /// <param name="IdLocalidadDevolucion"></param>
        /// <param name="idCliente"></param>
        /// <param name="idEstadoAlquiler"></param>
        /// <returns></returns>
        [HttpGet("GetAllCarro")]
        public async Task<ActionResult<IEnumerable<CarroAllVm>>> GetAllCarro(int? IdLocalidadRecogida, int? IdLocalidadDevolucion, int? idCliente, int? idEstadoAlquiler)
        {
            var query = await _mediator.Send(new ListCarroAllQuery(IdLocalidadRecogida, IdLocalidadDevolucion, idCliente, idEstadoAlquiler));
            return Ok(query);
        }
        /// <summary>
        /// Metodo registrar carros
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost("CreateCarro")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCarro([FromBody] CreateCarroCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        /// <summary>
        /// Metodo actualizar carros
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateCarro")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateCarro([FromBody] UpdateCarroCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
