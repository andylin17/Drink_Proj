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
            listType.AddRange(drink.Sugar?.ToList());
            listType.AddRange(drink.Ice.ToList());
            listType.AddRange(drink.Size.ToList());
            Bind();
        }
        
        BtnData drink = new BtnData();
        private BtnData btnData;
        private List<string> listType = new List<string>();
        private Dictionary<string, Control> dicDrink = new Dictionary<string, Control>();
        private int Amount = 1;
        //用來插入 ListViewItem
        public string[] lvItem { get; set; }
        //配料名稱
        public string subname { get; set; }
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
                dicDrink.Add(x.Text, control); //加入字典，做Group分類
                x.Enabled = listType?.Contains<string>(x.Text) ?? false; //判斷是否有這屬性
            });
        }

        public override void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Control sGroup = FindInDictionary(btn.Text);
            sDrinkIce = sGroup.Name == "gIce" ? btn.Text : sDrinkIce;
            sDrinkSugar = sGroup.Name == "gSugar" ? btn.Text : sDrinkSugar;
            sDrinkSize = sGroup.Name == "gSize" ? btn.Text : sDrinkSize ;
            ChangColor(btn.Text, sGroup);
        }
        
        private Control FindInDictionary(string FindMe)
        {
            if (dicDrink.ContainsKey(FindMe))
            {
                return dicDrink[FindMe];
            }
            else
            {
                return null;
            }
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
            //lvItem = new string[] {
                //drink.Text + f +subname,
                //textBox1.Text,
                //Money.ToString() };
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
        }
    }
}
