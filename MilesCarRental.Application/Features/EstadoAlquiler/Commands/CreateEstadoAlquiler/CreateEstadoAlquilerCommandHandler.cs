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

namespace MilesCarRental.Application.Features.EstadoAlquiler.Commands.CreateEstadoAlquiler
{
    public class CreateEstadoAlquilerCommandHandler : IRequestHandler<CreateEstadoAlquilerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEstadoAlquilerCommandHandler> _logger;
        /// <summary>
        /// Definicion de datos del constructor 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CreateEstadoAlquilerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateEstadoAlquilerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateEstadoAlquilerCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.EstadoAlquiler>().GetFirstOrDefaultAsync(x => x.DescripcionEstadoAlquiler == request.DescripcionEstadoAlquiler);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Domain.EstadoAlquiler>(request);
                var EntityAdd = await _unitOfWork.Repository<Domain.EstadoAlquiler>().AddAsync(Entity);
                var Response = _mapper.Map<Domain.EstadoAlquiler>(EntityAdd);

                _logger.LogInformation($"El registro fue creado con el id {EntityAdd.Id}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El registro del estado del alquiler no fue creado");

                return resp = false;
            }
        }
    }
}
