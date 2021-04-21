
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class PersonaModel
    {

        public int Id { get; set; }

        public int IdTipoDocumento { get { return this.idTipoDocumento.Id; } }

        public string NumeroDocumento { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Celular { get; set; }

        public string Foto { get; set; }

        public bool Estado { get; set; }

        public string Email { get; set; }

        public TipoDocumentoModel idTipoDocumento { get; set; }

        public UsuarioModel idUsuario { get; set; }
    }
}
