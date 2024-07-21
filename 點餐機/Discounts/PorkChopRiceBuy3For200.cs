using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class PorkChopRiceBuy3For200 : ADiscount
    {
        public override void Discount(List<Item> items)
        {
            Item item = items.FirstOrDefault(x => x.Name == "排骨飯");
            if (item.Number >= 3)
            {
                items.Add(new Item("(折扣)排骨飯", -40, item.Number / 3));
            }
        }
    }
}
