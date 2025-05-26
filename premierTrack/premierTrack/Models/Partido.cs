using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class Partido
    {
        public int IdPartido { get; set; }
        public int IdEquipoLocal { get; set; }
        public int IdEquipoVisitante { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public int IdJornada { get; set; }
        public string Estadio { get; set; }
    }
}
