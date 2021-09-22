using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLineLogic
{
    public class Discount
    { 
        public int Count { get; set; }

        public decimal Price { get; set; }

        public Discount(int count, decimal price)
        {
            Count = count;
            Price = price;
        }
    }
}
