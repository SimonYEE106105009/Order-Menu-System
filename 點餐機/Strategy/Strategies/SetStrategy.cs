using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Models;

namespace 點餐機.Strategy.Strategies
{
    internal class SetStrategy : AStrategy
    {
        public override void Discount(List<Item> items, MenuModel.Discountlist strategy)
        {
            string MainFood = strategy.MainFood;
            string SubFood = strategy.SubFood;
            int Price = strategy.Price;
            Item item = items.FirstOrDefault(x => x.Name == MainFood);
            Item item2 = items.FirstOrDefault(x => x.Name == SubFood);
            if (item != null && item2 != null)
            {
                int MinNumber = item.Number < item2.Number ? item.Number : item2.Number;
                items.Add(new Item("(套餐)"+MainFood+"搭"+SubFood, (item.Price + item2.Price - Price)*-1, MinNumber));
            }

        }
    }
}
