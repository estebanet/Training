using Microsoft.Azure.CosmosDB.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Azure_Table_Storage.Modelo
{
    class Equipo: TableEntity
    {
        public Equipo(string Nombre, string Liga)
            : base(Liga, Nombre) { }
        public Equipo() { }

        public int IdEquipo { get; set; }
        public int NoCampeonatos { get; set; }
        public string Apodo { get; set; }
        public DateTime Fundacion { get; set; }
    }
}
