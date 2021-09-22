using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLineLogic
{
    public class CartService : ICartService
    {
        List<CartItem> _cartItems = new List<CartItem>();
        public void Add(Item item)
        {
            var find = _cartItems.Where(w => w.Item == item).FirstOrDefault();
            if (find != null)
            {
                find.Count++;
            } 
            else
            {
                _cartItems.Add(new CartItem(item, 1));
            }
        }

        public decimal GetTotal(IDiscountService discountService)
        {
            decimal totalPrice = 0;
            foreach (var cartItem in _cartItems)
            {
                if(discountService != null)
                {
                    var discount = discountService.GetDiscountByItem(cartItem.Item);
                    if (discount != null)
                    {
                        decimal currentCartItemPrice = ProcessDiscountPrice(cartItem, discount);
                        if (currentCartItemPrice != 0)
                        {
                            totalPrice += currentCartItemPrice;
                            continue;
                        }
                    }
                }

                totalPrice += cartItem.Count * cartItem.Item.Price;
            }

            return totalPrice;
        }

        public decimal ProcessDiscountPrice(CartItem cartItem, Discount discount)
        {
            decimal totalCartItemPrice = 0;
            if(cartItem.Count >= discount.Count)
            {
                int multiplier = cartItem.Count / discount.Count;
                totalCartItemPrice = multiplier * discount.Price;

                int remainder = cartItem.Count % discount.Count;

                totalCartItemPrice += remainder * cartItem.Item.Price;
            }

            return totalCartItemPrice;
        }

        public void Remove(Item item)
        {
            var find = _cartItems.Where(w => w.Item == item).FirstOrDefault();
            if (find != null)
            {
                find.Count--;

                if (find.Count == 0)
                    _cartItems.Remove(find);
            }
        }
    }
}
