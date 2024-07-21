using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static 點餐機.Models.MenuModel;

namespace 點餐機.ADiscounts
{
    public abstract class ADiscount
    {
        public abstract void Discount(List<Item> items);
    }
}
