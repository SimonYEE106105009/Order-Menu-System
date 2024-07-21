using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class ChickenLegRiceBuy5Get20PercentOff : ADiscount
    {
        public override void Discount(List<Item> items)
        {
            Item item = items.FirstOrDefault(x => x.Name == "雞腿飯");
            if (item.Number >= 5)
            {
                items.Add(new Item("(折扣)雞腿飯", (int)(item.Price * -1 * 0.2 * item.Number), 1));
            }
        }
    }
}
