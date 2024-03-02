using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Models.Carro;
using MilesCarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Carro.Queries.ListCarro
{
    public class ListCarroQueryHandler : IRequestHandler<ListCarroQuery, List<CarroVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListCarroQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListCarroQueryHandler(IUnitOfWork unitOfWork, ILogger<ListCarroQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<CarroVm>> Handle(ListCarroQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                var entity = await _unitOfWork.Repository<Domain.Carro>().GetAsync(x => x.Id == request.Id);
                var entityVm = _mapper.Map<List<CarroVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Domain.Carro>().GetAllAsync();
                var entityVm = _mapper.Map<List<CarroVm>>(entity);

                return entityVm;

            }
        }
    }
}
