using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaroData.Entities
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public DateTime Fundacion { get; set; }
        public int Titulos { get; set; }
        public string Presidente { get; set; }
    }
}
