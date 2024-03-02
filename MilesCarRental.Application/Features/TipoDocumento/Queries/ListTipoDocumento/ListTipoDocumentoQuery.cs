using MediatR;
using MilesCarRental.Application.Models.TipoDocumento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.TipoDocumento.Queries.ListTipoDocuemnto
{
    public class ListTipoDocumentoQuery : IRequest<List<TipoDocumentoVm>>
    {
        public ListTipoDocumentoQuery(int? id)
        {
            id = Id;

        }
        public int? Id { get; set; }
    }
}
