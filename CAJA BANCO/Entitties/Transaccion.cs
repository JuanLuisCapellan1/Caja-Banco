using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAJA_BANCO.Entitties
{
    public class Transaccion
    {
        public int transaccionID { get; set; }
        public int beneficiarioID { get; set; }
        public int cuentaID { get; set; }
        public int tipoTransaccionID { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
    }
}
