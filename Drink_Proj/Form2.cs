using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drink_Proj
{
    public partial class subForm : BaseForm
    {
        public subForm(BtnData drink)
        {
            InitializeComponent();
            Bind();
            //註冊計算價格事件
            this.TotalMoney += new MoneyCalculate(GetPrice);
            confirm.DialogResult = DialogResult.OK;
            Money = drink.Price;
            this.drink = drink;
        }
        //傳進來的飲料物件
        public BtnData drink { get; set; }
        //
        private BtnData btnData;
        //總價
        public int Money { get; set; }
        //數量
        private int Amount = 1;
        //用來插入 ListViewItem
        public string[] lvItem { get; set; }
        //配料名稱
        public string subname { get; set; }

        public override void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btnData = btnDatas.Where(x => x.Text == btn.Text).SingleOrDefault();
            subname = "+" + btnData.Text;
        }
        //計算價錢
        public void GetPrice(int price)
        {
            Money = (drink.Price + price) * Amount;
        }
        //關掉視窗時，存ListViewItem 字串[]
        private void confirm_Click(object sender, EventArgs e)
        {
            DoCalculate(btnData?.Price ?? 0);//if nul that 0
        }
    }
}
