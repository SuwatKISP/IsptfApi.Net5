using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MCurrency
    {
        public string ccy_Code { get; set; }
        public string ccy_Name { get; set; }
        public int ccy_Base { get; set; }
        public string ccy_GE { get; set; }
        public string ccy_GEC { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public string userCode { get; set; }
        public string ccy_SWDEC { get; set; }
    }
}
