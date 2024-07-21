using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class Get15PercentOffAllPurchases : ADiscount
    {
        public override void Discount(List<Item> items)
        {
            int total = items.Sum(x => x.Subtotal);

            items.Add(new Item("(優惠)全場消費打85折", (int)(total * -1 * 0.15), 1));
        }
    }
}
