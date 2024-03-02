using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Models.Carro
{
    public class CarroAllVm
    {
        public int Id { get; set; }
        public string LocalidadRecogida { get; set; }
        public string LocalidadDevolucion { get; set; }
        public string Cilindraje { get; set; }
        public string Chasis { get; set; }
        public string Cliente { get; set; }
        public string EstadoAlquiler { get; set; }
        public string UsuarioAdd { get; set; }
        public DateTime FechaAdd { get; set; }
        public string UsuarioUp { get; set; }
        public DateTime FechaUp { get; set; }
    }
}
