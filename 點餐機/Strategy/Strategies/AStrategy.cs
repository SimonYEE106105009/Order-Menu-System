using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Strategy.Strategies
{
    public abstract class AStrategy
    {
        public abstract void Discount(List<Item> items, Models.MenuModel.Discountlist strategy);

    }
}
