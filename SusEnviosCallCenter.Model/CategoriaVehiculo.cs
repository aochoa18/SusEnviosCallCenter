
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class CategoriaVehiculoModel
    {
        
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public string Imagen { get; set; }

        public List<TipoVehiculoModel> tipoVehiculos { get; set; }
    }
}
