using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Features.Carro.Commands.UpdateCarro
{
    /// <summary>
    /// Paremtros de entrada para la actualizacion de los registros de la tabla carro
    /// </summary>
    public class UpdateCarroCommand : IRequest<bool>
    {
        public int Id { get; set; }
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
