using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐機
{
    internal class ShowPanel
    {
        public static void ShowDetail(List<Item>items)
        {
            FlowLayoutPanel Panel = new FlowLayoutPanel();
            Panel.Width = 400;
            Panel.Height = 400;
            foreach (Item item in items)
            {
                Label label1 = new Label();
                label1.Text = item.Name;
                label1.Width = 65;
                label1.TextAlign = ContentAlignment.MiddleCenter;
                Label label2 = new Label();
                label2.Text = item.Price.ToString();
                label2.Width = 65;
                label2.TextAlign = ContentAlignment.MiddleCenter;
                Label label3 = new Label();
                label3.Text = item.Number.ToString();
                label3.Width = 65;
                label3.TextAlign = ContentAlignment.MiddleCenter;
                Label label4 = new Label();
                label4.Text = item.Subtotal.ToString();
                label4.Width = 65;
                label4.TextAlign = ContentAlignment.MiddleCenter;
                Label label5 = new Label();
                label5.Text = item.Remark;
                label5.Width = 65;
                label5.TextAlign = ContentAlignment.MiddleCenter;
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Height = 40;
                flowLayoutPanel.Width = Panel.Width;
                flowLayoutPanel.Controls.Add(label1);
                flowLayoutPanel.Controls.Add(label2);
                flowLayoutPanel.Controls.Add(label3);
                flowLayoutPanel.Controls.Add(label4);
                flowLayoutPanel.Controls.Add(label5);
                Panel.Controls.Add(flowLayoutPanel);
            }

            Event.RefreshPanel(Panel);

        }
    }
}
