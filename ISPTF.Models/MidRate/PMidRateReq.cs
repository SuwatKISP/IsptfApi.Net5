using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.MidRate
{
    public class PMidRateReq
    {
        public DateTime Rate_Date { get; set; }
        public string Rate_Time { get; set; }
        public string Rate_Ccy { get; set; }


    }
}
