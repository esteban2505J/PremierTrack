using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class TablaPosicion
    {
        public int IdTablaPosiciones { get; set; }
        public int IdTemporada { get; set; }
        public int IdEquipo { get; set; }
        public int PartidosJugados { get; set; }
        public int Ganados { get; set; }
        public int Empatados { get; set; }
        public int Perdidos { get; set; }
        public int GolesFavor { get; set; }
        public int GolesContra { get; set; }
        public int DiferenciaGoles { get; set; }
        public int Puntos { get; set; }
        public int Posicion { get; set; }
    }
}
