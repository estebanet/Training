using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leccion4_PSC_ReaderWriterLockSlim
{
    class Program
    {
        static private int InvoiceNumber { get; set; }

        static void Main(string[] args)
        {
            UseReaderWriterLockSlim();

            Console.WriteLine("Presione <enter> para finalizar...");
            Console.Read();
        }

        static void UseReaderWriterLockSlim()
        {
            CountdownEvent CDE = new CountdownEvent(10);
            ConcurrentQueue<int> ConcurrentQ = new ConcurrentQueue<int>(Enumerable.Range(1, 10));
            ReaderWriterLockSlim RWLS = new ReaderWriterLockSlim();
            InvoiceNumber = 0;

            Action ProcessOrder = delegate ()
            {
                int ProcessOrders = 0;
                int Order;

                while (ConcurrentQ.TryDequeue(out Order))
                {
                    Console.WriteLine($"Hilo {Thread.CurrentThread.ManagedThreadId}, Procesando pedido: {Order}");
                    RWLS.EnterReadLock();
                    Console.WriteLine($"Hilo {Thread.CurrentThread.ManagedThreadId}, Asignando número de factura: {InvoiceNumber + 1}");
                    RWLS.ExitReadLock();
                    Thread.Sleep(1000);

                    RWLS.EnterWriteLock();
                    Console.WriteLine($"Pedido {Order} procesado, Hilo {Thread.CurrentThread.ManagedThreadId}!");
                    ProcessOrders++;
                    Console.WriteLine($"Hilo {Thread.CurrentThread.ManagedThreadId}, Número de factura asignado: {++InvoiceNumber}");
                    RWLS.ExitWriteLock();

                    CDE.Signal();
                }

                Console.WriteLine($"Hilo {Thread.CurrentThread.ManagedThreadId}, pedidos procesados {ProcessOrders}");
            };

            Task.Run(ProcessOrder);
            Task.Run(ProcessOrder);
            Task.Run(ProcessOrder);

            //Console.WriteLine($"CurrentCount antes de esperar... {CDE.CurrentCount}");
            CDE.Wait();
            Console.WriteLine($"Se han procesado los pedidos");
            CDE.Dispose();
        }
    }
}
