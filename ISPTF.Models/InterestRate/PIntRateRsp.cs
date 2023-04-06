using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.InterestRate
{
    public  class PIntRateRsp
    {
        public string IRate_Code { get; set; }
        public string InRate_Name { get; set; }
        public DateTime IRate_EffDate { get; set; }
        public string IRate_EffTime { get; set; }
        public double IRate_Rate { get; set; }
        public string RecStatus { get; set; }
        public int RCount { get; set; }
    }
}
