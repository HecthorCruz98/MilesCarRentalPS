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

namespace MilesCarRental.Application.Features.Localidad.Commands.UpdateLocalidad
{
    public class UpdateLocalidadCommandHandler : IRequestHandler<UpdateLocalidadCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateLocalidadCommandHandler> _logger;

        public UpdateLocalidadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateLocalidadCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateLocalidadCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.Localidad>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.DescripcionLocalidad = request.DescripcionLocalidad;
                VerifiData.FechaUp = DateTime.Now;
                VerifiData.UsuarioUp = request.UsuarioUp;

                var EntityGetResponse = await _unitOfWork.Repository<Domain.Localidad>().UpdateAsync(VerifiData);

                _logger.LogInformation($"La localidad con Id {VerifiData.Id} fue actualizada");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"La localidad con Id {request.Id} no fue actualizada");

                return resp = false;
            }
        }
    }
}
