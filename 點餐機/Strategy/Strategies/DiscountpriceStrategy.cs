using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Models;

namespace 點餐機.Strategy.Strategies
{
    internal class DiscountpriceStrategy : AStrategy
    {
        public override void Discount(List<Item> items, MenuModel.Discountlist strategy)
        {
            string MainFood = strategy.MainFood;
            int Buynumber = strategy.BuyNumber;
            int Price = strategy.Price;
            Item item = items.FirstOrDefault(x => x.Name == MainFood);
            if (item != null && item.Number >= Buynumber)
            {
                int quotientnumber = item.Number / Buynumber;
                int remaindernumber = item.Number % Buynumber;
                int Buyprice = Price * quotientnumber + item.Price * remaindernumber;
                int discountprices = (item.Number * item.Price) - Buyprice;
                items.Add(new Item("(折扣)"+item.Name+"買" + item.Number + "個為" + Price + "元", discountprices*-1, 1));
            }
        }
    }
}
