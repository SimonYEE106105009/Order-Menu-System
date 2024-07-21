using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Models;

namespace 點餐機.Strategy.Strategies
{
    internal class DiscountStrategy : AStrategy
    {
        public override void Discount(List<Item> items, MenuModel.Discountlist strategy)
        {
            string MainFood = strategy.MainFood;
            int Buynumber = strategy.BuyNumber;
            int Price = strategy.Price;
            double DiscountPercent = strategy.DiscountPrecent; 
            Item item = items.FirstOrDefault(x => x.Name == MainFood);
            if (item != null && item.Number >= Buynumber)
            {
                int quotientnumber = item.Number / Buynumber;
                int remaindernumber = item.Number % Buynumber;
                double Buyprice = (Buynumber * quotientnumber* item.Price * DiscountPercent) + item.Price * remaindernumber;
                double discountprices = (item.Number * item.Price) - Buyprice;
                items.Add(new Item("(折扣)買" + item.Number + "個打" + (DiscountPercent)*100 + "折", (int)discountprices*-1 , 1));
            }
        }
    }
}
