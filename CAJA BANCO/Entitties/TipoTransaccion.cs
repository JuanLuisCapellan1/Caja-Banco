using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAJA_BANCO.Entitties
{
    public class TipoTransaccion
    {
        public int tipoTransaccionID {  get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public override string ToString()
        {
            return $"{nombre}";
        }
    }
}
