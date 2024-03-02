using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Carro.Commands.CreateCarro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Cliente.Commands.CreateCliente
{
    /// <summary>
    /// Clase encargada de manejar los eventos de creacion de registros en la tabla cliente
    /// </summary>
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateClienteCommandHandler> _logger;
        /// <summary>
        /// Definicion de datos del constructor 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CreateClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Metodo de validacion e insercion de datos en la tabla cliente
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.Cliente>().GetFirstOrDefaultAsync(x => x.NombreCliente == request.NombreCliente);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Domain.Cliente>(request);
                var EntityAdd = await _unitOfWork.Repository<Domain.Cliente>().AddAsync(Entity);
                var Response = _mapper.Map<Domain.Cliente>(EntityAdd);

                _logger.LogInformation($"El cliente fue creado con el id {EntityAdd.Id}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El carro no fue creado");

                return resp = false;
            }
        }
    }
}
