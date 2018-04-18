using Microsoft.Azure.CosmosDB.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft_Azure_Table_Storage.Modelo
{
    class EquipoIngles: TableEntity
    {
        public string Liga
        {
            get
            {
                return PartitionKey;
            }
            set
            {
                PartitionKey = value;
            }
        }
        public string Nombre
        {
            get
            {
                return RowKey;
            }
            set
            {
                RowKey = value;
            }
        }

        public int Copas { get; set; }
    }
}
