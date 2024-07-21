using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 點餐機.Models.MenuModel;

namespace 點餐機
{
    internal class Order
    {
        private static List<Item> items = new List<Item>();
        public static void AddOrder(Item item, Discountlist discountOption)
        {
            // any 有無資料
            Item product = items.FirstOrDefault(x => x.Name == item.Name);

            // 新增 => 當items不存在的時候就做新增
            // 刪除 => 當item存在在items中 但數量為0
            // 修改 => 當item存在在 items中 且 數量不一致

            if (product == null && item.Number > 0)
            {
                items.Add(item);
                Discount.DiscountOrder(items,discountOption);
                return;
            }
            if (product == null && item.Number == 0)
            {
                return;
            }
            if (product != null && item.Number == 0)
            {
                items.Remove(product);
                Discount.DiscountOrder(items, discountOption);
                return;
            }
            else
            {
                product.Number = item.Number;
                product.Subtotal = item.Subtotal;
                Discount.DiscountOrder(items, discountOption);
                return;
            }
        }
        public static int GetSubtotal()
        {
            var updatedItems = items.Sum(i =>
            {
                i.Subtotal = i.Price * i.Number;
                return i.Subtotal;
            });
            return updatedItems;
        }
        #region ShowDetail
        //public static void ShowDetail(FlowLayoutPanel flowLayoutPanel5)
        //{
        //    flowLayoutPanel5.Controls.Clear();
        //    foreach (Item item in items)
        //    {
        //        Label label1 = new Label();
        //        label1.Text = item.Name;
        //        label1.Width = 65;
        //        label1.TextAlign = ContentAlignment.MiddleCenter;
        //        Label label2 = new Label();
        //        label2.Text = item.Price.ToString();
        //        label2.Width = 65;
        //        label2.TextAlign = ContentAlignment.MiddleCenter;
        //        Label label3 = new Label();
        //        label3.Text = item.Number.ToString();
        //        label3.Width = 65;
        //        label3.TextAlign = ContentAlignment.MiddleCenter;
        //        Label label4 = new Label();
        //        label4.Text = item.Subtotal.ToString();
        //        label4.Width = 65;
        //        label4.TextAlign = ContentAlignment.MiddleCenter;
        //        Label label5 = new Label();
        //        label5.Text = item.Remark;
        //        label5.Width = 65;
        //        label5.TextAlign = ContentAlignment.MiddleCenter;
        //        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
        //        flowLayoutPanel.Height = 40;
        //        flowLayoutPanel.Width = flowLayoutPanel5.Width;
        //        flowLayoutPanel.Controls.Add(label1);
        //        flowLayoutPanel.Controls.Add(label2);
        //        flowLayoutPanel.Controls.Add(label3);
        //        flowLayoutPanel.Controls.Add(label4);
        //        flowLayoutPanel.Controls.Add(label5);
        //        flowLayoutPanel5.Controls.Add(flowLayoutPanel);
        //    }
            #endregion     
        
    }
}
