
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class UsuarioPosModel
    {
        
        public int IdUsuario { get; set; }

        public decimal lat { get; set; }

        public decimal lon { get; set; }

        public bool activo { get; set; }

        public bool enEntrega { get; set; }

    }
}
