using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Carro.Commands.UpdateCarro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.TipoDocumento.Commands.UpdateTipoDocumento
{
    public class UpdateTipoDocumentoCommandHandler : IRequestHandler<UpdateTipoDocumentoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTipoDocumentoCommandHandler> _logger;

        public UpdateTipoDocumentoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateTipoDocumentoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.TipoDocumento>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.Id = request.Id;
                VerifiData.DescripcionTipoDocumento = request.DescripcionTipoDocumento;
                VerifiData.FechaUp = DateTime.Now;
                VerifiData.UsuarioUp = request.UsuarioUp;

                var EntityGetResponse = await _unitOfWork.Repository<Domain.TipoDocumento>().UpdateAsync(VerifiData);

                _logger.LogInformation($"El tipo de documento con Id {VerifiData.Id} fue actualizado");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El tipo de documento con Id {request.Id} no fue actualizado");

                return resp = false;
            }
        }
    }
}
