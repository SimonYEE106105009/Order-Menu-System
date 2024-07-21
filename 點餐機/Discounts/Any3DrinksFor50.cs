using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class Any3DrinksFor50 : ADiscount
    {
        public override void Discount(List<Item> items)
        {
            string[] drinks = { "紅茶", "綠茶", "奶茶", "鮮奶茶" };
            int DrinkNumber = items.Where(x => drinks.Contains(x.Name))
                                   .Sum(x => x.Number);
            if (DrinkNumber >= 3)
            {
                int DrinkTotal = items.Where(x => drinks.Contains(x.Name))
                                       .Sum(x => x.Subtotal);
                int Drink = DrinkNumber / 3;
                items.Add(new Item("(優惠)飲料任選三杯$50", (DrinkTotal - (50 * Drink)) * -1, 1));
            }
        }
    }
}
