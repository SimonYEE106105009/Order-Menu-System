using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class PorkChopRiceAddFriedGlutinousRiceBalls100 : ADiscount
    {
        public override void Discount(List<Item> items)
        {
            Item item = items.FirstOrDefault(x => x.Name == "排骨飯");
            Item item2 = items.FirstOrDefault(x => x.Name == "湯圓");
            if (item != null && item2 != null)
            {
                int MinNumber = item.Number < item2.Number ? item.Number : item2.Number;
                items.Add(new Item("(折扣)排骨飯搭湯圓", -10, MinNumber));
            }
        }
    }
}
