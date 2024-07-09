using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAJA_BANCO.Entitties
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documentoidentidad { get; set; }
        public DateTime? FechaRegistro { get; set; }

    }
}
