using FirstLineLogic;
using NUnit.Framework;

namespace FirstLineDemoTest
{
    public class Tests
    {
        [Test]
        public void BasicCart_AllItemsOnce()
        {
            Item item1 = new Item("Vase", 1.2m);
            Item item2 = new Item("Big mug", 1);
            Item item3 = new Item("Napkins pack", 0.45m);

            ICartService cart = new CartService();
            cart.Add(item1);
            cart.Add(item2);
            cart.Add(item3);

            Assert.AreEqual(2.65m, cart.GetTotal(null));

            Assert.Pass();
        }

        [Test]
        public void BasicCart_MixedItemCount()
        {
            Item item1 = new Item("Vase", 1.2m);
            Item item2 = new Item("Big mug", 1);

            ICartService cart = new CartService();
            cart.Add(item1);
            cart.Add(item1);
            cart.Add(item1);
            cart.Add(item2);

            Assert.AreEqual(4.6m, cart.GetTotal(null));

            Assert.Pass();
        }

        [Test]
        public void BasicCart_NoItems()
        {
            ICartService cart = new CartService();

            Assert.AreEqual(0, cart.GetTotal(null));

            Assert.Pass();
        }

        [Test]
        public void BasicDiscount_GetDiscountValue()
        {
            IDiscountService discountService = new DiscountService();

            Item mug = new Item("Big mug", 1);
            Item napkins = new Item("Napkins pack", 0.45m);
            Discount discountMug = new Discount(2, 1.5m);
            Discount discountNapkins = new Discount(3, 0.9m);

            discountService.Add(mug, discountMug);
            discountService.Add(napkins, discountNapkins);

            Assert.AreEqual(discountMug, discountService.GetDiscountByItem(mug));
            Assert.AreEqual(discountNapkins, discountService.GetDiscountByItem(napkins));
        }

        [Test]
        public void Discount_TotalPrice()
        {
            IDiscountService discountService = new DiscountService();

            Item vase = new Item("Vase", 1.2m);
            Item mug = new Item("Big mug", 1);
            Item napkins = new Item("Napkins pack", 0.45m);
            Discount discountMug = new Discount(2, 1.5m);
            Discount discountNapkins = new Discount(3, 0.9m);

            discountService.Add(mug, discountMug);
            discountService.Add(napkins, discountNapkins);

            ICartService cart = new CartService();
            cart.Add(vase);
            cart.Add(vase);
            cart.Add(mug);
            cart.Add(mug);
            cart.Add(napkins);
            cart.Add(napkins);
            cart.Add(napkins);

            Assert.AreEqual(4.8m, cart.GetTotal(discountService));
        }

        [Test]
        public void Discount_TotalPrice_RemoveItems()
        {
            IDiscountService discountService = new DiscountService();

            Item vase = new Item("Vase", 1.2m);
            Item mug = new Item("Big mug", 1);
            Item napkins = new Item("Napkins pack", 0.45m);
            Discount discountMug = new Discount(2, 1.5m);
            Discount discountNapkins = new Discount(3, 0.9m);

            discountService.Add(mug, discountMug);
            discountService.Add(napkins, discountNapkins);

            ICartService cart = new CartService();
            cart.Add(vase);
            cart.Add(vase);
            cart.Add(mug);
            cart.Add(mug);
            cart.Add(napkins);
            cart.Add(napkins);
            cart.Add(napkins);

            Assert.AreEqual(4.8m, cart.GetTotal(discountService));
            cart.Remove(napkins);
            Assert.AreEqual(4.8m, cart.GetTotal(discountService));
            cart.Remove(mug);
            Assert.AreEqual(4.3m, cart.GetTotal(discountService));
        }

        [Test]
        public void Discount_TotalPrice_RemoveDiscount()
        {
            IDiscountService discountService = new DiscountService();

            Item vase = new Item("Vase", 1.2m);
            Item mug = new Item("Big mug", 1);
            Item napkins = new Item("Napkins pack", 0.45m);
            Discount discountMug = new Discount(2, 1.5m);
            Discount discountNapkins = new Discount(3, 0.9m);

            discountService.Add(mug, discountMug);
            discountService.Add(napkins, discountNapkins);

            ICartService cart = new CartService();
            cart.Add(vase);
            cart.Add(vase);
            cart.Add(mug);
            cart.Add(mug);
            cart.Add(napkins);
            cart.Add(napkins);
            cart.Add(napkins);

            Assert.AreEqual(4.8m, cart.GetTotal(discountService));
            discountService.Remove(napkins);
            Assert.AreEqual(5.25m, cart.GetTotal(discountService));
        }

        [Test]
        public void Discount_TotalPrice_MoreItemsThanBonus()
        {
            IDiscountService discountService = new DiscountService();

            Item mug = new Item("Big mug", 1);
            Item napkins = new Item("Napkins pack", 0.45m);
            Discount discountMug = new Discount(2, 1.5m);
            Discount discountNapkins = new Discount(3, 0.9m);

            discountService.Add(mug, discountMug);
            discountService.Add(napkins, discountNapkins);

            ICartService cart = new CartService();
            cart.Add(mug);
            cart.Add(mug);
            cart.Add(mug);
            cart.Add(napkins);
            cart.Add(napkins);
            cart.Add(napkins);
            cart.Add(napkins);

            Assert.AreEqual(3.85m, cart.GetTotal(discountService));
        }
    }
}