using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferPacking_AMPCRsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string PACKING_NO { get; set; }
        public string CCY { get; set; }
        public double PackingAmount { get; set; }
        public DateTime Event_Date { get; set; }
        public string Cust_Code { get; set; }
        public string Cust_Name { get; set; }

    }
}
