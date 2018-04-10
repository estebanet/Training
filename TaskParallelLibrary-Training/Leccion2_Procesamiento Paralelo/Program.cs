using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leccion2_Procesamiento_Paralelo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunParallelTasks();
            Console.WriteLine("Presione <enter> para finalizar");
            Console.ReadLine();

            //Continuar Ejercicio 1 - Tarea 3 / Ejecución de ciclos en paralelo.
        }

        static void RunParallelTasks()
        {
            Console.WriteLine("Iniciando ejecución de multiples tareas...");
            Parallel.Invoke(
                () => WriteToConsole("Tarea 1"),
                () => WriteToConsole("Tarea 2"),
                () => WriteToConsole("Tarea 3"));
        }

        static void WriteToConsole(string message)
        {
            int ThreadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"{message}, Thread: {ThreadId}");
            Thread.Sleep(5000);
            Console.WriteLine($"Fin de la tarea {message}, Thread: {ThreadId}");
        }
    }
}
