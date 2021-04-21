
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class UsuarioModel
    {

        public int ID { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public bool Activo { get; set; }

        public int? IdPersona { get; set; }

        public string XueUserCode { get; set; }

        public int? IdPerfil { get; set; }

        public PersonaModel idPersona { get; set; }

        public PerfilModel idPerfil { get; set; }
    }
}
