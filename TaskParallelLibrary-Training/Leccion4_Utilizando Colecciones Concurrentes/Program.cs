using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace Leccion4_Utilizando_Colecciones_Concurrentes
{
    class Program
    {
        static void Main(string[] args)
        {
            //UseConcurrentBag();
            //UseDictionaryConcurrent();
            //UseQueueConcurrent();
            UseStackConcurrent();
            Console.WriteLine("Presione <enter> para continuar...");
            Console.Read();
        }

        static void UseConcurrentBag()
        {
            //ArrayList BagNoThreadSafe = new ArrayList();
            ConcurrentBag<object> BagNoThreadSafe = new ConcurrentBag<object>();

            Action<object> ActionToAddObjects = delegate (object object_)
            {
                Console.WriteLine("Añdiento objeto: " + object_ + $" con {BagNoThreadSafe.Count} elementos antes de su inserción");
                BagNoThreadSafe.Add(object_);
                Console.WriteLine("Objeto añadido: " + object_ + $" con {BagNoThreadSafe.Count} elementos después de su inserción");
            };

            Parallel.Invoke(() => ActionToAddObjects("1"),
                () => ActionToAddObjects("2"),
                () => ActionToAddObjects("3"),
                () => ActionToAddObjects("4"),
                () => ActionToAddObjects("5"),
                () => ActionToAddObjects("6"),
                () => ActionToAddObjects("7"),
                () => ActionToAddObjects("8"),
                () => ActionToAddObjects("9"),
                () => ActionToAddObjects("10"));

            Console.WriteLine("Finalizando escritura en colección Thread-Safe");

            Console.WriteLine("Elementos agregados a bag thread safe");

            int i = 0;
            foreach (object obj in BagNoThreadSafe)
            {
                Console.WriteLine((i++ + 1) + ") " + obj);
            }
        }

        static void UseDictionaryConcurrent()
        {
            ConcurrentDictionary<int, object> BagNoThreadSafe = new ConcurrentDictionary<int, object>();

            Action<object> ActionToAddObjects = delegate (object object_)
            {
                Console.WriteLine("Añdiento objeto: " + object_ + $" con {BagNoThreadSafe.Count} elementos antes de su inserción");
                BagNoThreadSafe.TryAdd(int.Parse(object_.ToString()), object_);
                Console.WriteLine("Objeto añadido: " + object_ + $" con {BagNoThreadSafe.Count} elementos después de su inserción");
            };

            Parallel.Invoke(() => ActionToAddObjects("1"),
                () => ActionToAddObjects("2"),
                () => ActionToAddObjects("3"),
                () => ActionToAddObjects("4"),
                () => ActionToAddObjects("5"),
                () => ActionToAddObjects("6"),
                () => ActionToAddObjects("7"),
                () => ActionToAddObjects("8"),
                () => ActionToAddObjects("9"),
                () => ActionToAddObjects("10"));

            Console.WriteLine("Finalizando escritura en colección Thread-Safe");

            Console.WriteLine("Elementos agregados a bag thread safe");

            int i = 0;
            foreach (object obj in BagNoThreadSafe)
            {
                Console.WriteLine((i++ + 1) + ") " + obj);
            }
        }

        static void UseQueueConcurrent()
        {
            ConcurrentQueue<object> BagNoThreadSafe = new ConcurrentQueue<object>();

            Action<object> ActionToAddObjects = delegate (object object_)
            {
                Console.WriteLine("Añdiento objeto: " + object_ + $" con {BagNoThreadSafe.Count} elementos antes de su inserción");
                BagNoThreadSafe.Enqueue(object_);
                Console.WriteLine("Objeto añadido: " + object_ + $" con {BagNoThreadSafe.Count} elementos después de su inserción");
            };

            Parallel.Invoke(() => ActionToAddObjects("1"),
                () => ActionToAddObjects("2"),
                () => ActionToAddObjects("3"),
                () => ActionToAddObjects("4"),
                () => ActionToAddObjects("5"),
                () => ActionToAddObjects("6"),
                () => ActionToAddObjects("7"),
                () => ActionToAddObjects("8"),
                () => ActionToAddObjects("9"),
                () => ActionToAddObjects("10"));

            Console.WriteLine("Finalizando escritura en colección Thread-Safe");

            Console.WriteLine("Elementos agregados a bag thread safe");

            //int i = 0;
            //foreach (object obj in BagNoThreadSafe)
            //{
            //    Console.WriteLine((i++ + 1) + ") " + obj);
            //}

            int CountObjectsDequeue = 0;
            Action<int> ActionToDequeue = noHilo =>
            {
                object Valor = null;
                int DequeueCountThread = 0;
                while (BagNoThreadSafe.TryDequeue(out Valor))
                {

                    Interlocked.Increment(ref CountObjectsDequeue);
                    Console.WriteLine(CountObjectsDequeue + ") Valor desencolado: " + Valor);
                    DequeueCountThread++;
                }

                Console.WriteLine("Hilo: " + noHilo + ") desencolo " + DequeueCountThread + " elementos");
            };

            Parallel.Invoke(() => ActionToDequeue(1), () => ActionToDequeue(2),
                () => ActionToDequeue(3), () => ActionToDequeue(4));
        }

        static void UseStackConcurrent()
        {
            ConcurrentStack<object> BagNoThreadSafe = new ConcurrentStack<object>();

            Action<object> ActionToAddObjects = delegate (object object_)
            {
                Console.WriteLine("Añdiento objeto: " + object_ + $" con {BagNoThreadSafe.Count} elementos antes de su inserción");
                BagNoThreadSafe.Push(object_);
                Console.WriteLine("Objeto añadido: " + object_ + $" con {BagNoThreadSafe.Count} elementos después de su inserción");
            };

            Parallel.Invoke(() => ActionToAddObjects("1"),
                () => ActionToAddObjects("2"),
                () => ActionToAddObjects("3"),
                () => ActionToAddObjects("4"),
                () => ActionToAddObjects("5"),
                () => ActionToAddObjects("6"),
                () => ActionToAddObjects("7"),
                () => ActionToAddObjects("8"),
                () => ActionToAddObjects("9"),
                () => ActionToAddObjects("10"));

            Console.WriteLine("Finalizando escritura en colección Thread-Safe");

            Console.WriteLine("Elementos agregados a bag thread safe");

            //int i = 0;
            //foreach (object obj in BagNoThreadSafe)
            //{
            //    Console.WriteLine((i++ + 1) + ") " + obj);
            //}

            int CountObjectsDequeue = 0;
            Action<int> ActionToDequeue = noHilo =>
            {
                object Valor = null;
                int DequeueCountThread = 0;
                while (BagNoThreadSafe.TryPop(out Valor))
                {

                    Interlocked.Increment(ref CountObjectsDequeue);
                    Console.WriteLine(CountObjectsDequeue + ") Valor desempilado: " + Valor);
                    DequeueCountThread++;
                }

                Console.WriteLine("Hilo: " + noHilo + ") desemplilo " + DequeueCountThread + " elementos");
            };

            Parallel.Invoke(() => ActionToDequeue(1), () => ActionToDequeue(2),
                () => ActionToDequeue(3), () => ActionToDequeue(4));
        }
    }
}
