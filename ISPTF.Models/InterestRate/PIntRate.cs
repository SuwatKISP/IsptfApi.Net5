using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.InterestRate
{
    public class PIntRate
    {
        public string IRate_Code { get; set; }
        public DateTime IRate_EffDate { get; set; }
        public string IRate_EffTime { get; set; }
        public double IRate_Rate { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }

    }
}
