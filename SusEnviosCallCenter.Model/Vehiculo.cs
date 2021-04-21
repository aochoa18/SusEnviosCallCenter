
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class VehiculoModel
    {
        
        public int Id { get; set; }

        public int IdTipoVehiculo { get; set; }

        public int IdTipoVinculacion { get; set; }

        public string Placa { get; set; }

        public string Descripcion { get; set; }

        public double Capacidad { get; set; }

        public bool Estado { get; set; }

        public int Propietario { get; set; }

        public int IdUsuario { get; set; }

    }
}
