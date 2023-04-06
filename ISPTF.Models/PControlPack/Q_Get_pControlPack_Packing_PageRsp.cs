using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PControlPack
{
    public class Q_Get_pControlPack_Packing_PageRsp
    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public  string ContNo { get; set; }
        public string DocCcy { get; set; }
        public double DocAmount { get; set; }
        public DateTime ContDate { get; set; }
        public string Cust_Code { get; set; }
        public string Cust_Name { get; set; }

    }
}
