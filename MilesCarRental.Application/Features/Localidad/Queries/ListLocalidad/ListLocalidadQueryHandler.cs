using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Carro.Queries.ListCarro;
using MilesCarRental.Application.Models.Carro;
using MilesCarRental.Application.Models.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Localidad.Queries.ListLocalidad
{
    public class ListLocalidadQueryHandler : IRequestHandler<ListLocalidadQuery, List<LocalidadVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListLocalidadQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListLocalidadQueryHandler(IUnitOfWork unitOfWork, ILogger<ListLocalidadQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<LocalidadVm>> Handle(ListLocalidadQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                var entity = await _unitOfWork.Repository<Domain.Localidad>().GetAsync(x => x.Id == request.Id);
                var entityVm = _mapper.Map<List<LocalidadVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Domain.Localidad>().GetAllAsync();
                var entityVm = _mapper.Map<List<LocalidadVm>>(entity);

                return entityVm;

            }
        }
    }
}
