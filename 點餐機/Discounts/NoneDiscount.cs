using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;

namespace 點餐機.Discounts
{
    internal class NoneDiscount : ADiscount
    {
        public override void Discount(List<Item> items)
        {

        }
    }
}
