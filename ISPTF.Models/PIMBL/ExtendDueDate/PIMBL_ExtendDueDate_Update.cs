//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMBL
{
    public class PIMBL_ExtendDueDate_Update_Req
    {
        public string? BLNumber { get; set; }
        public string? AdNumber { get; set; }
        public string? RecType { get; set; }
        public int? BLSeqno { get; set; }
        public string? BLStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? eventdate { get; set; }
        public string? LCNumber { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? TenorType { get; set; }
        public int? TenorTerm { get; set; }
        //public string? TenorTerm { get; set; }
        public string? BLCcy { get; set; }
        public double? blAmount { get; set; }
        public double? blbalance { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? IntStartDate { get; set; }
        public double? exchrate { get; set; }
        public double? EngageRate { get; set; }
        public double? EngageComm { get; set; }
        public double? CableAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? CommOther { get; set; }
        public string? TaxRefund { get; set; }
        public string? PayFlag { get; set; }
        public string? paymethod { get; set; }
        public string? Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? payremark { get; set; }
        public string? CenterID { get; set; }
        public string? InUse { get; set; }


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
//param.Add("@CustCode", pimblupdate.CustCode);
//param.Add("@CustAddr", pimblupdate.CustAddr);
//param.Add("@TenorType", pimblupdate.TenorType);
//param.Add("@TenorTerm", pimblupdate.TenorTerm);
//param.Add("@TenorTerm", pimblupdate.TenorTerm);
//param.Add("@BLCcy", pimblupdate.BLCcy);
//param.Add("@blAmount", pimblupdate.blAmount);
//param.Add("@blbalance", pimblupdate.blbalance);
//param.Add("@StartDate", pimblupdate.StartDate);
//param.Add("@DueDate", pimblupdate.DueDate);
//param.Add("@IntStartDate", pimblupdate.IntStartDate);
//param.Add("@exchrate", pimblupdate.exchrate);
//param.Add("@EngageRate", pimblupdate.EngageRate);
//param.Add("@EngageComm", pimblupdate.EngageComm);
//param.Add("@CableAmt", pimblupdate.CableAmt);
//param.Add("@PayableAmt", pimblupdate.PayableAmt);
//param.Add("@CommOther", pimblupdate.CommOther);
//param.Add("@TaxRefund", pimblupdate.TaxRefund);
//param.Add("@PayFlag", pimblupdate.PayFlag);
//param.Add("@paymethod", pimblupdate.paymethod);
//param.Add("@Allocation", pimblupdate.Allocation);
//param.Add("@DateLastPaid", pimblupdate.DateLastPaid);
//param.Add("@LastReceiptNo", pimblupdate.LastReceiptNo);
//param.Add("@payremark", pimblupdate.payremark);
//param.Add("@CenterID", pimblupdate.CenterID);
//param.Add("@InUse", pimblupdate.InUse);
