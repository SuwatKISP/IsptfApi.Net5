using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferEXLC_EXLCRsp

    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string EXPORT_LC_NO { get; set; }
        public string DRAFT_CCY { get; set; }
        public double DRAFT_AMT { get; set; }
        public DateTime EVENT_DATE { get; set; }
        public string AcceptFlag { get; set; }
        public string Cust_Code { get; set; }
        public string CUST_NAME { get; set; }
    }
}
