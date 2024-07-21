using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Models;

namespace 點餐機.Strategy.Strategies
{
    internal class FullStrategies : AStrategy
    {
        public override void Discount(List<Item> items, MenuModel.Discountlist strategy)
        {
            int TotalPrice = strategy.TotalPrice;
            int DiscountPrice = strategy.DiscountPrice;
            int Pricetotal = items.Sum(x => x.Price * x.Number);

            if (Pricetotal >= TotalPrice)
            {
                items.Add(new Item("(滿額)" + TotalPrice + "元以上折" + DiscountPrice + "元", DiscountPrice * -1, 1));
            }
        }
    }
}
