
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class ClienteModel
    {
        
        public int Id { get; set; }

        public int IdTipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Direccion { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int IdCiudad { get; set; }

        public string PlayerId { get; set; }

        public string PushToken { get; set; }

        public bool Estado { get; set; }

        public TipoDocumentoModel idTipoDocumento { get; set; }

        public MunicipioModel idCiudad { get; set; }

    }
}
