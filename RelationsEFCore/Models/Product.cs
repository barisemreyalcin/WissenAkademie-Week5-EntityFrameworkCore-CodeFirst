using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationsEFCore.Models
{
    public class Product
    {
        public Product() { 
            Date = DateTime.Now;
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int StockAmount { get; set; }
        public double UnitPrice { get; set; }
        public DateTime Date { get; set; }
        // foreign key
        public int CategoryRefID { get; set; }
        public virtual Category Category { get; set; } // bire sonsuz
        public virtual ProductDetail ProductDetail { get; set; } // bire bir
    }
}
