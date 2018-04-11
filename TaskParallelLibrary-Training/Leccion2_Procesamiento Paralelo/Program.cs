using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //RunParallelTasks();
            //ParallelLopIterate();
            RunLINQ();
            RunPLINQ();
            Console.WriteLine("Presione <enter> para finalizar");
            Console.ReadLine();

            //Continuar con Ejercicio 2 Enlazando Tareas - Tarea 1 Crear tareas de continuación.
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

        static void ParallelLopIterate()
        {
            //Demostración de ejecuciones de ciclo en paralelo con For y Foreach de Parallel.
            int[] IntArray = new int[5];
            Parallel.For(0, 5, indice =>
            {
                IntArray[indice] = indice * indice;
                Console.WriteLine($"Calculando operación {indice}, en Thread {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine("Mostrando resultados...");
            Parallel.ForEach(IntArray, Cuadrado =>
            {
                Console.WriteLine($"Cuadrado de {Array.IndexOf(IntArray, Cuadrado)}: {Cuadrado}");
            });
        }

        static void RunLINQ()
        {
            //1 tick => 100 ns
            Stopwatch swObj = new Stopwatch();
            swObj.Start();
            var products = NorthWind.Repository.Products.Select(product => new ProductDTO
            {
                ProductId = product.ProductID,
                ProductName = product.ProductName,
                ProductPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            });
            swObj.Stop();
            Console.WriteLine($"Número de ticks transcurridos después de la consulta: {swObj.ElapsedTicks}");
        }

        static void RunPLINQ()
        {
            //1 tick => 100 ns
            Stopwatch swObj = new Stopwatch();
            swObj.Start();
            var products = NorthWind.Repository.Products.AsParallel()
                .Select(product => new ProductDTO
            {
                ProductId = product.ProductID,
                ProductName = product.ProductName,
                ProductPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            });
            swObj.Stop();
            Console.WriteLine($"Número de ticks transcurridos después de la consulta (con PLINQ): {swObj.ElapsedTicks}");
        }
    }
}
