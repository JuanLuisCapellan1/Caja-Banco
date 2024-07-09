using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAJA_BANCO.Entitties
{
    public class Usuarios
    {
        public int usuarioId {  get; set; }
        public string nombreUsuario { get; set; }
        public string contraseña { get; set; }
        public int perfilId { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime ultimoacceso { get; set; }
        public int clienteId { get; set; }

        public override string ToString()
        {
            return $"{nombreUsuario}";
        }
    }
}
