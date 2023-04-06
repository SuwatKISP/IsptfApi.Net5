using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ExportBC
{
    public class Q_EXBCIssueEditPageRsp

    {
        public int rCount { get; set; }
        public string exporT_BC_NO { get; set; }
        public string cust_Name { get; set; }
        public string drafT_CCY { get; set; }
        public string negO_AMT { get; set; }
        public string tenoR_TYPE { get; set; }
        public string evenT_TYPE { get; set; }
        public string recorD_TYPE { get; set; }
        public string reC_STATUS { get; set; }
        public string useR_ID { get; set; }
        public string collecT_AGENT { get; set; }
        public int evenT_NO { get; set; }
        public DateTime? EVENT_DATE { get; set; }
    }
}
