using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DrinkData
    {
        public DrinkData(BtnData btn)
        {
            Index = btn.Index;
            Text = btn.Text;
            Price = btn.Price;
            Group = btn.Group;
        }
        public string Index { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public string Group { get; set; }
        public string 糖度 { get; set; }
        public string 冰塊 { get; set; }
        public string 大小 { get; set; }
        public string stuffname { get; set; }
        public int stuffprice { get; set; }
    }
}
