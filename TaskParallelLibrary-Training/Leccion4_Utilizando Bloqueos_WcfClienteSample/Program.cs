using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leccion4_Utilizando_Bloqueos_WcfClienteSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                ServiceReference1.Service1Client proxy2 = new ServiceReference1.Service1Client();
                ServiceReference1.CompositeType resultado1 = null, resultado2 = null;

                Console.WriteLine("Iniciando consumo de WS");

                Parallel.Invoke(() => { resultado1 = proxy.GetSession(1); },
                    () => { resultado2 = proxy2.GetSession(1); });

                Console.WriteLine("Resultados de asignación de sesiones");

                Console.WriteLine($"Consulta 1: {resultado1?.IsActive}");
                Console.WriteLine($"Consulta 2: {resultado2?.IsActive}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ha fallado el consumo del WS: {e.Message}");
            }

            Console.WriteLine("Presione <enter> para continuar");
            Console.Read();
        }
    }
}
