//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ShippingGuarantee
{
    public class PIMSG_Reverse_SG_Update_Req
    {
        public string? SGNumber { get; set; }
        public string? RecType { get; set; }
        public int? SGSeqno { get; set; }
        public string? SGStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? SupStatus { get; set; }
        public string? Event   { get; set; }
        public DateTime? Eventdate { get; set; }
        public string? LOCode { get; set; }
        public string? AOCode { get; set; }
        public string? SGMode { get; set; }
        public string? SGType { get; set; }
        public string? ReferLC { get; set; }
        public DateTime? expirydate { get; set; }
        public string? CustCode { get; set; }
        public string? beninfo { get; set; }
        public string? BLNumber { get; set; }
        public string? shipping { get; set; }
        public string? vessel { get; set; }
        public string? masterAwb { get; set; }
        public string? houseAwb { get; set; }
        public string? InvNumber { get; set; }
        public string? SGCcy { get; set; }
        public double? SGAmt { get; set; }
        public double? ExchRate { get; set; }
        public double? SGBaht { get; set; }
        public double? CommAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PenaltyAmt { get; set; }
        public double? RefundTax { get; set; }
        public string? RefundFlag { get; set; }
        public string? PayFlag { get; set; }
        public string? PayMethod { get; set; }
        public string? PayRemark { get; set; }
        public string? Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? AppvNo { get; set; }
        public string? FacNo { get; set; }
        public string? Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public string? GENACC_FLAG { get; set; }
        public string? Inuse { get; set; }
        public string? CenterID { get; set; }

    }
}

//param.Add("@SGNumber", pimsgupdate.SGNumber);
//param.Add("@RecType", pimsgupdate.RecType);
//param.Add("@SGSeqno", pimsgupdate.SGSeqno);
//param.Add("@SGStatus", pimsgupdate.SGStatus);
//param.Add("@RecStatus", pimsgupdate.RecStatus);
//param.Add("@SupStatus", pimsgupdate.SupStatus);
//param.Add("@event", pimsgupdate.event);
//param.Add("@Eventdate", pimsgupdate.Eventdate);
//param.Add("@LOCode", pimsgupdate.LOCode);
//param.Add("@AOCode", pimsgupdate.AOCode);
//param.Add("@SGMode", pimsgupdate.SGMode);
//param.Add("@SGType", pimsgupdate.SGType);
//param.Add("@ReferLC", pimsgupdate.ReferLC);
//param.Add("@expirydate", pimsgupdate.expirydate);
//param.Add("@CustCode", pimsgupdate.CustCode);
//param.Add("@beninfo", pimsgupdate.beninfo);
//param.Add("@BLNumber", pimsgupdate.BLNumber);
//param.Add("@shipping", pimsgupdate.shipping);
//param.Add("@vessel", pimsgupdate.vessel);
//param.Add("@masterAwb", pimsgupdate.masterAwb);
//param.Add("@houseAwb", pimsgupdate.houseAwb);
//param.Add("@InvNumber", pimsgupdate.InvNumber);
//param.Add("@SGCcy", pimsgupdate.SGCcy);
//param.Add("@SGAmt", pimsgupdate.SGAmt);
//param.Add("@ExchRate", pimsgupdate.ExchRate);
//param.Add("@SGBaht", pimsgupdate.SGBaht);
//param.Add("@CommAmt", pimsgupdate.CommAmt);
//param.Add("@DutyAmt", pimsgupdate.DutyAmt);
//param.Add("@PenaltyAmt", pimsgupdate.PenaltyAmt);
//param.Add("@RefundTax", pimsgupdate.RefundTax);
//param.Add("@RefundFlag", pimsgupdate.RefundFlag);
//param.Add("@PayFlag", pimsgupdate.PayFlag);
//param.Add("@PayMethod", pimsgupdate.PayMethod);
//param.Add("@PayRemark", pimsgupdate.PayRemark);
//param.Add("@Allocation", pimsgupdate.Allocation);
//param.Add("@DateLastPaid", pimsgupdate.DateLastPaid);
//param.Add("@LastReceiptNo", pimsgupdate.LastReceiptNo);
//param.Add("@AppvNo", pimsgupdate.AppvNo);
//param.Add("@FacNo", pimsgupdate.FacNo);
//param.Add("@Remark", pimsgupdate.Remark);
//param.Add("@UpdateDate", pimsgupdate.UpdateDate);
//param.Add("@UserCode", pimsgupdate.UserCode);
//param.Add("@GENACC_FLAG", pimsgupdate.GENACC_FLAG);
//param.Add("@Inuse", pimsgupdate.Inuse);
//param.Add("@CenterID", pimsgupdate.CenterID);

