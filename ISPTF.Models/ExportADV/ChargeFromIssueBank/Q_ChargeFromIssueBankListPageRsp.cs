using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ExportADV
{
    public class Q_ChargeFromIssueBankListPageRsp

    {
        public int RCount { get; set; }
        public string? EXPORT_ADVICE_NO { get; set; }
        public string? LC_NO { get; set; }
        public string? BENEFICIARY_ID { get; set; }
        public string? BENEFICIARY_INFO { get; set; }
        public string? LC_CURRENCY { get; set; }
        public double? LC_AMOUNT { get; set; }
        public string? EVENT_TYPE { get; set; }
        public string? RECORD_TYPE { get; set; }
        public string? REC_STATUS { get; set; }
        public int? EVENT_NO { get; set; }
        public DateTime? EVENT_DATE { get; set; }

    }
}
