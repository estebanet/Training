using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leccion2_Procesamiento_Paralelo
{
    class ProductDTO
    {
        public ProductDTO()
        {
            System.Threading.Thread.Sleep(1);
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? UnitsInStock { get; set; }
    }
}
