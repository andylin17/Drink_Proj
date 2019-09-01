using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class NewButton : System.Windows.Forms.Button
    {
        public string sName;
        public int iPrice;
        public int iCount = 0;
        public bool bIsList = false; 
        public void SetDrinkData(string name,int price)
        {
            sName = name;
            iPrice = price;
        }
    }
}
