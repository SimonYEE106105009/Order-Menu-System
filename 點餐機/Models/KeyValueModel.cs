using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static 點餐機.Models.MenuModel;

namespace 點餐機
{
    internal class KeyValueModel
    {
        public String Key { get; set; }
        public Discountlist Value { get; set; }

        public KeyValueModel(String Key, Discountlist Value) {
            this.Key = Key;
            this.Value = Value;
        }
    }
}
