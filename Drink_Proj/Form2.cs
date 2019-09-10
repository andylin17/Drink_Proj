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
    public partial class Form2 : BaseForm
    {
        public Form2(DrinkData drink)
        {
            InitializeComponent();
            this.drink = drink;
            //先這樣
            //List<string> a = new List<string>();
            //listType.AddRange(drink.Sugar.ToList() ?? a);
            //listType.AddRange(drink.Ice.ToList());
            //listType.AddRange(drink.Size.ToList());
            confirm.DialogResult = DialogResult.OK;
            Bind();
            //註冊計算價格事件
            this.TotalMoney += new MoneyCalculate(GetPrice);
        }

        DrinkData drink;
        private BtnData proData;
        public subForm form2 { get; set; }

        //private new void Bind()
        //{
        //    foreach (var groupBox in this.FindForm().Controls.OfType<GroupBox>())
        //        SetButtonEvent(groupBox);
        //}
        //private void SetButtonEvent(Control control)
        //{
        //    var button = control.Controls.OfType<Button>().OrderBy(x => x.TabIndex).ToList();
        //    //綁定事件
        //    button.ForEach(x => {
        //        x.Click += new EventHandler(Button_Click);      
        //        x.Enabled = listType?.Contains<string>(x.Text) ?? false; //判斷是否有這屬性
        //    });
        //}

        //public override void Button_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    proData = btnDatas.Where(x => x.Text == btn.Text).SingleOrDefault();
        //    sDrinkIce = btn.Parent.Name == "gIce" ? btn.Text : sDrinkIce;
        //    sDrinkSugar = btn.Parent.Name == "gSugar" ? btn.Text : sDrinkSugar;
        //    sDrinkSize = btn.Parent.Name == "gSize" ? btn.Text : sDrinkSize ;
        //    if(!string.IsNullOrEmpty(sDrinkSize))
        //    {
        //        switch (sDrinkSize)
        //        {
        //            case "特大": iSizePrice = 10; break;
        //            case "大杯": iSizePrice = 5; break;
        //            case "中杯": iSizePrice = 0; break;
        //        }
        //    }
        //    ChangColor(btn.Text, btn.Parent);
        //}

        public override void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            proData = btnDatas.Where(x => x.Text == btn.Text).SingleOrDefault();
            //反射方法 設定屬性
            var property = drink.GetType().GetProperty(proData.Group);
            property.SetValue(drink,proData.Text);
            drink.sizePrice = proData.Price == 0 ? drink.sizePrice : proData.Price;
            //////end
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
            //lvItem = new string[] {
            //    drink.Text + sform2subname + "   " + sDrinkSugar + sDrinkIce + "  " + sDrinkSize,
            //    textBox1.Text,
            //    iTotalPrice.ToString()
            //};
        }
        //數量+1
        private void up_Click(object sender, EventArgs e)
        {
            drink.Amount += 1;
            textBox1.Text = drink.Amount.ToString();
        }
        //數量-1
        private void down_Click(object sender, EventArgs e)
        {
            drink.Amount = drink.Amount > 1 ? drink.Amount - 1 : 1;
            textBox1.Text = drink.Amount.ToString();
        }

        private void Btnsubfrm_Click(object sender, EventArgs e)
        {
            form2 = new subForm(drink);
            form2.ShowDialog();
            //if (form2.ShowDialog() == DialogResult.OK)
            //{
            //    sform2subname = form2.subname;
            //    this.Money = form2.Money;
            //}
        }
        public void GetPrice()
        {
            drink.Price = (drink.Price + drink.sizePrice + drink.stuffprice) * drink.Amount;
        }

    }
}
