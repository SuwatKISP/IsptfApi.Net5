using System;

namespace ISPTF.Models.ExportBC
{
    public class EXPCPaymentOverDueReleaseReq
    {
		public string? EXPORT_BC_NO { get; set; }
		public string? BENE_ID { get; set; }
		public string? VOUCH_ID { get; set; }
		public DateTime? EVENT_DATE { get; set; }
		public string? CenterID { get; set; }
		public int? TxBaseDay { get; set; }
		public string? USER_ID { get; set; }
		public DateTime? ValueDate { get; set; }
		public double? NEGO_COMM { get; set; }
		public double? TELEX_SWIFT { get; set; }
		public double? COURIER_POSTAGE { get; set; }
		public double? STAMP_FEE { get; set; }
		public double? BE_STAMP { get; set; }
		public double? COMM_OTHER { get; set; }
		public double? HANDING_FEE { get; set; }
		public double? DRAFTCOMM { get; set; }
		public double? TOTAL_CHARGE { get; set; }
		public int? REFUND_TAX_YN { get; set; }
		public double? REFUND_TAX_AMT { get; set; }
		public string? PAYMENTTYPE { get; set; }
		public string? NARRATIVE { get; set; }
		public string? ALLOCATION { get; set; }
		public string? AUTOOVERDUE { get; set; }
		public string? LCOVERDUE { get; set; }
		public string? PAYMENT_INSTRU { get; set; }
		public string? METHOD { get; set; }
		public string? INTCODE { get; set; }
		public double? OINTRATE { get; set; }
		public double? OINTSPDRATE { get; set; }
		public double? OINTCURRATE { get; set; }
		public int? OINTDAY { get; set; }
		public double? INTBALANCE { get; set; }
		public double? LASTINTAMT { get; set; }
		public double? PRNBALANCE { get; set; }
		public double? TOTAL_NEGO_BALANCE { get; set; }
		public DateTime? VALUE_DATE { get; set; }
		public DateTime? PASTDUEDATE { get; set; }
		public double? int_paid_thb { get; set; }
	}
}