using MediatR;
using MilesCarRental.Application.Models.EstadoAlquiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.EstadoAlquiler.Query.ListEstadoAlquiler
{
    public class ListEstadoAlquilerQuery : IRequest<List<EstadoAlquilerVm>>
    {
        public ListEstadoAlquilerQuery(int? id)
        {
            id = Id;

        }
        public int? Id { get; set; }
    }
}
