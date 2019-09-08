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
    public partial class MainForm : BaseForm
    {
        int iTotalPrice = 0;
        public MainForm()
        {
            InitializeComponent();
            Bind();
            //註冊計算價格事件
            this.TotalMoney += new MoneyCalculate(GetPrice);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 500);
        }

        public override void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            BtnData btnData = btnDatas.Where(x => x.Text == btn.Text).SingleOrDefault();
            if (btnData == null)
                return;
            //subForm form2 = new subForm(btnData);
            DrinkData drinkdata = new DrinkData(btnData);
            Form2 form2 = new Form2(drinkdata);
            this.Enabled = false;
            if(form2.ShowDialog() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(form2.lvItem);
                listView1.Items.Add(lvi);
                DoCalculate(form2.Money);
            }
            this.Enabled = true;
        }
        private void BtnBuy_Click(object sender, EventArgs e)
        {
            
        }
        public void GetPrice(int price)
        {
            iTotalPrice += price;
            txtTotalPrice.Text = iTotalPrice.ToString();
        }
    }
}
