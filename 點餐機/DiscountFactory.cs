using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐機.ADiscounts;
using 點餐機.Discounts;

namespace 點餐機
{
    internal class DiscountFactory
    {
        public static ADiscount CreateDiscout(string discountName)
        {
            ADiscount discount = null;
            switch (discountName)
            {
                case "飲料任選三杯$50":
                    discount = new Any3DrinksFor50();
                    break;
                case "咖哩飯買2個送薯條":
                    discount = new Buy2CurryRiceGetFreeFries();
                    break;
                case "雞排飯搭紅茶$100":
                    discount = new ChickenFilletRiceWithRedTea100();
                    break;
                case "雞腿飯買5個打8折":
                    discount = new ChickenLegRiceBuy5Get20PercentOff();
                    break;
                case "咖哩飯搭地瓜球$100":
                    discount = new CurryRiceAddSweetPotatoBalls100();
                    break;
                case "全場消費打85折":
                    discount = new Get15PercentOffAllPurchases();
                    break;
                case "排骨飯搭炸湯圓$100":
                    discount = new PorkChopRiceAddFriedGlutinousRiceBalls100();
                    break;
                case "排骨飯買3個$200":
                    discount = new PorkChopRiceBuy3For200();
                    break;
                case "消費滿$300折$30":
                    discount = new SpendOver300Get30Discount();
                    break;
                case "三寶飯買2送1":
                    discount = new ThreeTreasuresRiceBuy2Get1Free();
                    break;
                default:
                    discount = new NoneDiscount();
                    break;
            }
            return discount;
        }
    }
}
