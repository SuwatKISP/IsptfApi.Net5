using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterReferEXBC_EXBC_SelectRsp

    {
        public string EXPORT_BC_NO { get; set; }
        public DateTime EVENT_DATE { get; set; }
        public string REFER_BC_NO { get; set; }
        public string BENE_ID { get; set; }
        public string BENE_INFO { get; set; }
        public string INVOICE { get; set; }
        public string Refer1 { get; set; }
        public string DRAFT_CCY { get; set; }
        public double DRAFT_AMT { get; set; }
        public string TENOR_TYPE { get; set; }
        public string TENOR_OF_COLL { get; set; }
        public double SIGHT_AMT {get; set;}
        public double TERM_AMT {get; set;}
        public double TOT_NEGO_AMT { get; set; }
        public DateTime TERM_DUE_DATE { get; set; }

    }
}
