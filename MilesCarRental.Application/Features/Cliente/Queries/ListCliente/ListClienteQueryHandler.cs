using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Carro.Queries.ListCarro;
using MilesCarRental.Application.Models.Carro;
using MilesCarRental.Application.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Cliente.Queries.ListCliente
{
    public class ListClienteQueryHandler : IRequestHandler<ListClienteQuery, List<ClienteVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListClienteQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListClienteQueryHandler(IUnitOfWork unitOfWork, ILogger<ListClienteQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<ClienteVm>> Handle(ListClienteQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                var entity = await _unitOfWork.Repository<Domain.Carro>().GetAsync(x => x.Id == request.Id);
                var entityVm = _mapper.Map<List<ClienteVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Domain.Carro>().GetAllAsync();
                var entityVm = _mapper.Map<List<ClienteVm>>(entity);

                return entityVm;

            }
        }
    }
}
