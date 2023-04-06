//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class InsGrdShareRsp
    {
        public string ShareCustomer { get; set; }
        public string Share_Imp { get; set; }
        public string Share_Exp { get; set; }
        public string Share_Dlc { get; set; }
        public string Share_LG { get; set; }
        public double Share_Credit { get; set; }
        public string Share_CCS  { get; set; }
        public string ShareCust_Code { get; set; }
        public string ShareCust_Name { get; set; }

    }
}
