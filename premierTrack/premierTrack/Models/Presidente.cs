using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierTrack.Models
{
    public class Presidente
    {
        public int? IdPresidente { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Cedula { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; } // Nuevo atributo
    }
}
