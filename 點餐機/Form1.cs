using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 點餐機.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static 點餐機.Models.MenuModel;

namespace 點餐機
{
    public partial class Form1 : Form
    {
      
        string remark;
        public Form1()
        {
            InitializeComponent();
            Event.NotifyRenderhPanel += ReceivePanel;
        }


        public void ReceivePanel(object sender, FlowLayoutPanel e)
        {
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel5.Controls.Add(e);
            //decimal totalPrice = e.Sum(x => x.Price);
            totalLab.Text= Order.GetSubtotal().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           string path = ConfigurationManager.AppSettings["Menupath"];
           string json = File.ReadAllText(path, Encoding.UTF8);
           MenuModel models =JsonConvert.DeserializeObject<MenuModel>(json);

            for (int i = 0; i < models.MenuList.Length; i++)
            {
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                Label label = new Label();
                label.Text = models.MenuList[i].Type;
                FlowLayoutPanel menus = new FlowLayoutPanel();
                menus.HorizontalScroll.Maximum = 0;
                menus.AutoScroll = false;
                menus.VerticalScroll.Visible = false;
                menus.AutoScroll = true;
                string[] foods = models.MenuList[i].Food.Select(food => $"{food.Name}${food.Price}").ToArray();
                menus.SetFoods(foods, Checkbox_CheckedChanged, NumericUpDown_ValueChanged);
                flowLayoutPanel.Controls.Add(label);
                flowLayoutPanel.Controls.Add(menus);
                menuContainer.Controls.Add(flowLayoutPanel);
                //menuContainer.BorderStyle = BorderStyle.FixedSingle;
                //flowLayoutPanel.BorderStyle=BorderStyle.FixedSingle;
                flowLayoutPanel.Width = 170;
                flowLayoutPanel.Height = 200;
                menus.Height = 140;
                
                //menus.Width = 70;
            }


            // 品名 單價 數量 小計 備註
            //GenerateItem("品名", "單價", "數量", "小計", "備註");

            // 建立折扣下拉選單
            //三寶飯買2送1
            //雞排飯搭紅茶$100
            //排骨飯買三個$200
            //雞腿飯買5個打8折
            //每買兩個咖哩飯送薯條
            //咖哩飯加購地瓜球$100
            //消費滿額300折扣30
            //全場消費打85折
            //排骨飯加購炸湯圓$100
            //飲料任選三杯$50

            //List<KeyValueModel> list = new List<KeyValueModel>();
            #region for迴圈的寫法
            //for (int i = 0; i < models.DiscountList.Length; i++)
            //{
            //    string Namelist = models.DiscountList[i].Name;
            //    string Strategylist = models.DiscountList[i].StrategyName;
            //    list.Add(new KeyValueModel(Namelist, Strategylist));
            //}
            #endregion
            List<KeyValueModel> list = models.DiscountList.Select(x=>new KeyValueModel(x.Name,x)).ToList();

            //List<KeyValueModel> list = new List<KeyValueModel>()
            //{
            //    new KeyValueModel("三寶飯買2送1","點餐機.Discounts.ThreeTreasuresRiceBuy2Get1Free"),
            //    new KeyValueModel("雞排飯搭紅茶$100","點餐機.Discounts.ChickenFilletRiceWithRedTea100"),
            //    new KeyValueModel("排骨飯買三個$200","點餐機.Discounts.PorkChopRiceBuy3For200"),
            //    new KeyValueModel("雞腿飯買5個打8折","點餐機.Discounts.ChickenLegRiceBuy5Get20PercentOff"),
            //    new KeyValueModel("每買兩個咖哩飯送薯條","點餐機.Discounts.Buy2CurryRiceGetFreeFries"),
            //    new KeyValueModel("咖哩飯加購地瓜球$100","點餐機.Discounts.CurryRiceAddSweetPotatoBalls100"),
            //    new KeyValueModel("消費滿額300折扣30","點餐機.Discounts.SpendOver300Get30Discount"),
            //    new KeyValueModel("全場消費打85折","點餐機.Discounts.Get15PercentOffAllPurchases"),
            //    new KeyValueModel("排骨飯加購炸湯圓$100","點餐機.Discounts.PorkChopRiceAddFriedGlutinousRiceBalls100"),
            //    new KeyValueModel("飲料任選三杯$50","點餐機.Discounts.Any3DrinksFor50"),
            //    new KeyValueModel(" ","點餐機.Discounts.NoneDiscount")
            //};

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";

            #region 舊方法
            //createfood(mainfoods, flowLayoutPanel1);
            //createfood(sidefoods, flowLayoutPanel2);
            //createfood(drink, flowLayoutPanel3);
            //createfood(dessert, flowLayoutPanel4);
            #endregion
        }

        public void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            CheckBox checkbox = (CheckBox)numericUpDown.Parent.Controls[0];
            checkbox.Checked = numericUpDown.Value == 0 ? false : true;
            Item item = new Item(checkbox.Text.Split('$')[0].ToString(), int.Parse(checkbox.Text.Split('$')[1]), (int)numericUpDown.Value, remark);
            Order.AddOrder(item, (Discountlist)comboBox1.SelectedValue);

        }

        public void Checkbox_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox checkbox = (CheckBox)sender;
            NumericUpDown numericUpDown = (NumericUpDown)checkbox.Parent.Controls[1];
            numericUpDown.Value = checkbox.Checked == true ? 1 : 0;
            Item item = new Item(checkbox.Text.Split('$')[0].ToString(), int.Parse(checkbox.Text.Split('$')[1]), (int)numericUpDown.Value, remark);
            Order.AddOrder(item, (Discountlist)comboBox1.SelectedValue);
            Console.WriteLine(comboBox1.Text);

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
