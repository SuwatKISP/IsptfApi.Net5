//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMBL
{
    public class PIMBL_CollectRefundChanges_Update_Req
    {

        public string? BLNumber { get; set; }
        public string? AdNumber { get; set; }
        public string? RecType { get; set; }
        public int? BLSeqno { get; set; }
        public DateTime? BLStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? eventdate { get; set; }
        public string? LCNumber { get; set; }
        public string? DocCcy { get; set; }
        public string? CustCode { get; set; }
        public int? CustAddr { get; set; }
        public string? CommBenCcy { get; set; }
        public double? BLCcy { get; set; }
        public double? blAmount { get; set; }
        public double? blbalance { get; set; }
        public string? FBCharge { get; set; }
        public string? FBInterest { get; set; }
        public string? PrevFBChrg { get; set; }
        public string? PrevFBint { get; set; }
        public double? OverdrawComm { get; set; }
        public double? exchrate { get; set; }
        public double? EngageComm { get; set; }
        public double? FBChargeTHB { get; set; }
        public double? FBInterestTHB { get; set; }
        public double? OpenAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public string? PayableAmt { get; set; }
        public double? CommOther { get; set; }
        public string? CommLieu { get; set; }
        public string? TaxRefund { get; set; }
        public string? TaxAmt { get; set; }
        public double? CommDesc { get; set; }
        public double? PayFlag { get; set; }
        public string? paymethod { get; set; }
        public string? Allocation { get; set; }
        public string? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? CenterID { get; set; }

    }
}

//param.Add("@BLNumber", pimblupdate.BLNumber);
//param.Add("@AdNumber", pimblupdate.AdNumber);
//param.Add("@RecType", pimblupdate.RecType);
//param.Add("@BLSeqno", pimblupdate.BLSeqno);
//param.Add("@BLStatus", pimblupdate.BLStatus);
//param.Add("@RecStatus", pimblupdate.RecStatus);
//param.Add("@Event", pimblupdate.Event);
//param.Add("@eventdate", pimblupdate.eventdate);
//param.Add("@LCNumber", pimblupdate.LCNumber);
//param.Add("@DocCcy", pimblupdate.DocCcy);
//param.Add("@CustCode", pimblupdate.CustCode);
//param.Add("@CustAddr", pimblupdate.CustAddr);
//param.Add("@CommBenCcy", pimblupdate.CommBenCcy);
//param.Add("@BLCcy", pimblupdate.BLCcy);
//param.Add("@blAmount", pimblupdate.blAmount);
//param.Add("@blbalance", pimblupdate.blbalance);
//param.Add("@FBCharge", pimblupdate.FBCharge);
//param.Add("@FBInterest", pimblupdate.FBInterest);
//param.Add("@PrevFBChrg", pimblupdate.PrevFBChrg);
//param.Add("@PrevFBint", pimblupdate.PrevFBint);
//param.Add("@OverdrawComm", pimblupdate.OverdrawComm);
//param.Add("@exchrate", pimblupdate.exchrate);
//param.Add("@EngageComm", pimblupdate.EngageComm);
//param.Add("@FBChargeTHB", pimblupdate.FBChargeTHB);
//param.Add("@FBInterestTHB", pimblupdate.FBInterestTHB);
//param.Add("@OpenAmt", pimblupdate.OpenAmt);
//param.Add("@CableAmt", pimblupdate.CableAmt);
//param.Add("@PostageAmt", pimblupdate.PostageAmt);
//param.Add("@DutyAmt", pimblupdate.DutyAmt);
//param.Add("@PayableAmt", pimblupdate.PayableAmt);
//param.Add("@CommOther", pimblupdate.CommOther);
//param.Add("@CommLieu", pimblupdate.CommLieu);
//param.Add("@TaxRefund", pimblupdate.TaxRefund);
//param.Add("@TaxAmt", pimblupdate.TaxAmt);
//param.Add("@CommDesc", pimblupdate.CommDesc);
//param.Add("@PayFlag", pimblupdate.PayFlag);
//param.Add("@paymethod", pimblupdate.paymethod);
//param.Add("@Allocation", pimblupdate.Allocation);
//param.Add("@DateLastPaid", pimblupdate.DateLastPaid);
//param.Add("@LastReceiptNo", pimblupdate.LastReceiptNo);
//param.Add("@CenterID", pimblupdate.CenterID);
