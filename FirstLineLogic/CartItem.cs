using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLineLogic
{
    public class CartItem
    {
       public Item Item { get; private set; }
        
       public int Count { get; set; }

        public CartItem(Item item, int count)
        {
            Item = item;
            Count = count;
        }
    }
}
