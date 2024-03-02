using MediatR;
using MilesCarRental.Application.Models.Carro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Carro.Queries.ListCarroAllVm
{
    public class ListCarroAllQuery : IRequest<List<CarroAllVm>>
    {
        public ListCarroAllQuery(int? idLocalidadRecogida, int? idLocalidadDevolucion, int? idCliente, int? idEstadoAlquiler)
        {
            IdLocalidadRecogida = idLocalidadRecogida;
            IdLocalidadDevolucion = idLocalidadDevolucion;
            IdCliente = idCliente;
            IdEstadoAlquiler = idEstadoAlquiler;

        }
        public int? IdLocalidadRecogida { get; set; }
        public int? IdLocalidadDevolucion { get; set; }
        public int? IdCliente { get; set; }
        public int? IdEstadoAlquiler { get; set; }
    }
}
