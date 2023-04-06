//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMSBLC
{
    public class PEXPC_RegisterClaim_Update_Req
    {
        public string? SBLCStatus { get; set; }
        public string? Event { get; set; }
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
        public double? PrevSBLCAmt { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DateExpiry { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? beninfo { get; set; }
        public string? TenorTerm { get; set; }
        public string? BankCode { get; set; }
        public string? BankName { get; set; }
        public double? exchrate { get; set; }
        public double? ClaimAmt { get; set; }
        public string? payremark { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? appvno { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string? AuthCode { get; set; }

    }
}

//param.Add("@SBLCStatus", pimsblcupdate.SBLCStatus);
//param.Add("@Event", pimsblcupdate.Event);
//param.Add("@RecStatus", pimsblcupdate.RecStatus);
//param.Add("@InUse", pimsblcupdate.InUse);
//param.Add("@LGMode", pimsblcupdate.LGMode);
//param.Add("@LGType", pimsblcupdate.LGType);
//param.Add("@SBLCccy", pimsblcupdate.SBLCccy);
//param.Add("@SBLCAmt", pimsblcupdate.SBLCAmt);
//param.Add("@SBLCbal", pimsblcupdate.SBLCbal);
//param.Add("@LGTHBAmt", pimsblcupdate.LGTHBAmt);
//param.Add("@LGTHBBal", pimsblcupdate.LGTHBBal);
//param.Add("@THBAmt", pimsblcupdate.THBAmt);
//param.Add("@PrevSBLCAmt", pimsblcupdate.PrevSBLCAmt);
//param.Add("@StartDate", pimsblcupdate.StartDate);
//param.Add("@DateExpiry", pimsblcupdate.DateExpiry);
//param.Add("@CustCode", pimsblcupdate.CustCode);
//param.Add("@CustAddr", pimsblcupdate.CustAddr);
//param.Add("@beninfo", pimsblcupdate.beninfo);
//param.Add("@TenorTerm", pimsblcupdate.TenorTerm);
//param.Add("@BankCode", pimsblcupdate.BankCode);
//param.Add("@BankName", pimsblcupdate.BankName);
//param.Add("@exchrate", pimsblcupdate.exchrate);
//param.Add("@ClaimAmt", pimsblcupdate.ClaimAmt);
//param.Add("@payremark", pimsblcupdate.payremark);
//param.Add("@LastReceiptNo", pimsblcupdate.LastReceiptNo);
//param.Add("@appvno", pimsblcupdate.appvno);
//param.Add("@UpdateDate", pimsblcupdate.UpdateDate);
//param.Add("@UserCode", pimsblcupdate.UserCode);
//param.Add("@AuthDate", pimsblcupdate.AuthDate);
//param.Add("@AuthCode", pimsblcupdate.AuthCode);
