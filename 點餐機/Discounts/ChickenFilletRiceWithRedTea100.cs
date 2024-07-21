using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class ChickenFilletRiceWithRedTea100 : ADiscount
    {

        public override void Discount(List<Item> items)
        {
            Item item = items.FirstOrDefault(x => x.Name == "雞排飯");
            Item item2 = items.FirstOrDefault(x => x.Name == "紅茶");
            if (item != null && item2 != null)
            {
                int MinNumber = item.Number < item2.Number ? item.Number : item2.Number;
                items.Add(new Item("(折扣)雞排飯搭紅茶", -10, MinNumber));
            }
        }
    }
}
