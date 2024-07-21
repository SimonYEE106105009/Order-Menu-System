using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.Models;

namespace 點餐機.Strategy.Strategies
{
    internal class DrinkDiscount : AStrategy
    {
        public override void Discount(List<Item> items, MenuModel.Discountlist strategy)
        {
            string[] Drinks = strategy.Drinks;
            int Price = strategy.Price;
            int Buynumber = strategy.BuyNumber;
            int count = 0;
            int totalprice = 0;
            for (int i = 0; i < items.Count; i++)
            {
     
                if (Drinks.Contains(items[i].Name) == true)
                {
                    count += items[i].Number;
                    totalprice += items[i].Number * items[i].Price;
                }

                
            }
            int total = totalprice - (count / 3) * Price;
            if (count >= Buynumber)
            {
                items.Add(new Item("(優惠)"+"飲料任選" + Buynumber + "杯" + Price + "元",total*-1, 1));
            }
        }
    }
}
