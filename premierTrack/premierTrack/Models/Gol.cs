using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class Gol
    {
        public int IdGol { get; set; }
        public int IdPartido { get; set; }
        public int IdJugador { get; set; }
        public int TipoGol { get; set; }
        public int? Minuto { get; set; } // Nullable porque puede ser null
    }
}
