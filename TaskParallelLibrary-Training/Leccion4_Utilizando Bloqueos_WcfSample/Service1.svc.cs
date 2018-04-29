using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace Leccion4_Utilizando_Bloqueos_WcfSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static object objLock = new object();
        public CompositeType GetSession(int UserId)
        {
            CompositeType Resultado;
            try
            {
                using (Model1Container dbContext = new Model1Container())
                {
                    lock (objLock)
                    {
                        if (!dbContext.Sesions.Where(sesion => sesion.UsuarioId == UserId && sesion.IsActive).Any())
                        {
                            Thread.Sleep(3000);
                            DateTime fechaAhora = DateTime.Now;
                            dbContext.Sesions.Add(new Sesion
                            {
                                Date = fechaAhora,
                                IsActive = true,
                                UsuarioId = UserId
                            });
                            dbContext.SaveChanges();
                            Resultado = new CompositeType { IsActive = true, SessionDate = fechaAhora };
                        }
                        else
                        {
                            Resultado = new CompositeType { IsActive = false, SessionDate = DateTime.MinValue };
                        }
                    }
                }
            }
            catch (Exception)
            {
                Resultado = null;
            }

            return Resultado;
        }
    }
}
