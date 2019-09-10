/*/////////////////////////////////////

    主視窗

/*/////////////////////////////////////
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
        DrinkData drinkdata;
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
            //創建 飲料物件
            drinkdata = new DrinkData(btnData);
            Form2 form2 = new Form2(drinkdata);
            this.Enabled = false;
            if(form2.ShowDialog() == DialogResult.OK)
            {
                //ListViewItem lvi = new ListViewItem(form2.lvItem);
                //listView1.Items.Add(lvi);
                SetList();
                DoCalculate();
            }
            this.Enabled = true;
        }
        /// <summary>
        /// 總價計算
        /// </summary>
        public void GetPrice()
        {
            iTotalPrice += drinkdata.Price;
            txtTotalPrice.Text = iTotalPrice.ToString();
        }
        /// <summary>
        /// listView add item
        /// </summary>
        public void SetList()
        {
            ListViewItem item = new ListViewItem(new string[]
            {
                drinkdata.Text + (string.IsNullOrEmpty(drinkdata.stuffname)?"":"+"+drinkdata.stuffname),
                drinkdata.糖度,
                drinkdata.冰塊,
                drinkdata.大小,
                drinkdata.Amount.ToString(),
                drinkdata.Price.ToString()
            });
            listView1.Items.Add(item);
        }
        //關閉釋放資源
        public override void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
