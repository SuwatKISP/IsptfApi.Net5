//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class PDOMLC_CollectRefundCharges_Update_Req
    {
        public string? DLCNumber { get; set; }
        public string? RecType { get; set; }
        public int? DLCSeqno { get; set; }
        public string? DLCStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? RecStatus { get; set; }
        public string? InUse { get; set; }
        public string? DLCCcy { get; set; }
        public double? DLCAmt { get; set; }
        public double? DLCBal { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? taxrefund { get; set; }
        public double? CableMail { get; set; }
        public double? CommAmt { get; set; }
        public double? DutyStamp { get; set; }
        public double? PayableStamp { get; set; }
        public double? OthCharge { get; set; }
        public double? TaxAmt { get; set; }
        public string? PayFlag { get; set; }
        public string? paymethod { get; set; }
        public string? PayRemark { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? appvno { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public string? Allocation { get; set; }
        public string? CenterID { get; set; }


    }
}

//param.Add("@DLCNumber", pimdomlcupdate.DLCNumber);
//param.Add("@RecType", pimdomlcupdate.RecType);
//param.Add("@DLCSeqno", pimdomlcupdate.DLCSeqno);
//param.Add("@DLCStatus", pimdomlcupdate.DLCStatus);
//param.Add("@Event", pimdomlcupdate.Event);
//param.Add("@EventDate", pimdomlcupdate.EventDate);
//param.Add("@RecStatus", pimdomlcupdate.RecStatus);
//param.Add("@InUse", pimdomlcupdate.InUse);
//param.Add("@DLCCcy", pimdomlcupdate.DLCCcy);
//param.Add("@DLCAmt", pimdomlcupdate.DLCAmt);
//param.Add("@DLCBal", pimdomlcupdate.DLCBal);
//param.Add("@CustCode", pimdomlcupdate.CustCode);
//param.Add("@CustAddr", pimdomlcupdate.CustAddr);
//param.Add("@taxrefund", pimdomlcupdate.taxrefund);
//param.Add("@CableMail", pimdomlcupdate.CableMail);
//param.Add("@CommAmt", pimdomlcupdate.CommAmt);
//param.Add("@DutyStamp", pimdomlcupdate.DutyStamp);
//param.Add("@PayableStamp", pimdomlcupdate.PayableStamp);
//param.Add("@OthCharge", pimdomlcupdate.OthCharge);
//param.Add("@TaxAmt", pimdomlcupdate.TaxAmt);
//param.Add("@PayFlag", pimdomlcupdate.PayFlag);
//param.Add("@paymethod", pimdomlcupdate.paymethod);
//param.Add("@PayRemark", pimdomlcupdate.PayRemark);
//param.Add("@DateLastPaid", pimdomlcupdate.DateLastPaid);
//param.Add("@LastReceiptNo", pimdomlcupdate.LastReceiptNo);
//param.Add("@appvno", pimdomlcupdate.appvno);
//param.Add("@UpdateDate", pimdomlcupdate.UpdateDate);
//param.Add("@UserCode", pimdomlcupdate.UserCode);
//param.Add("@Allocation", pimdomlcupdate.Allocation);
//param.Add("@CenterID", pimdomlcupdate.CenterID);
