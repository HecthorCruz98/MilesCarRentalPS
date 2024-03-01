using MilesCarRental.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain
{
    /// <summary>
    /// Clase encargada de la manipuylacion de los datos del carro en alquiler
    /// </summary>
    public class Carro : Entity
    {
        public int IdLocalidadRecogida { get; set; }
        [ForeignKey("IdLocalidadRecogida")]
        public Localidad LocalidadRecogida { get; set; }
        public int IdLocalidadDevolucion { get; set; }
        [ForeignKey("usrId")]
        public Localidad LocalidadDevolucion { get; set; }
        public string Cilindraje { get; set; }
        public string Chasis { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        public int IdEstadoAlquiler { get; set; }
        [ForeignKey("IdEstadoAlquiler")]
        public EstadoAlquiler EstadoAlquiler { get; set; }

    }
}
