using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public int IdDivision { get; set; }
        public string Ciudad { get; set; }
        public string Estadio { get; set; }
        public int Presidente { get; set; }
    }
}
