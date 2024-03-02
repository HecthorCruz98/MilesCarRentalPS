using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Cliente.Commands.CreateCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Localidad.Commands.CreateLocalidad
{
    public class CreateLocalidadCommandHandler : IRequestHandler<CreateLocalidadCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLocalidadCommandHandler> _logger;
        /// <summary>
        /// Definicion de datos del constructor 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CreateLocalidadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateLocalidadCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateLocalidadCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.Localidad>().GetFirstOrDefaultAsync(x => x.DescripcionLocalidad == request.DescripcionLocalidad);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Domain.Localidad>(request);
                var EntityAdd = await _unitOfWork.Repository<Domain.Localidad>().AddAsync(Entity);
                var Response = _mapper.Map<Domain.Localidad>(EntityAdd);

                _logger.LogInformation($"La localidad fue creada con el id {EntityAdd.Id}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"el registro no fue creado");

                return resp = false;
            }
        }
    }
}
