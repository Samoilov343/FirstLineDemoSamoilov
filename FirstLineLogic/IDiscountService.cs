using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLineLogic
{
    public interface IDiscountService
    {
        void Add(Item item, Discount discount);
        Discount GetDiscountByItem(Item item);

        void Remove(Item item);
    }
}
