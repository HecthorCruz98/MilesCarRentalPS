using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Carro.Commands.CreateCarro
{
    /// <summary>
    /// Clase encargada de manejar los eventos de creacion de registros en la tabla carro
    /// </summary>
    public class CreateCarroCommandHandler : IRequestHandler<CreateCarroCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCarroCommandHandler> _logger;
        /// <summary>
        /// Definicion de datos del constructor 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CreateCarroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCarroCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Metodo de valñidacion e insercion de datos en la tabla carro
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(CreateCarroCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<MilesCarRental.Domain.Carro>().GetFirstOrDefaultAsync(x => x.Chasis == request.Chasis);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Domain.Carro>(request);
                var EntityAdd = await _unitOfWork.Repository<Domain.Carro>().AddAsync(Entity);
                var Response = _mapper.Map<Domain.Carro>(EntityAdd);

                _logger.LogInformation($"La factura fue creada con el id {EntityAdd.Id}");


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
