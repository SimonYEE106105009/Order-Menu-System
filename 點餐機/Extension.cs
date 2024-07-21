using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐機
{
    internal static class Extension
    {
        public static int GetPrice(this string item)
        {
            int price = int.Parse(item.Split('$')[1]);
            return price;
        }

        public static void SetFoods(this FlowLayoutPanel flowLayoutPanel, string[] food, EventHandler Checkbox_CheckedChanged, EventHandler NumericUpDown_ValueChanged)
        {
            for (int i = 0; i < food.Length; i++)
            {
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Height = 30;
                CheckBox checkBox = new CheckBox();
                checkBox.CheckedChanged += Checkbox_CheckedChanged;
                checkBox.Width = 100;

                checkBox.Text = food[i].ToString();
                panel.Controls.Add(checkBox);
                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.ValueChanged += NumericUpDown_ValueChanged;

                numericUpDown.Width = 50;
                panel.Controls.Add(numericUpDown);
                flowLayoutPanel.Controls.Add(panel);
            }
        }


    }
}
