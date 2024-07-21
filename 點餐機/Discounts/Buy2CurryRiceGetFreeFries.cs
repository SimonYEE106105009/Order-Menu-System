using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class Buy2CurryRiceGetFreeFries : ADiscount
    {
        public override void Discount(List<Item> items)
        {
            Item item = items.FirstOrDefault(x => x.Name == "咖哩飯" && x.Number / 2 > 0);
            if (item != null)
            {
                items.Add(new Item("(贈送)薯條", 0, item.Number / 2));
            }
        }
    }
}
