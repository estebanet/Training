using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leccion4_PSC_SemaphoreSlim
{
    class Program
    {
        static void Main(string[] args)
        {
            UseSemaphoreSlim();

            Console.WriteLine("Presione <enter> para finalizar");
            Console.Read();
        }

        static void UseSemaphoreSlim()
        {
            var semaphore1 = new SemaphoreSlim(2);
            //var semaphore2 = new SemaphoreSlim(3, 5);

            //bool enteredS1 = semaphore1.Wait(5000);
            //bool enteredS2 = semaphore2.Wait(1000);

            //Console.WriteLine($"Acceso concedido por semáforo 1: {enteredS1}, " +
            //    $"Accesos disponibles: {semaphore1.CurrentCount}");

            //Console.WriteLine($"Acceso concedido por semáforo 2: {enteredS2}, " +
            //    $"Accesos disponibles: {semaphore2.CurrentCount}");

            //semaphore2.Release();
            //semaphore2.Release();
            //semaphore2.Release();

            //Console.WriteLine(
            //    $"Accesos disponibles: {semaphore2.CurrentCount}, despues de liberar 3 veces el semaforo");

            //Task.Run(delegate
            //{
            //    Console.WriteLine(
            //        $"Tarea {1} antes de solicitar bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    semaphore1.Wait();
            //    Console.WriteLine(
            //        $"Tarea {1} consiguió bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    DoWorkIteration(1, 1);
            //    semaphore1.Release();
            //});


            //Task.Run(delegate
            //{
            //    Console.WriteLine(
            //        $"Tarea {2} antes de solicitar bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    semaphore1.Wait();
            //    Console.WriteLine(
            //        $"Tarea {2} consiguió bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    DoWorkIteration(2, 4);
            //    semaphore1.Release();
            //});

            //Task.Run(delegate
            //{
            //    Console.WriteLine(
            //        $"Tarea {3} antes de solicitar bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    semaphore1.Wait();
            //    Console.WriteLine(
            //        $"Tarea {3} consiguió bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    DoWorkIteration(3, 4);
            //    semaphore1.Release();
            //});

            //Task.Run(delegate
            //{
            //    Console.WriteLine(
            //        $"Tarea {4} antes de solicitar bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    semaphore1.Wait();
            //    Console.WriteLine(
            //        $"Tarea {4} consiguió bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    DoWorkIteration(4, 4);
            //    semaphore1.Release();
            //});

            //Task.Run(delegate
            //{
            //    Console.WriteLine(
            //        $"Tarea {5} antes de solicitar bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    semaphore1.Wait();
            //    Console.WriteLine(
            //        $"Tarea {5} consiguió bloqueo, Accesos disponibles: {semaphore1.CurrentCount}");
            //    DoWorkIteration(5, 4);
            //    semaphore1.Release();
            //});

            //semaphore1.Wait();
            //Console.WriteLine($"Accesos disponibles (1a solicitud): {semaphore1.CurrentCount}");
            //semaphore1.Wait();
            //Console.WriteLine($"Accesos disponibles (2da solicitud) {semaphore1.CurrentCount}");
            //Task.Run(() =>
            //{
            //    Console.WriteLine("Ejecutando Task liberadora");
            //    Thread.Sleep(2000);
            //    Console.WriteLine($"Accesos disponibles antes de liberación {semaphore1.CurrentCount}");
            //    semaphore1.Release();
            //    Console.WriteLine($"Accesos disponibles post de liberación {semaphore1.CurrentCount}");
            //});
            //semaphore1.Wait();
            //Console.WriteLine($"Accesos disponibles (3a solicitud) {semaphore1.CurrentCount}");

            bool enter = semaphore1.Wait(10000);
            Console.WriteLine($"El hilo no tuvo que esperar 10,000 ms: {enter}");
            enter = semaphore1.Wait(10000);
            Console.WriteLine($"Segundo acceso exitoso: {enter}");
            Console.WriteLine("Aquí ya no hay accesos, el hilo tendrá que esperar");
            enter = semaphore1.Wait(10000);
            Console.WriteLine($"Tercer acceso exitoso: {enter}");
            //Console.WriteLine($"Accesos disponibles: {semaphore1.CurrentCount}");
            semaphore1.Release();
            //Console.WriteLine($"Accesos disponibles después de release: {semaphore1.CurrentCount}");
            enter = semaphore1.Wait(10000);
            Console.WriteLine($"Después de realase acceso exitoso: {enter}");
            //Console.WriteLine($"Accesos disponibles: {semaphore1.CurrentCount} antes de esperar");
            var T = Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("Task liberando semforo");
                semaphore1.Release();
            });
            Console.WriteLine($"Accesos disponibles antes de espera: {semaphore1.CurrentCount}");
            //semaphore1.Wait();
            T.Wait();
            Console.WriteLine($"Accesos disponibles después de espera: {semaphore1.CurrentCount}");
            semaphore1.Dispose();
        }

        static void DoWorkIteration(int taskNumber, int seconds)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(seconds * 1000);
                Console.WriteLine($"Ejecutando tarea {taskNumber}");
            }
            Console.WriteLine($"Tarea {taskNumber}, liberando semáforo...");
        }
    }
}
