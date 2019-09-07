using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DrinkData : BtnData
    {
        public enum Suger
        {
            regular = 10,
            less = 7,
            half = 5,
            light = 3,
            non = 0
        }
        public enum Ice
        {
            regular = 10,
            less = 7,
            half = 5,
            light = 3,
            non = 0
        }
    }
}