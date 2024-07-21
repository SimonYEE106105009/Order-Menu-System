using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Models
{
    public class MenuModel
    {
        public Menulist[] MenuList { get; set; }
        public Discountlist[] DiscountList { get; set; }

        public class Menulist
        {
            public string Type { get; set; }
            public Food[] Food { get; set; }
        }

        public class Food
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class Discountlist
        {
            public string Name { get; set; }
            public string StrategyName { get; set; }
            public string MainFood { get; set; }
            public string SubFood { get; set; }
            public string[] Drinks { get; set; }
            public string GiveFood { get; set; }
            public int BuyNumber { get; set; }
            public int BuySubNumber { get; set; }
            public int GiveNumber { get; set; }
            public int Price { get; set; }
            public int TotalPrice { get; set; }
            public int DiscountPrice { get; set; }
            public double DiscountPrecent { get; set; }
        }

    }
}
