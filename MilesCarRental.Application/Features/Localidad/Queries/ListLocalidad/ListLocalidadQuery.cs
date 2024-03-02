using MediatR;
using MilesCarRental.Application.Models.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Localidad.Queries.ListLocalidad
{
    public class ListLocalidadQuery : IRequest<List<LocalidadVm>>
    {
        public ListLocalidadQuery(int? id)
        {
            id = Id;

        }
        public int? Id { get; set; }
    }
}
