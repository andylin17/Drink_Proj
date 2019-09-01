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
    public partial class MainForm : Form
    {
        NewButton[] Btns;
        int iListCount = 0;
        int iTotalPrice = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 500);

            NewButton[] Btnlist = { btnBlackTea , btnGreenTea , 烏龍茶 ,烏龍綠茶,清茶};
            Btns = Btnlist;
            Btns[0].SetDrinkData(Btns[0].Text, 25);
            Btns[1].SetDrinkData(Btns[1].Text, 40);
            Btns[2].SetDrinkData(Btns[2].Text, 10);
            Btns[3].SetDrinkData(Btns[3].Text, 20);
            Btns[4].SetDrinkData(Btns[4].Text, 50);


            for (int i = 0; i < 100 ; i++)
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
            for (int i = 0; i < Btns.Length; i++)
            {
                Btns[i].Click += new EventHandler(BtnClick);
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {      
            for (int i = 0; i < Btns.Length; i++)
            {
                if(sender == Btns[i])
                {
                    Btns[i].iCount++;
                    if (Btns[i].bIsList == false)
                    {
                        listView1.Items[iListCount].SubItems[0].Text = Btns[i].sName;
                        listView1.Items[iListCount].SubItems[1].Text = Btns[i].iCount.ToString();
                        listView1.Items[iListCount].SubItems[2].Text = Btns[i].iPrice.ToString();
                        Btns[i].bIsList = true;
                        iListCount++;
                    }
                    else
                    {
                        ListViewItem item = listView1.FindItemWithText(Btns[i].sName);
                        int num = item.Index;
                        listView1.Items[num].SubItems[1].Text = Btns[i].iCount.ToString();
                    }
                    iTotalPrice = iTotalPrice + Btns[i].iPrice;
                    break;
                }         
            }           
            txtTotalPrice.Text = iTotalPrice.ToString(); 
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            iListCount = 0;
            iTotalPrice = 0;
            txtTotalPrice.Text = iTotalPrice.ToString();          
            for (int i = 0; i < Btns.Length; i++)
            {
                Btns[i].bIsList = false;
                Btns[i].iCount = 0;
                listView1.Items.RemoveAt(0);
            }
        }
    }
}
