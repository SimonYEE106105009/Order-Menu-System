using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐機.Strategy
{
    public interface DiscountStrategy
    {
        double ApplyDiscount(double price);
    }
}
