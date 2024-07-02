using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAJA_BANCO
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public int ClienteId { get; set; }
        public decimal Balance { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string ClienteDocumentoIdentidad { get; set; }

        public override string ToString()
        {
            return $"No.Cuenta: {CuentaId}";
        }
    }
}
