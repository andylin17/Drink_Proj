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
        NewButton[] Btns;
        int iListCount = 0;
        int iTotalPrice = 0;
        public MainForm()
        {
            InitializeComponent();
            Bind(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 500);

            for (int i = 0; i < 100; i++)
            {
                // Start Update
                listView1.BeginUpdate();
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "";
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                //lvi.SubItems.Add("");
                listView1.Items.Add(lvi);
                // End Update
                listView1.EndUpdate();

            }
        }

        public override void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            BtnData btnData = btnDatas.Where(x => x.Name == btn.Name).SingleOrDefault();

        }
        private void BtnBuy_Click(object sender, EventArgs e)
        {

        }
    }
}
