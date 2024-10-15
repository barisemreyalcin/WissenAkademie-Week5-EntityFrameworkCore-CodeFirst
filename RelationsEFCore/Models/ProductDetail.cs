using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationsEFCore.Models
{
    public class ProductDetail
    {
        public int ProductDetailID { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int ProductRefID { get; set; } // foreign key
        public Product Product { get; set; }

    }
}
