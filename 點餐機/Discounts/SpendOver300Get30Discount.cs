using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class SpendOver300Get30Discount : ADiscount
    {
        public override void Discount(List<Item> items)
        {
            int total = items.Sum(x => x.Subtotal);
            #region foreach迴圈加法
            //foreach (Item item in items)
            //{
            //    total += item.Subtotal;
            //}
            #endregion
            if (total > 300)
            {
                items.Add(new Item("(優惠)滿$300折$30", -30, total / 300));
            }
        }
    }
}
