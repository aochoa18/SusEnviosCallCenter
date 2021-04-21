using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class ServicioRequest
    {
        public int id { get; set; }
        public string direccionOrigen { get; set; }
        public string direccionDestino { get; set; }
        public string descripcionCarga { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public double valor { get; set; }
        public int estadoServicio { get; set; }
        public int idCliente { get; set; }
        public int idCiudadOrigen { get; set; }
        public int idCiudadDestino { get; set; }
        public int idTipoCamion { get; set; }
        public int idCamion { get; set; }
        public double latOrigen { get; set; }
        public double lonOrigen { get; set; }
        public double latDest { get; set; }
        public double lonDest { get; set; }
    }
}
