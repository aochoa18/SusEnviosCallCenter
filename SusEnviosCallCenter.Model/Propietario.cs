
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class PropietarioModel
    {
        
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int IdTipoDocumento { get; set; }

        public string NumeroDocumeto { get; set; }

        public string NombreContacto { get; set; }

        public string TelefonoContacto { get; set; }

        public string DireccionContacto { get; set; }

        public int IdCiudad { get; set; }

        public bool Estado { get; set; }

    }
}
