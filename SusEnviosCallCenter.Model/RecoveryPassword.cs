
using System;

namespace SusEnviosCallCenter.Model
{
    public class RecoveryPasswordModel
    {

        public int ID { get; set; }

        public int? IdUsuario { get; set; }

        public string Token { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public bool? Estado { get; set; }

    }
}
