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

namespace MilesCarRental.Application.Features.Cliente.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClienteCommandHandler> _logger;

        public UpdateClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var VerifiData = await _unitOfWork.Repository<Domain.Cliente>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            bool resp = false;
            if (VerifiData != null)
            {
                VerifiData.NombreCliente = request.NombreCliente;
                VerifiData.ApellidoCliente = request.ApellidoCliente;
                VerifiData.DocumentoCliente = request.DocumentoCliente;
                VerifiData.IdTipoDocumentoCliente = request.IdTipoDocumentoCliente;
                VerifiData.FechaUp = DateTime.Now;
                VerifiData.UsuarioUp = request.UsuarioUp;

                var EntityGetResponse = await _unitOfWork.Repository<Domain.Cliente>().UpdateAsync(VerifiData);

                _logger.LogInformation($"El cliente con Id {VerifiData.Id} fue actualizado");


                return resp = true;

            }
            else
            {
                _logger.LogInformation($"El cliente con Id {request.Id} no fue actualizado");

                return resp = false;
            }
        }
    }
}
