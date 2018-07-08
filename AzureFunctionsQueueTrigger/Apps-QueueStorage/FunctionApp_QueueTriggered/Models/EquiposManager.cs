using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp_QueueTriggered.Models
{
    public class EquiposManager: IDisposable
    {
        private GaroData.EquiposModeloEF dbContext;
        private bool isDispose;

        public EquiposManager()
        {
            dbContext = new GaroData.EquiposModeloEF();
        }

        public EquiposManager(string connectionString)
        {
            dbContext = new GaroData.EquiposModeloEF(connectionString);
        }

        public void Dispose()
        {
            if (!isDispose)
            {
                dbContext.Dispose();
                isDispose = true;
            }
        }

        public void RegistrarEquipo(GaroData.Entities.Equipo equipo)
        {
            dbContext.Equipos.Add(equipo);
            dbContext.SaveChanges();
        }
    }
}
