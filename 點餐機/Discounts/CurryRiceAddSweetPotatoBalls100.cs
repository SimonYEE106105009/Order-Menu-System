using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class CurryRiceAddSweetPotatoBalls100 : ADiscount
    {
        public override void Discount(List<Item> items)
        {
            Item item = items.FirstOrDefault(x => x.Name == "咖哩飯");
            Item item2 = items.FirstOrDefault(x => x.Name == "地瓜球");
            if (item != null && item2 != null)
            {
                items.Add(new Item("(折扣)$5", -5, 1));
            }
        }
    }
}
