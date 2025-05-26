using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class Tarjeta
    {
        public int IdTarjeta { get; set; }
        public int IdPartido { get; set; }
        public int IdJugador { get; set; }
        public int? Minuto { get; set; } // Nullable porque puede ser null
        public int IdTipoTarjeta { get; set; }
    }
}
