using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class Presidente
    {
        public int IdPresidente { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; } // Nullable porque puede ser null
        public DateTime? FechaFin { get; set; }    // Nullable porque puede ser null
        public int IdEquipo { get; set; }
    }
}
