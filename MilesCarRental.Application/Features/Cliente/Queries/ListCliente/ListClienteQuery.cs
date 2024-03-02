using MediatR;
using MilesCarRental.Application.Models.Cliente;
using MilesCarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Cliente.Queries.ListCliente
{
    public class ListClienteQuery : IRequest<List<ClienteVm>>
    {
        public ListClienteQuery(int? id)
        {
            Id = id;

        }
        public int? Id { get; set; }
    }
}
