using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐機
{
    public class Item
    {
        public string Name { get; set; }   
        public int Price { get; set; } 
        public int Number { get; set; }
        public int Subtotal { get; set; }
        public string Remark { get; set; }

        public Item(string name, int price, int number)
        {
            Name = name;
            Price = price;
            Number = number;
        } 

        public Item(string name, int price, int number, string remark)
        { 
            Name = name;
            Price = price;
            Number = number;
            Subtotal = price * number;
            Remark = remark;
        }
    }
}
