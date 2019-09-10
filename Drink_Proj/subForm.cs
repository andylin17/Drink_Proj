/*/////////////////////////////////////

    配料視窗
    獲取配料名稱、價格
/*/////////////////////////////////////
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
        public subForm(DrinkData drink)
        {
            InitializeComponent();
            Bind();
            confirm.DialogResult = DialogResult.OK;
            this.drink = drink;
        }
        //傳進來的飲料物件
        DrinkData drink; 
        //配料物件
        private BtnData stuffData;

        public override void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            stuffData = btnDatas.Where(x => x.Text == btn.Text).SingleOrDefault();
        }
        //關掉視窗時，存配料屬性
        private void confirm_Click(object sender, EventArgs e)
        {
            drink.stuffname = stuffData?.Text ?? "";
            drink.stuffprice = stuffData?.Price ?? 0;
        }
    }
}
