using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Drink_Proj
{
    public partial class Form3 : BaseForm
    {
        public Form3(BtnData drink)
        {
            InitializeComponent();
            this.drink = drink;
            this.TotalMoney += new MoneyCalculate(GetPrice);
            //先這樣
            List<string> a = new List<string>();
            listType.AddRange(drink.Sugar.ToList() ?? a);
            listType.AddRange(drink.Ice.ToList());
            listType.AddRange(drink.Size.ToList());
            confirm.DialogResult = DialogResult.OK;
            Bind();
        }
        
        BtnData drink = new BtnData();
        private BtnData btnData;
        private List<string> listType = new List<string>();
        private int Amount = 1;
        //用來插入 ListViewItem
        public string[] lvItem { get; set; }
        public int Money { get; set; }
        public int iTotalPrice { get; set; }
        public int iSizePrice { get; set; }
        public string sform2subname { get; set; }

        //存放選取的屬性
        string sDrinkIce;
        string sDrinkSugar;
        string sDrinkSize;
        private new void Bind()
        {
            foreach (var groupBox in this.FindForm().Controls.OfType<GroupBox>())
                SetButtonEvent(groupBox);
        }
        private void SetButtonEvent(Control control)
        {
            var button = control.Controls.OfType<Button>().OrderBy(x => x.TabIndex).ToList();
            //綁定事件
            button.ForEach(x => {
                x.Click += new EventHandler(Button_Click);      
                x.Enabled = listType?.Contains<string>(x.Text) ?? false; //判斷是否有這屬性
            });
        }

        public override void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            sDrinkIce = btn.Parent.Name == "gIce" ? btn.Text : sDrinkIce;
            sDrinkSugar = btn.Parent.Name == "gSugar" ? btn.Text : sDrinkSugar;
            sDrinkSize = btn.Parent.Name == "gSize" ? btn.Text : sDrinkSize ;
            if(!string.IsNullOrEmpty(sDrinkSize))
            {
                switch (sDrinkSize)
                {
                    case "特大": iSizePrice = 10; break;
                    case "大杯": iSizePrice = 5; break;
                    case "中杯": iSizePrice = 0; break;
                }
            }
            ChangColor(btn.Text, btn.Parent);
        }
        
        private void ChangColor(string btntext , Control control)
        {
            var button = control.Controls.OfType<Button>().ToList();
            button.ForEach(x =>
            {
                x.BackColor = x.Text == btntext ? Color.LightGreen : Color.LightSalmon;
                x.UseVisualStyleBackColor = x.Text == btntext ? false : true;
            });
        }
        private void confirm_Click(object sender, EventArgs e)
        {
            DoCalculate(btnData?.Price ?? 0);//if nul that 0
            lvItem = new string[] {
                drink.Text + sform2subname + "   " + sDrinkSugar + sDrinkIce + "  " + sDrinkSize,
                textBox1.Text,
                iTotalPrice.ToString() };
        }
        public void GetPrice(int price)
        {
            iTotalPrice = (drink.Price + price + iSizePrice + Money) * Amount;
        }
        //數量+1
        private void up_Click(object sender, EventArgs e)
        {
            Amount += 1;
            textBox1.Text = Amount.ToString();
        }
        //數量-1
        private void down_Click(object sender, EventArgs e)
        {
            Amount = Amount > 1 ? Amount - 1 : 1;
            textBox1.Text = Amount.ToString();
        }

        private void Btnsubfrm_Click(object sender, EventArgs e)
        {
            subForm form2 = new subForm(drink);
            if (form2.ShowDialog() == DialogResult.OK)
            {
                sform2subname = form2.subname;
                this.Money = form2.Money;
            }
        }
    }
}
