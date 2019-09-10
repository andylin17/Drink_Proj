/*/////////////////////////////////////

    飲料物件
    儲存所有相關屬性
    用於傳遞、計算、顯示

/*/////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DrinkData
    {
        public DrinkData(BtnData btn)//建構..取得飲料按鈕的所有屬性
        {
            var properties = btn.GetType().GetProperties().ToList();
            properties.ForEach(x => this.GetType().GetProperty(x.Name).SetValue(this, x.GetValue(btn)));
            Amount = 1;
        }
        public string Index { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public string Group { get; set; }
        public string 糖度 { get; set; }
        public string 冰塊 { get; set; }
        public string 大小 { get; set; }
        public int sizePrice { get; set; }
        public string stuffname { get; set; }
        public int stuffprice { get; set; }
        public int Amount { get; set; }
    }
}
