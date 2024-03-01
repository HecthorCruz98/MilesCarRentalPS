using MilesCarRental.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesCarRental.Domain
{
    public class Cliente : Entity
    {
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public int IdTipoDocumentoCliente { get; set; }
        [ForeignKey("IdTipoDocumentoCliente")]
        public TipoDocumento TipoDocumento { get; set; }

    }
}
