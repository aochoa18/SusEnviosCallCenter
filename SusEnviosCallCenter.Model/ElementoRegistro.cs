
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class ElementoRegistroModel
    {
        
        public int id { get; set; }

        public int idRegistroServicio { get; set; }

        public int idTipoElemento { get; set; }

        public string elemento { get; set; }

        public bool estado { get; set; }

    }
}
