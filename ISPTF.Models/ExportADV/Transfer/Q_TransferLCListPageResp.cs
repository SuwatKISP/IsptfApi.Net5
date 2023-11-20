using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ExportADV
{
    public class Q_TransferLCListPageResp

    {
        public int RCount { get; set; }
        public string EXPORT_ADVICE_NO { get; set; }
        public int SEQ_TRANSFER { get; set; }
        public int EVENT_NO { get; set; }
        public string RECORD_TYPE { get; set; }
        public string REC_STATUS { get; set; }
        public string EVENT_TYPE { get; set; }
        public string BUSINESS_TYPE { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string LC_NO { get; set; }
        public string LC_Currency { get; set; }
        public string TRANSFER_ID { get; set; }
        public string TRANSFER_INFO { get; set; }
        public string TRANSFER_TYPE { get; set; }
        public string SUBSTATION_DOC { get; set; }
        public string TYPE_OF_CHARGE_TRANSFER { get; set; }
        public DateTime? TRANSFER_DATE { get; set; }
        public double? TRANSFER_AMOUNT { get; set; }
        public DateTime? PREV_EXPIRY { get; set; }
        public DateTime? TRANSFER_EXPIRY_DATE { get; set; }
        public double? TRANSFER_COM_RATE { get; set; }
        public double? TRANSFER_RATE { get; set; }
        public double? TRANSFER_COM { get; set; }
        public string TRANSFER_OTHER { get; set; }
        public double? TRANSFER_AMT_CANCEL { get; set; }
        public string REASON_OF_CANCEL { get; set; }
        public double? AMEND_COM { get; set; }
        public double? AMENDTRN_COM { get; set; }
        public double? ADVICE_COM { get; set; }
        public double? CABLE_COM { get; set; }
        public double? POSTAGE { get; set; }
        public double? CONFIRM_COM { get; set; }
        public double? OTHER_CHARGE { get; set; }
        public string PAYMENT_INSTRU { get; set; }
        public string METHOD { get; set; }
        public string RECEIPT_NO { get; set; }
        public double? TOTAL_CHARGE { get; set; }
        public double? REFUND_TAX { get; set; }
        public string PAY_REFUND { get; set; }
        public double? TOTAL_AMOUNT { get; set; }
        public string USER_ID { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string AUTH_CODE { get; set; }
        public DateTime? AUTH_DATE { get; set; }
        public string VOUCH_ID { get; set; }
        public string IN_Use { get; set; }
        public string GENACC_FLAG { get; set; }
        public DateTime? GENACC_DATE { get; set; }
        public string STATUS { get; set; }
        public string ALLOCATION { get; set; }
        public string REMARK { get; set; }
        public string CenterID { get; set; }
    }
}
