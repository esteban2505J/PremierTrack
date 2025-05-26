using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class EstadisticasJugador
    {
        public int IdEstadistica { get; set; }
        public int IdJugador { get; set; }
        public int IdPartido { get; set; }
        public int IdTemporada { get; set; }
        public int? CantidadGoles { get; set; }
        public int? Asistencias { get; set; }
        public int? TirosAPuerta { get; set; }
        public int? PasesCompletados { get; set; }
        public int? TarjetasAmarillas { get; set; }
        public int? TarjetasRojas { get; set; }
    }
}
