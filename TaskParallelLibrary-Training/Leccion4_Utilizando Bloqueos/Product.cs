using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leccion4_Utilizando_Bloqueos
{
    class Product
    {
        object lockObj;
        int UnitsInStock;

        public Product()
        {
            lockObj = new object();
        }

        public Product(int InitialUnitsInStock)
            :this()
        {
            UnitsInStock = InitialUnitsInStock;
        }

        internal bool PlaceOrder(int RequestedUnits)
        {
            bool Acepted = false;
            if (UnitsInStock < 0)
            {
                throw new Exception("La existencia no puede ser negativa");
            }

            //lock (lockObj)
            //{
            try
            {
                Monitor.Enter(lockObj);
                if (UnitsInStock >= RequestedUnits)
                {
                    Console.WriteLine($"Existencia antes de antender el pedido: {UnitsInStock}");

                    UnitsInStock -= RequestedUnits;

                    Console.WriteLine($"Existencia después de antender el pedido: {UnitsInStock}");

                    Acepted = true;
                }
            }
            finally
            {
                Monitor.Exit(lockObj);
            }
            //}

            return Acepted;
        }
    }
}
