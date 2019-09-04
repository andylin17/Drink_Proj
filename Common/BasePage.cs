using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Common
{
    public class BaseForm:Form
    {
        public delegate void MoneyCalculate(int i);

        public event MoneyCalculate TotalMoney;

        public List<BtnData> btnDatas;
        public void Bind()
        {
            btnDatas = GetBtnData();
            foreach(var groupBox in this.FindForm().Controls.OfType<GroupBox>())
                SetButtonEvent(groupBox);
        }
        private void SetButtonEvent(Control control)
        {
            //取得form下的Button控制項
            var button = control.Controls.OfType<Button>().OrderBy(x=>x.TabIndex).ToList(); 
            //綁定事件
            button.ForEach(x => { x.Click += new EventHandler(Button_Click);x.Text = GetText(control.Text,button.IndexOf(x).ToString()); });

        }
        public virtual void Button_Click(object sender, EventArgs e) { }
        /// <summary>
        /// 實例化 BtnData 物件
        /// </summary>
        /// <returns></returns>
        private List<BtnData> GetBtnData()
        {
            string json = File.ReadAllText(@"../../setbtn.json");       //read json file
            return JsonConvert.DeserializeObject<List<BtnData>>(json);  //json to object => BtnData
        }
        /// <summary>
        /// 設置Button 的 Text
        /// </summary>
        /// <param name="group">群組</param>
        /// <param name="index">Index</param>
        /// <returns>Text</returns>
        private string GetText(string group ,string index)
        {
            try
            {   //select x.Text from btnDatas as x where x.Group == group && x.Index == index
                return btnDatas.Where(x => x.Group == group && x.Index == index).Select(x => x.Text).Single();
            }
            catch
            {
                return index;//重複or 空值...回傳index
            }
        }
        /// <summary>
        /// 觸發 TotalMoney 事件
        /// </summary>
        /// <param name="price"></param>
        public void DoCalculate(int price)
        {
            TotalMoney?.Invoke(price);
        }
    }
}
