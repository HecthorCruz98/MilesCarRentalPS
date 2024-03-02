using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Cliente.Commands.UpdateCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.EstadoAlquiler.Commands.UpdateEstadoAlquiler
{
    public class UpdateEstadoAlquilerCommandHandler : IRequestHandler<UpdateEstadoAlquilerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEstadoAlquilerCommandHandler> _logger;

        public UpdateEstadoAlquilerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateEstadoAlquilerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateEstadoAlquilerCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.EstadoAlquiler>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.DescripcionEstadoAlquiler = request.DescripcionEstadoAlquiler;
                VerifiData.FechaUp = DateTime.Now;
                VerifiData.UsuarioUp = request.UsuarioUp;

                var EntityGetResponse = await _unitOfWork.Repository<Domain.EstadoAlquiler>().UpdateAsync(VerifiData);

                _logger.LogInformation($"El estado de alquiler con Id {VerifiData.Id} fue actualizado");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El estado del alquiler con Id {request.Id} no fue actualizado");

                return resp = false;
            }
        }
    }
}
