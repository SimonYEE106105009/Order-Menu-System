using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 點餐機.ADiscounts;
using 點餐機.Strategy;
using 點餐機.Strategy.Strategies;
using static 點餐機.Models.MenuModel;

namespace 點餐機
{
    internal class Discount
    {
        public static void DiscountOrder(List<Item> items, Discountlist strategy)
        {
            items.RemoveAll(x => x.Name.Contains("贈送") || x.Name.Contains("折扣") || x.Name.Contains("優惠") || x.Name.Contains("套餐") || x.Name.Contains("滿額"));
            Type t = Type.GetType(strategy.StrategyName);
            AStrategy discount = (AStrategy)Activator.CreateInstance(t);
            StrategyContext context = new StrategyContext(items, discount);
            context.ApplyStrategy(strategy);
            //discount.Discount(items);
            ShowPanel.ShowDetail(items);


            //if (option == "三寶飯買2送1") 
            //{
            //    #region FOR迴圈版本
            //    //FOR迴圈版本
            //    //foreach (Item item in items)
            //    //{
            //    //    if(item.Name == "三寶飯" && item.Number/2>0)
            //    //    {
            //    //        items.Add(new Item("(贈送)三寶飯",0,item.Number/2));
            //    //    }
            //    //}
            //    #endregion

            //    //LINQ
            //    Item item = items.FirstOrDefault(x => x.Name == "三寶飯" && x.Number / 2 > 0);
            //    if (item!=null)
            //    {
            //        items.Add(new Item("(贈送)三寶飯", 0, item.Number / 2));
            //    }
            //}
            //else if (option == "雞排飯搭紅茶$100")
            //{
            //    Item item = items.FirstOrDefault(x => x.Name == "雞排飯");
            //    Item item2 = items.FirstOrDefault(x => x.Name == "紅茶");
            //    if (item != null && item2 != null)
            //    {
            //        int MinNumber = item.Number < item2.Number ? item.Number : item2.Number;
            //        items.Add(new Item("(折扣)雞排飯搭紅茶", -10, MinNumber));
            //    }
            //}
            //else if (option == "排骨飯買3個$200")
            //{
            //    Item item = items.FirstOrDefault(x => x.Name == "排骨飯");
            //    if (item.Number >= 3)
            //    {
            //        items.Add(new Item("(折扣)排骨飯",-40, item.Number/3));
            //    }
            //}
            //else if (option == "雞腿飯買5個打8折")
            //{
            //    Item item = items.FirstOrDefault(x => x.Name == "雞腿飯");
            //    if (item.Number >= 5)
            //    {
            //        items.Add(new Item("(折扣)雞腿飯", (int)(item.Price*-1*0.2*item.Number),1));
            //    }
            //}
            //else if (option == "咖哩飯買2個送薯條")
            //{
            //    Item item = items.FirstOrDefault(x => x.Name == "咖哩飯" && x.Number / 2 > 0);
            //    if (item != null)
            //    {
            //        items.Add(new Item("(贈送)薯條", 0, item.Number / 2));
            //    }
            //}
            //else if (option == "咖哩飯搭地瓜球$100")
            //{
            //    Item item = items.FirstOrDefault(x => x.Name == "咖哩飯");
            //    Item item2 =items.FirstOrDefault(x => x.Name == "地瓜球");
            //    if (item != null && item2 != null)
            //    {
            //        items.Add(new Item("(折扣)$5", -5 ,1));
            //    }
            //}
            //else if (option == "排骨飯搭炸湯圓$100")
            //{
            //    Item item = items.FirstOrDefault(x => x.Name == "排骨飯");
            //    Item item2 = items.FirstOrDefault(x => x.Name == "地瓜球");
            //    if (item != null && item2 != null)
            //    {
            //        int MinNumber = item.Number < item2.Number ? item.Number : item2.Number;
            //        items.Add(new Item("(折扣)排骨飯搭湯圓", -10, MinNumber));
            //    }
            //}
            //else if (option == "消費滿$300折$30")
            //{
            //    int total = items.Sum(x => x.Subtotal);
            //    //foreach (Item item in items)
            //    //{
            //    //    total += item.Subtotal;
            //    //}
            //    if (total > 300)
            //    {
            //        items.Add(new Item("(優惠)滿$300折$30", -30, total / 300));
            //    }
            //}
            //else if (option == "全場消費打85折")
            //{
            //    int total = items.Sum(x => x.Subtotal);

            //    items.Add(new Item("(優惠)全場消費打85折", (int)(total * -1 * 0.15), 1));
            //}
            //else if (option == "飲料任選三杯$50")
            //{
            //    string[] drinks = { "紅茶","綠茶","奶茶","鮮奶茶" };
            //    int DrinkNumber = items.Where(x => drinks.Contains(x.Name))
            //                           .Sum(x => x.Number);
            //    if (DrinkNumber >= 3)
            //    {
            //        int DrinkTotal = items.Where(x => drinks.Contains(x.Name))
            //                               .Sum(x => x.Subtotal);
            //        int Drink = DrinkNumber / 3;
            //        items.Add(new Item("(優惠)飲料任選三杯$50", (DrinkTotal - (50 *Drink))*-1, 1));
            //    }
            //}
        }
    }
}
