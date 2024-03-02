using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Application.Models.TipoDocumento
{
    public class TipoDocumentoVm
    {
        public int Id { get; set; }
        public string DescripcionTipoDocumento { get; set; }
        public string UsuarioAdd { get; set; }
        public DateTime FechaAdd { get; set; }
        public string UsuarioUp { get; set; }
        public DateTime FechaUp { get; set; }
    }
}
