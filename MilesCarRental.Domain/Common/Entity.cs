using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain.Common
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string UsuarioAdd { get; set; }
        public string UsuarioUp { get; set; }
        public DateTime FechaAdd { get; set; }
        public DateTime FechaUp { get; set; }

    }
}
