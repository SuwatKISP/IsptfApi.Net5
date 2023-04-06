//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBC
{
    public class PIMBC_CollectRefund_Update_Req
    {
        public string? Allocation { get; set; }
        public double? BCAmount { get; set; }
        public double? BCBalance { get; set; }
        public string? BCCcy { get; set; }
        public string? BCNumber { get; set; }
        public int? BCSeqno { get; set; }
        public string? BCStatus { get; set; }
        public string? BCType { get; set; }
        public double? CableAmt { get; set; }
        public string? CenterID { get; set; }
        public double? CommLieu { get; set; }
        public double? CommOther { get; set; }
        public string? CustAddr { get; set; }
        public string? CustCode { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public double? DutyAmt { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public double? IBCComm { get; set; }
        public string? Inuse { get; set; }
        public string? PayFlag { get; set; }
        public string? paymethod { get; set; }
        public string? payremark { get; set; }
        public double? PostageAmt { get; set; }
        public double? ProtestAmt { get; set; }
        public string? RecStatus { get; set; }
        public string? RecType { get; set; }
        public double? TaxAmt { get; set; }
        public string? TaxRefund { get; set; }

    }
}

//param.Add("@Allocation", pimbcupdate.Allocation);
//param.Add("@BCAmount", pimbcupdate.BCAmount);
//param.Add("@BCBalance", pimbcupdate.BCBalance);
//param.Add("@BCCcy", pimbcupdate.BCCcy);
//param.Add("@BCNumber", pimbcupdate.BCNumber);
//param.Add("@BCSeqno", pimbcupdate.BCSeqno);
//param.Add("@BCStatus", pimbcupdate.BCStatus);
//param.Add("@BCType", pimbcupdate.BCType);
//param.Add("@CableAmt", pimbcupdate.CableAmt);
//param.Add("@CenterID", pimbcupdate.CenterID);
//param.Add("@CommLieu", pimbcupdate.CommLieu);
//param.Add("@CommOther", pimbcupdate.CommOther);
//param.Add("@CustAddr", pimbcupdate.CustAddr);
//param.Add("@CustCode", pimbcupdate.CustCode);
//param.Add("@DateLastPaid", pimbcupdate.DateLastPaid);
//param.Add("@DutyAmt", pimbcupdate.DutyAmt);
//param.Add("@Event", pimbcupdate.Event);
//param.Add("@EventDate", pimbcupdate.EventDate);
//param.Add("@IBCComm", pimbcupdate.IBCComm);
//param.Add("@Inuse", pimbcupdate.Inuse);
//param.Add("@PayFlag", pimbcupdate.PayFlag);
//param.Add("@paymethod", pimbcupdate.paymethod);
//param.Add("@payremark", pimbcupdate.payremark);
//param.Add("@PostageAmt", pimbcupdate.PostageAmt);
//param.Add("@ProtestAmt", pimbcupdate.ProtestAmt);
//param.Add("@RecStatus", pimbcupdate.RecStatus);
//param.Add("@RecType", pimbcupdate.RecType);
//param.Add("@TaxAmt", pimbcupdate.TaxAmt);
//param.Add("@TaxRefund", pimbcupdate.TaxRefund);

