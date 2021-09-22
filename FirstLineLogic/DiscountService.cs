using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLineLogic
{
    public class DiscountService : IDiscountService
    {
        Dictionary<Item, Discount> discountDict = new Dictionary<Item, Discount>();
        public void Add(Item item, Discount discount)
        {
            if(discountDict.ContainsKey(item))
            {
                discountDict[item] = discount;
            }
            else
            {
                discountDict.Add(item, discount);
            }
        }

        public Discount GetDiscountByItem(Item item)
        {
            if (discountDict.ContainsKey(item))
                return discountDict[item];
            else
                return null;
        }

        public void Remove(Item item)
        {
            if (discountDict.ContainsKey(item))
            {
                discountDict.Remove(item);
            }
        }


    }
}
