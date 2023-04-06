using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.InterestRate
{
    public class PIntRateReq
    {
        public string IRate_Code { get; set; }
        public DateTime IRate_EffDate { get; set; }
        public string IRate_EffTime { get; set; }
    }
}
