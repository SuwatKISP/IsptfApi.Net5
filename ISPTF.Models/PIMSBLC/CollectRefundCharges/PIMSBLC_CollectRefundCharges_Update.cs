//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMSBLC
{
    public class PEXPC_CollectRefundCharges_Update_Req
    {
        public string? SBLCStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? RecStatus { get; set; }
        public string? InUse { get; set; }
        public string? LGMode { get; set; }
        public string? LGType { get; set; }
        public string? SBLCccy { get; set; }
        public double? SBLCAmt { get; set; }
        public double? SBLCbal { get; set; }
        public double? LGTHBAmt { get; set; }
        public double? LGTHBBal { get; set; }
        public double? THBAmt { get; set; }
        public double? PrevSBLCNet { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? taxrefund { get; set; }
        public double? PrincipleAmt { get; set; }
        public double? IntAmt { get; set; }
        public double? CommAmt { get; set; }
        public double? DutyStamp { get; set; }
        public double? Payable { get; set; }
        public double? TelexCharge { get; set; }
        public double? OthCharge { get; set; }
        public double? TaxAmt { get; set; }
        public string? PayFlag { get; set; }
        public string? paymethod { get; set; }
        public string? payremark { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? appvno { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public string? Allocation { get; set; }

    }
}

//param.Add("@SBLCStatus", pimsblcupdate.SBLCStatus);
//param.Add("@Event", pimsblcupdate.Event);
//param.Add("@EventDate", pimsblcupdate.EventDate);
//param.Add("@RecStatus", pimsblcupdate.RecStatus);
//param.Add("@InUse", pimsblcupdate.InUse);
//param.Add("@LGMode", pimsblcupdate.LGMode);
//param.Add("@LGType", pimsblcupdate.LGType);
//param.Add("@SBLCccy", pimsblcupdate.SBLCccy);
//param.Add("@SBLCAmt ", pimsblcupdate.SBLCAmt);
//param.Add("@SBLCbal", pimsblcupdate.SBLCbal);
//param.Add("@LGTHBAmt", pimsblcupdate.LGTHBAmt);
//param.Add("@LGTHBBal", pimsblcupdate.LGTHBBal);
//param.Add("@THBAmt", pimsblcupdate.THBAmt);
//param.Add("@PrevSBLCNet", pimsblcupdate.PrevSBLCNet);
//param.Add("@CustCode", pimsblcupdate.CustCode);
//param.Add("@CustAddr", pimsblcupdate.CustAddr);
//param.Add("@taxrefund", pimsblcupdate.taxrefund);
//param.Add("@PrincipleAmt", pimsblcupdate.PrincipleAmt);
//param.Add("@IntAmt", pimsblcupdate.IntAmt);
//param.Add("@CommAmt", pimsblcupdate.CommAmt);
//param.Add("@DutyStamp", pimsblcupdate.DutyStamp);
//param.Add("@Payable", pimsblcupdate.Payable);
//param.Add("@TelexCharge", pimsblcupdate.TelexCharge);
//param.Add("@OthCharge", pimsblcupdate.OthCharge);
//param.Add("@TaxAmt", pimsblcupdate.TaxAmt);
//param.Add("@PayFlag", pimsblcupdate.PayFlag);
//param.Add("@paymethod", pimsblcupdate.paymethod);
//param.Add("@payremark", pimsblcupdate.payremark);
//param.Add("@DateLastPaid", pimsblcupdate.DateLastPaid);
//param.Add("@LastReceiptNo", pimsblcupdate.LastReceiptNo);
//param.Add("@appvno", pimsblcupdate.appvno);
//param.Add("@UpdateDate", pimsblcupdate.UpdateDate);
//param.Add("@UserCode", pimsblcupdate.UserCode);
//param.Add("@Allocation", pimsblcupdate.Allocation);
