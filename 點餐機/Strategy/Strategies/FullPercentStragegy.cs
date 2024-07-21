using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Models;

namespace 點餐機.Strategy.Strategies
{
    internal class FullPercentStragegy : AStrategy
    {
        public override void Discount(List<Item> items, MenuModel.Discountlist strategy)
        {
            double discountpercent = strategy.DiscountPrecent;
            int pricetotal = items.Sum(x => x.Price * x.Number);

            items.Add(new Item("(折扣)打85折", (int)((pricetotal) - (pricetotal*discountpercent))*-1, 1));
        }
    }
}
