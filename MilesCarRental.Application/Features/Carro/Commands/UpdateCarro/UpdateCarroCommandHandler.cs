using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Carro.Commands.UpdateCarro
{
    public class UpdateCarroCommandHandler : IRequestHandler<UpdateCarroCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCarroCommandHandler> _logger;

        public UpdateCarroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCarroCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateCarroCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.Carro>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.IdEstadoAlquiler = request.IdEstadoAlquiler;
                VerifiData.IdLocalidadRecogida = request.IdLocalidadRecogida;
                VerifiData.IdLocalidadDevolucion = request.IdLocalidadDevolucion;
                VerifiData.IdCliente = request.IdCliente;
                VerifiData.Chasis = request.Chasis;
                VerifiData.Cilindraje = request.Cilindraje;
                VerifiData.FechaUp = DateTime.Now;
                VerifiData.UsuarioUp = request.UsuarioUp;

                var EntityGetResponse = await _unitOfWork.Repository<Domain.Carro>().UpdateAsync(VerifiData);

                _logger.LogInformation($"El carro con Id {VerifiData.Id} fue actualizado");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El carro con Id {request.Id} no fue actualizado");

                return resp = false;
            }
        }
    }
}
