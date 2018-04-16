using Microsoft.Azure.CosmosDB.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Azure_Table_Storage_Emulator.Entidades
{
    class ClientePersonalizado : TableEntity
    {
        public ClientePersonalizado(string Nombre, string Puesto)
            : base(Puesto, Nombre) { }
        public ClientePersonalizado() { }

        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
    }
}
