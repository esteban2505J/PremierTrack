using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class Jornada
    {
        public int IdJornada { get; set; }
        public int NumeroJornada { get; set; }
        public int IdTemporada { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Estado { get; set; }
    }
}
