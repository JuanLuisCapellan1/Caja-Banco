using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAJA_BANCO.Entitties
{
    public class Beneficiario
    {
        public int beneficiarioID {  get; set; }
        public string nombre { get; set; }
        public int cuentaID { get; set; }
        public int usuarioID { get; set; }

        public override string ToString()
        {
            return $"{nombre}";
        }
    }
}
