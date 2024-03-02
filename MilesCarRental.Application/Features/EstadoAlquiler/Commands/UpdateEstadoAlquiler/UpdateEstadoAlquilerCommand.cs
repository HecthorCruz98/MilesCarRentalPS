using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.EstadoAlquiler.Commands.UpdateEstadoAlquiler
{
    public class UpdateEstadoAlquilerCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string DescripcionEstadoAlquiler { get; set; }
        public string UsuarioUp { get; set; }
        public DateTime FechaUp { get; set; }
    }
}
