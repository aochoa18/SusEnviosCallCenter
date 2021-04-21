
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class ServicioModel
    {

        public int Id { get; set; }

        public int IdCliente { get; set; }

        public int? IdTipoCamion { get; set; }

        public int IdCiudadOrigen { get; set; }

        public int IdCiudadDestino { get; set; }

        public string DireccionOrigen { get; set; }

        public string DireccionDestino { get; set; }

        public string DescripcionCarga { get; set; }

        public int EstadoServicio { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public double Valor { get; set; }

        public double? latOrigen { get; set; }

        public double? lonOrigen { get; set; }

        public double? latDest { get; set; }

        public double? lonDest { get; set; }

        public int? IdUsuario { get; set; }

        public int IdTipoServicio { get; set; }

        public ClienteModel idCliente { get; set; }

        public TipoVehiculoModel idTipoCamion { get; set; }
        public MunicipioModel idCiudadOrigen { get; set; }
        public MunicipioModel idCiudadDestino { get; set; }
        public UsuarioModel idUsuario { get; set; }
        public TipoServicioModel idTipoServicio { get; set; }

        public EstadoServicioModel estadoServicio { get; set; }

        public List<RegistroServicioModel> registroServicios { get; set; }
    }
}
