using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MilesCarRental.Application.Contracts;
using MilesCarRental.Application.Features.Carro.Queries.ListCarro;
using MilesCarRental.Application.Models.Carro;
using MilesCarRental.Application.Models.Localidad;
using MilesCarRental.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Carro.Queries.ListCarroAllVm
{
    public class ListCarroAllQueryHandler : IRequestHandler<ListCarroAllQuery, List<CarroAllVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListCarroAllQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListCarroAllQueryHandler(IUnitOfWork unitOfWork, ILogger<ListCarroAllQueryHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<CarroAllVm>> Handle(ListCarroAllQuery request, CancellationToken cancellationToken)
        {
            List<CarroAllVm> lista = new List<CarroAllVm>();

            if (request.IdLocalidadRecogida != null || request.IdLocalidadDevolucion != null || request.IdCliente != null || request.IdEstadoAlquiler != null)
            {
                var entity = await _unitOfWork.Repository<Domain.Carro>().GetAsync(x => x.IdLocalidadRecogida == request.IdLocalidadRecogida || x.IdLocalidadDevolucion == request.IdLocalidadDevolucion
                || x.IdCliente == request.IdCliente || x.IdEstadoAlquiler == request.IdEstadoAlquiler);

                foreach (var data in entity)
                {
                    var localidadRecogida = await _unitOfWork.Repository<Domain.Localidad>().GetAsync(x => x.Id == data.IdLocalidadRecogida);
                    var localidadDevolucion = await _unitOfWork.Repository<Domain.Localidad>().GetAsync(x => x.Id == data.IdLocalidadDevolucion);
                    var cliente = await _unitOfWork.Repository<Domain.Cliente>().GetAsync(x => x.Id == data.IdCliente);
                    var estadoAlquiler = await _unitOfWork.Repository<Domain.EstadoAlquiler>().GetAsync(x => x.Id == data.IdEstadoAlquiler);

                    lista.Add(new CarroAllVm
                    {
                        Id = data.Id,
                        LocalidadRecogida = localidadRecogida.FirstOrDefault().DescripcionLocalidad,
                        LocalidadDevolucion = localidadDevolucion.FirstOrDefault().DescripcionLocalidad,
                        EstadoAlquiler = estadoAlquiler.FirstOrDefault().DescripcionEstadoAlquiler,
                        Cliente = cliente.FirstOrDefault().NombreCliente + " " + cliente.FirstOrDefault().ApellidoCliente,
                        Chasis = data.Chasis,
                        Cilindraje = data.Cilindraje,
                    });

                }

                return lista;

            }
            else
            {
                var entity = await _unitOfWork.Repository<Domain.Carro>().GetAllAsync();

                foreach (var data in entity)
                {
                    var localidadRecogida = await _unitOfWork.Repository<Domain.Localidad>().GetAsync(x => x.Id == data.IdLocalidadRecogida);
                    var localidadDevolucion = await _unitOfWork.Repository<Domain.Localidad>().GetAsync(x => x.Id == data.IdLocalidadDevolucion);
                    var cliente = await _unitOfWork.Repository<Domain.Cliente>().GetAsync(x => x.Id == data.IdCliente);
                    var estadoAlquiler = await _unitOfWork.Repository<Domain.EstadoAlquiler>().GetAsync(x => x.Id == data.IdEstadoAlquiler);

                    lista.Add(new CarroAllVm 
                    {
                        Id = data.Id,
                        LocalidadRecogida = localidadRecogida.FirstOrDefault().DescripcionLocalidad,
                        LocalidadDevolucion = localidadDevolucion.FirstOrDefault().DescripcionLocalidad,
                        EstadoAlquiler = estadoAlquiler.FirstOrDefault().DescripcionEstadoAlquiler,
                        Cliente = cliente.FirstOrDefault().NombreCliente + " " + cliente.FirstOrDefault().ApellidoCliente,
                        Chasis = data.Chasis,
                        Cilindraje = data.Cilindraje,
                    });
                }

                return lista;

            }
        }
    }
}
