using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ExportBC
{
    public class Q_EXBCEditPageRsp
    //2023-02-09 ใช้ใน EXBCIssuePurchaseController ทีเดียว ตอนนี้ : EXBCIssuePurchController
    {
        public int RCount { get; set; }
        public string EXPORT_BC_NO { get; set; }
        public string Cust_Name { get; set; }
        public string DRAFT_CCY { get; set; }
        public string NEGO_AMT { get; set; }
        public string TENOR_TYPE { get; set; }
        public string EVENT_TYPE { get; set; }
        public string RECORD_TYPE { get; set; }
        public string REC_STATUS { get; set; }
        public string USER_ID { get; set; }
        public string COLLECT_AGENT { get; set; }
        public string CLAIM_TYPE { get; set; }
        public int EVENT_NO { get; set; }
    }
}
