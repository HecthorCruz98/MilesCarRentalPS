using MediatR;
using MilesCarRental.Application.Models.Carro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Carro.Queries.ListCarro
{
    public class ListCarroQuery : IRequest<List<CarroVm>>
    {
        public ListCarroQuery(int? id, int? idLocalidadRecogida, int? idLocalidadDevolucion, int? idCliente, int? idEstadoAlquiler)
        {
            id = Id;
            idLocalidadRecogida = IdLocalidadRecogida;
            idLocalidadDevolucion = IdLocalidadDevolucion;
            idCliente = IdCliente;
            idEstadoAlquiler = IdEstadoAlquiler;

        }
        public int? Id { get; set; }
        public int? IdLocalidadRecogida { get; set; }
        public int? IdLocalidadDevolucion { get; set; }
        public int? IdCliente { get; set; }
        public int? IdEstadoAlquiler { get; set; }
    }
}
