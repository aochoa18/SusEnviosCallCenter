
using System;

namespace SusEnviosCallCenter.Model
{
    public class RegistroServicioRequest
    {

        public int id { get; set; }

        public int idServicio { get; set; }

        public int idEstadoServicio { get; set; }

        public DateTime fechaRegistro { get; set; }

        public string observacion { get; set; }

    }
}
