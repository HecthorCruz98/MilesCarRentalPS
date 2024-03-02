using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Cliente.Queries.ListCliente;
using MilesCarRental.Application.Features.TipoDocumento.Queries.ListTipoDocuemnto;
using MilesCarRental.Application.Models.Cliente;
using MilesCarRental.Application.Models.TipoDocumento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.TipoDocumento.Queries.ListTipoDocumento
{
    public class ListTipoDocumentoQueryHandler : IRequestHandler<ListTipoDocumentoQuery, List<TipoDocumentoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListTipoDocumentoQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListTipoDocumentoQueryHandler(IUnitOfWork unitOfWork, ILogger<ListTipoDocumentoQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<TipoDocumentoVm>> Handle(ListTipoDocumentoQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                var entity = await _unitOfWork.Repository<Domain.TipoDocumento>().GetAsync(x => x.Id == request.Id);
                var entityVm = _mapper.Map<List<TipoDocumentoVm>>(entity);

                return entityVm;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Domain.TipoDocumento>().GetAllAsync();
                var entityVm = _mapper.Map<List<TipoDocumentoVm>>(entity);

                return entityVm;

            }
        }
    }
}
