using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Localidad.Commands.CreateLocalidad
{
    public class CreateLocalidadCommand : IRequest<bool>
    {
        public string DescripcionLocalidad { get; set; }
        public string UsuarioAdd { get; set; }
        public DateTime FechaAdd { get; set; }
    }
}
