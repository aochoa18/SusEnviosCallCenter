
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusEnviosCallCenter.Model
{
    public class PagoModel
    {
        
        public int id { get; set; }

        public int idServicio { get; set; }

        public Guid? TransactionId { get; set; }

        public decimal Valor { get; set; }

        public string EstadoTransaccion { get; set; }

        public int? IdMedioPago { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaRespuesta { get; set; }

    }
}
