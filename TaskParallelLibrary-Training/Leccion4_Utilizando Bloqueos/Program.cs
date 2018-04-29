using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leccion4_Utilizando_Bloqueos
{
    class Program
    {
        static void Main(string[] args)
        {
            Product producto = new Product(1000);
            Random generadorEnteros = new Random();

            Parallel.For(0, 100, indice =>
            {
                producto.PlaceOrder(generadorEnteros.Next(1, 100));
            });

            Console.WriteLine("Presione <enter> para continuar...");
            Console.Read();
        }
    }
}
