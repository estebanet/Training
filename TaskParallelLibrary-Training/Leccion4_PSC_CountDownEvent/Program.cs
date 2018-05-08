using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leccion4_PSC_CountDownEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            UseCountDownEvent();
            Console.WriteLine("Presione <enter> para continuar");
            Console.Read();
        }

        static void UseCountDownEvent()
        {
            CountdownEvent CDE = new CountdownEvent(10);
            ConcurrentQueue<int> ConcurrentQ = new ConcurrentQueue<int>(Enumerable.Range(1, 10));

            Action ProcessOrder = delegate ()
            {
                int ProcessOrders = 0;
                int Order;

                while (ConcurrentQ.TryDequeue(out Order))
                {
                    Console.WriteLine($"Hilo {Thread.CurrentThread.ManagedThreadId}, Procesando pedido: {Order}");
                    Thread.Sleep(1000);
                    ProcessOrders++;
                    CDE.Signal();
                    Console.WriteLine($"Pedido {Order} procesado, Hilo {Thread.CurrentThread.ManagedThreadId}!");
                }

                Console.WriteLine($"Hilo {Thread.CurrentThread.ManagedThreadId}, pedidos procesados {ProcessOrders}");
            };

            Task.Run(ProcessOrder);
            Task.Run(ProcessOrder);
            Task.Run(ProcessOrder);

            Console.WriteLine($"CurrentCount antes de esperar... {CDE.CurrentCount}");
            CDE.Wait();
            Console.WriteLine($"Se han procesado los pedidos");
            CDE.Dispose();
        }
    }
}
