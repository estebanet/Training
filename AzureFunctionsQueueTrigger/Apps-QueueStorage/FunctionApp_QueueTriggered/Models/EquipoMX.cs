using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp_QueueTriggered.Models
{
    public class EquipoMX: GaroData.Entities.Equipo
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
    }
}
