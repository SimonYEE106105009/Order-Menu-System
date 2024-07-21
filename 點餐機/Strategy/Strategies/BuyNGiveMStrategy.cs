using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Models;

namespace 點餐機.Strategy.Strategies
{
    internal class BuyNGiveMStrategy : AStrategy
    {
        public override void Discount(List<Item> items, MenuModel.Discountlist strategy)
        {
            string foodName = strategy.MainFood; // 三寶飯
            int buyNumber = strategy.BuyNumber;
            int giveNumber = strategy.GiveNumber;
            string givefood = strategy.GiveFood;

            Item item = items.FirstOrDefault(x => x.Name == foodName && x.Number / buyNumber > 0);
            if (item != null)
            {
                int bonusfood = (item.Number / buyNumber) * giveNumber;
                items.Add(new Item($"(贈送){givefood}", 0, bonusfood));
            }
        }
    }
}
