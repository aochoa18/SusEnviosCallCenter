
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class RegistroServicioModel
    {
        
        public int Id { get; set; }

        public int IdServicio { get; set; }

        public int IdEstadoServicio { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Observacion { get; set; }
    }
}
