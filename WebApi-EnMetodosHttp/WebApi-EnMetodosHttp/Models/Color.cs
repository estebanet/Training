using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_EnMetodosHttp.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Intensidad { get; set; }
        public int Tipo { get; set; }
        public bool EsBrilosso { get; set; }
        public string CodigoEx { get; set; }
    }
}