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
            //RunLINQ();
            //RunPLINQ();
            //RunContinuationTask();
            RunNestedTasks();
            Console.WriteLine("Presione <enter> para finalizar");
            Console.ReadLine();

            //Continuar con Ejercicio 3 Manejo de excepciones en tareas - Tarea 1 Atrapar excepciones de Tareas.
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

        static List<string> GetProductNames()
        {
            Thread.Sleep(3000);
            return NorthWind.Repository.Products
                .Select(product => product.ProductName).ToList();
        }

        static void RunContinuationTask()
        {
            Task<List<string>> firstTask = new Task<List<string>>(new Func<List<string>>(GetProductNames));
                

            Task<int> secondTask  = firstTask.ContinueWith<int>(antecedentTask =>
            {
                return ProcessData(antecedentTask.Result);
            });

            Task.Run(() =>
            Console.WriteLine($"Número de nombres de producto procesados: {secondTask.Result}"));

            firstTask.Start();
        }

        static int ProcessData(List<string> ProductNames)
        {
            foreach(string ProductName in ProductNames)
            {
                Console.WriteLine(ProductName);
            }

            return ProductNames.Count;
        }

        static void RunNestedTasks()
        {
            Task outerTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Iniciando tarea \"externa\"");
                Task innerTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Iniciando tarea \"interna\"");
                    Thread.Sleep(3000);
                    Console.WriteLine("Por finalizar tarea \"interna\"");
                }, TaskCreationOptions.AttachedToParent);
            });

            outerTask.Wait();
            Console.WriteLine("Tarea \"externa\" finalizada");
        }
    }
}
