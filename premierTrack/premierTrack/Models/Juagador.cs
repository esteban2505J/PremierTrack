using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class Juagador
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public int Posicion { get; set; }
        public int NumeroCamiseta { get; set; }
        public int IdEquipo { get; set; }
        public int FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
    }
}
