using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_api.Models
{
    public class Product
    {
        public Product() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public int VendorId { get; set; }
    }
}
