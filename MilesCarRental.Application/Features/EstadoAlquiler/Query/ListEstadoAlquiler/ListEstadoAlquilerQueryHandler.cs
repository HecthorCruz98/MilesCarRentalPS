using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Cliente.Queries.ListCliente;
using MilesCarRental.Application.Models.Cliente;
using MilesCarRental.Application.Models.EstadoAlquiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.EstadoAlquiler.Query.ListEstadoAlquiler
{
    public class ListEstadoAlquilerQueryHandler : IRequestHandler<ListEstadoAlquilerQuery, List<EstadoAlquilerVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListEstadoAlquilerQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListEstadoAlquilerQueryHandler(IUnitOfWork unitOfWork, ILogger<ListEstadoAlquilerQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<EstadoAlquilerVm>> Handle(ListEstadoAlquilerQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                var entity = await _unitOfWork.Repository<Domain.EstadoAlquiler>().GetAsync(x => x.Id == request.Id);
                var entityVm = _mapper.Map<List<EstadoAlquilerVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Domain.EstadoAlquiler>().GetAllAsync();
                var entityVm = _mapper.Map<List<EstadoAlquilerVm>>(entity);

                return entityVm;

            }
        }
    }
}
