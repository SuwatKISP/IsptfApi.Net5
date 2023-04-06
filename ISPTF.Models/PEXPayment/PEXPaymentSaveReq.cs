//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PEXPayment
{
    public class PEXPaymentSaveReq
    {
        public string? DOCNUMBER { get; set; }  // ใช้ EXPORT_BC_NO
        public int? PAY_TYPE { get; set; }
        public DateTime? PAYMENT_DATE { get; set; }
        public int? AGENT_PAY_BY { get; set; }
        public int? SETTLEMENT_CREDIT { get; set; }
        public string? MTFLAG { get; set; }
        public double? SIGHT_PAID_AMT { get; set; }
        public double? SIGHT_PAID_RATE { get; set; }
        public double? SIGHT_PAID_THB { get; set; }
        public string? SIGHT_FORWARD { get; set; }
        public double? TERM_PAID_AMT { get; set; }
        public double? TERM_PAID_RATE { get; set; }
        public double? TERM_PAID_THB { get; set; }
        public string? TERM_FORWARD { get; set; }
        public double? TOT_PRINC_PAID { get; set; }
        public double? Com_Lieu { get; set; }
        public double? ComLieuRate { get; set; }
        public string? fb_ccy { get; set; }
        public double? Agent_amt { get; set; }
        public double? Agent_rate { get; set; }
        public double? Agent_thb { get; set; }
        public double? over_paid_amt { get; set; }
        public double? over_paid_rate { get; set; }
        public double? over_paid_thb { get; set; }
        public int? int_day { get; set; }
        public double? int_paid_amt { get; set; }
        public double? int_paid_rate { get; set; }
        public double? int_exch_rate { get; set; }
        public double? int_paid_thb { get; set; }
        public double? prn_paid_thb { get; set; }
        public double? Charge_Ccy { get; set; }
        public double? Charge_Rate { get; set; }
        public double? Charge_Thb { get; set; }
        public double? TOTAL_DUE_TO_CUS { get; set; }
        public double? FcdAmt { get; set; }
        public string? FcdAcc { get; set; }
        public double? MTAmt { get; set; }
        public string? Debit_credit_flag { get; set; }
        public string? ACCOUNT_NO1 { get; set; }
        public string? ACCOUNT_NO2 { get; set; }
        public string? ACCOUNT_NO3 { get; set; }
        public double? AMT_DEBIT_AC1 { get; set; }
        public double? AMT_DEBIT_AC2 { get; set; }
        public double? AMT_DEBIT_AC3 { get; set; }
        public double? AMT_CREDIT_AC1 { get; set; }
        public double? AMT_CREDIT_AC2 { get; set; }
        public double? AMT_CREDIT_AC3 { get; set; }
        public double? CASH { get; set; }
        public double? CHEQUE_AMT { get; set; }
        public string? CHEQUE_NO { get; set; }
        public string? CHEQUE_BK_BRN { get; set; }

    }
}
