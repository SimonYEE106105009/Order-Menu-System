using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;
using 點餐機.Strategy.Strategies;
using static 點餐機.Models.MenuModel;

namespace 點餐機.Strategy
{
    public class StrategyContext
    {
        AStrategy strategy;
        List<Item> list;

        public StrategyContext(List<Item>list, AStrategy strategy)
        {
            this.strategy = strategy;
            this.list = list;
        }
        public void ApplyStrategy(Discountlist condition)
        {
            strategy.Discount(list,condition);
        }
    }
}
