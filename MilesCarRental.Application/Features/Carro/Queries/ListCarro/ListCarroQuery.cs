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
        public ListCarroQuery(int? id)
        {
            Id = id;

        }
        public int? Id { get; set; }
    }
}
