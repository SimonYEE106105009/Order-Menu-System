using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class ThreeTreasuresRiceBuy2Get1Free : ADiscount
    {
        public override void Discount(List<Item> items)
        {
            Item item = items.FirstOrDefault(x => x.Name == "三寶飯" && x.Number / 2 > 0);
            if (item != null)
            {
                items.Add(new Item("(贈送)三寶飯", 0, item.Number / 2));
            }
        }
    }
}
