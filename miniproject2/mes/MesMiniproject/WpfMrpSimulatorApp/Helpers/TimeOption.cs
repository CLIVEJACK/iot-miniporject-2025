using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMrpSimulatorApp.Helpers
{
    public class TimeOption
    {
        public TimeOnly Time { get; set; }  // "09:00 != 09:00 9:00 AM" 비교불가능해서 만듬 

        public string Display {  get; set; }    
    }
}
