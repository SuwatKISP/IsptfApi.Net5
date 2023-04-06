using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MCustRateDefault
    {
        public string Def_Cust { get; set; }
        public string Def_Mod { get; set; }
        public string Def_Exp { get; set; }
        public string Def_Type {get; set;}
        public double Def_Rate{get; set;}
        public double Def_Min { get; set; }
        public double Def_Max { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }
        public string RecStatus { get; set; }

    }
}
