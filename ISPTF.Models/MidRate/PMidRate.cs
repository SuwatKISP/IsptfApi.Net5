using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.MidRate
{
    public class PMidRate
    {
        public DateTime Rate_Date { get; set; }
        public string Rate_Time { get; set; }
        public string Rate_Ccy { get; set; }
        public double? Rate_MidRate { get; set; }
        public double? Rate_Reuter { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }
        //public string UpdateDate { get; set; }
        //public string AuthDate { get; set; }


    }
}
