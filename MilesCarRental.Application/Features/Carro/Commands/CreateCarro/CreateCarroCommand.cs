using MediatR;
using MilesCarRental.Domain;
using MilesCarRental.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Carro.Commands.CreateCarro
{
    public class CreateCarroCommand : IRequest<bool>
    {
        public int IdLocalidadRecogida { get; set; }
        public int IdLocalidadDevolucion { get; set; }
        public string Cilindraje { get; set; }
        public string Chasis { get; set; }
        public int IdCliente { get; set; }
        public int IdEstadoAlquiler { get; set; }
        public string UsuarioAdd { get; set; }
        public DateTime FechaAdd { get; set; }
    }
}
