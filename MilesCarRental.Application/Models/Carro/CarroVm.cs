using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Models.Carro
{
    public class CarroVm
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
        public string UsuarioUp { get; set; }
        public DateTime FechaUp { get; set; }
    }
}
