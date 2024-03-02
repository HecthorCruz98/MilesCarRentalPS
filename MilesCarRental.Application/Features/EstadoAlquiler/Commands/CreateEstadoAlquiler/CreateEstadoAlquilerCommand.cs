using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.EstadoAlquiler.Commands.CreateEstadoAlquiler
{
    public class CreateEstadoAlquilerCommand : IRequest<bool>
    {
        public string DescripcionEstadoAlquiler { get; set; }
        public string UsuarioAdd { get; set; }
        public DateTime FechaAdd { get; set; }
    }
}
