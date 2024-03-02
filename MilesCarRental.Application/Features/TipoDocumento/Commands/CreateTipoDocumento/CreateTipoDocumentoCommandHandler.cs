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

namespace MilesCarRental.Application.Features.TipoDocumento.Commands.CreateTipoDocumento
{
    public class CreateTipoDocumentoCommandHandler : IRequestHandler<CreateTipoDocumentoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTipoDocumentoCommandHandler> _logger;
        /// <summary>
        /// Definicion de datos del constructor 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CreateTipoDocumentoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateTipoDocumentoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(CreateTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.TipoDocumento>().GetFirstOrDefaultAsync(x => x.DescripcionTipoDocumento == request.DescripcionTipoDocumento);

            bool resp = false;
            if (VerifiData == null)
            {
                var Entity = _mapper.Map<Domain.TipoDocumento>(request);
                var EntityAdd = await _unitOfWork.Repository<Domain.TipoDocumento>().AddAsync(Entity);
                var Response = _mapper.Map<Domain.TipoDocumento>(EntityAdd);

                _logger.LogInformation($"El registro fue creado con el id {EntityAdd.Id}");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El registro del tipo de documento no fue creado");

                return resp = false;
            }
        }
    }
}
