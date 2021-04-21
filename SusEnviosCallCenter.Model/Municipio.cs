
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class MunicipioModel
    {
        
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int IdDepartamento { get; set; }

        public string CodigoDane { get; set; }

        public int? Regional { get; set; }

        public bool Estado { get; set; }

    }
}
