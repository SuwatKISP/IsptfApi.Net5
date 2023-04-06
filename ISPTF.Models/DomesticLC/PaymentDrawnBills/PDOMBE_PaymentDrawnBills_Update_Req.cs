//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class PDOMBE_PaymentDrawnBills_Update_Req
    {
        public string? BENumber { get; set; }
        public string? RecType { get; set; }
        public int? BESeqno { get; set; }
        public string? BEStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? DLCNumber { get; set; }
        public string? DocCcy { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? TenorType { get; set; }
        public string? BECcy { get; set; }
        public double? BEBalance { get; set; }
        public double? BEOverDrawn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public double? IntBefore { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? IntBalance { get; set; }
        public double? exchrate { get; set; }
        public double? OverAmt { get; set; }
        public double? NegoAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? CommOther { get; set; }
        public double? CommTran { get; set; }
        public double? CommCertify { get; set; }
        public double? CommEngage { get; set; }
        public double? Discfee { get; set; }
        public string? taxrefund { get; set; }
        public double? TaxAmt { get; set; }
        public string? CommDesc { get; set; }
        public string? PaymentFlag { get; set; }
        public double? payBalance { get; set; }
        public double? payinterest { get; set; }
        public string? PayFlag { get; set; }
        public string? paymethod { get; set; }
        public string? Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? UserCode { get; set; }
        public DateTime? DateToStop { get; set; }
        public string? CenterID { get; set; }
        public string? SwFlag { get; set; }

    }
}

//param.Add("@BENumber", pimdombeupdate.BENumber);
//param.Add("@RecType", pimdombeupdate.RecType);
//param.Add("@BESeqno", pimdombeupdate.BESeqno);
//param.Add("@BEStatus", pimdombeupdate.BEStatus);
//param.Add("@RecStatus", pimdombeupdate.RecStatus);
//param.Add("@Event", pimdombeupdate.Event);
//param.Add("@EventDate", pimdombeupdate.EventDate);
//param.Add("@DLCNumber", pimdombeupdate.DLCNumber);
//param.Add("@DocCcy", pimdombeupdate.DocCcy);
//param.Add("@CustCode", pimdombeupdate.CustCode);
//param.Add("@CustAddr", pimdombeupdate.CustAddr);
//param.Add("@TenorType", pimdombeupdate.TenorType);
//param.Add("@BECcy", pimdombeupdate.BECcy);
//param.Add("@BEBalance", pimdombeupdate.BEBalance);
//param.Add("@BEOverDrawn", pimdombeupdate.BEOverDrawn);
//param.Add("@StartDate", pimdombeupdate.StartDate);
//param.Add("@DueDate", pimdombeupdate.DueDate);
//param.Add("@IntBefore", pimdombeupdate.IntBefore);
//param.Add("@IntRateCode", pimdombeupdate.IntRateCode);
//param.Add("@intrate", pimdombeupdate.intrate);
//param.Add("@IntSpread", pimdombeupdate.IntSpread);
//param.Add("@IntBaseDay", pimdombeupdate.IntBaseDay);
//param.Add("@IntStartDate", pimdombeupdate.IntStartDate);
//param.Add("@LastIntDate", pimdombeupdate.LastIntDate);
//param.Add("@LastIntAmt", pimdombeupdate.LastIntAmt);
//param.Add("@IntBalance", pimdombeupdate.IntBalance);
//param.Add("@exchrate", pimdombeupdate.exchrate);
//param.Add("@OverAmt", pimdombeupdate.OverAmt);
//param.Add("@NegoAmt", pimdombeupdate.NegoAmt);
//param.Add("@CableAmt", pimdombeupdate.CableAmt);
//param.Add("@PostageAmt", pimdombeupdate.PostageAmt);
//param.Add("@DutyAmt", pimdombeupdate.DutyAmt);
//param.Add("@PayableAmt", pimdombeupdate.PayableAmt);
//param.Add("@CommOther", pimdombeupdate.CommOther);
//param.Add("@CommTran", pimdombeupdate.CommTran);
//param.Add("@CommCertify", pimdombeupdate.CommCertify);
//param.Add("@CommEngage", pimdombeupdate.CommEngage);
//param.Add("@Discfee", pimdombeupdate.Discfee);
//param.Add("@taxrefund", pimdombeupdate.taxrefund);
//param.Add("@TaxAmt", pimdombeupdate.TaxAmt);
//param.Add("@CommDesc", pimdombeupdate.CommDesc);
//param.Add("@PaymentFlag", pimdombeupdate.PaymentFlag);
//param.Add("@payBalance", pimdombeupdate.payBalance);
//param.Add("@payinterest", pimdombeupdate.payinterest);
//param.Add("@PayFlag", pimdombeupdate.PayFlag);
//param.Add("@paymethod", pimdombeupdate.paymethod);
//param.Add("@Allocation", pimdombeupdate.Allocation);
//param.Add("@DateLastPaid", pimdombeupdate.DateLastPaid);
//param.Add("@LastReceiptNo", pimdombeupdate.LastReceiptNo);
//param.Add("@UserCode", pimdombeupdate.UserCode);
//param.Add("@DateToStop", pimdombeupdate.DateToStop);
//param.Add("@CenterID", pimdombeupdate.CenterID);
//param.Add("@SwFlag", pimdombeupdate.SwFlag);

