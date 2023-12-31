﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pExPayment
    {
        public string DOCNUMBER { get; set; }
        public int EVENT_NO { get; set; }
        public string EVENT_TYPE { get; set; }
        public string REC_STATUS { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public int? PAY_TYPE { get; set; }
        public DateTime? PAYMENT_DATE { get; set; }
        public double? NEGO_AMT { get; set; }
        public double? LESS_AGENT { get; set; }
        public double? TOT_NEGO_AMOUNT { get; set; }
        public double? BANK_CHARGE_AMT { get; set; }
        public double? NET_PROCEED_CLAIM { get; set; }
        public int? PAY_BY { get; set; }
        public int? AGENT_PAY_BY { get; set; }
        public int? SETTLEMENT_CREDIT { get; set; }
        public string MTFLAG { get; set; }
        public double? RECEIVE_PAY_AMT { get; set; }
        public int? PARTIAL_FULL_RATE { get; set; }
        public double? SIGHT_PAID_AMT { get; set; }
        public double? SIGHT_PAID_RATE { get; set; }
        public double? SIGHT_PAID_THB { get; set; }
        public string SIGHT_FORWARD { get; set; }
        public double? TERM_PAID_AMT { get; set; }
        public double? TERM_PAID_RATE { get; set; }
        public double? TERM_PAID_THB { get; set; }
        public string TERM_FORWARD { get; set; }
        public double? TOT_PRINC_PAID { get; set; }
        public string ParTnor_Type1 { get; set; }
        public string ParTnor_Type2 { get; set; }
        public string ParTnor_Type3 { get; set; }
        public string ParTnor_Type4 { get; set; }
        public string ParTnor_Type5 { get; set; }
        public string ParTnor_Type6 { get; set; }
        public double? PARTIAL_AMT1 { get; set; }
        public double? PARTIAL_AMT2 { get; set; }
        public double? PARTIAL_AMT3 { get; set; }
        public double? PARTIAL_AMT4 { get; set; }
        public double? PARTIAL_AMT5 { get; set; }
        public double? PARTIAL_AMT6 { get; set; }
        public double? PARTIAL_RATE1 { get; set; }
        public double? PARTIAL_RATE2 { get; set; }
        public double? PARTIAL_RATE3 { get; set; }
        public double? PARTIAL_RATE4 { get; set; }
        public double? PARTIAL_RATE5 { get; set; }
        public double? PARTIAL_RATE6 { get; set; }
        public double? PARTIAL_AMT1_THB { get; set; }
        public double? PARTIAL_AMT2_THB { get; set; }
        public double? PARTIAL_AMT3_THB { get; set; }
        public double? PARTIAL_AMT4_THB { get; set; }
        public double? PARTIAL_AMT5_THB { get; set; }
        public double? PARTIAL_AMT6_THB { get; set; }
        public string FORWARD_CONRACT_NO1 { get; set; }
        public string FORWARD_CONRACT_NO2 { get; set; }
        public string FORWARD_CONRACT_NO3 { get; set; }
        public string FORWARD_CONRACT_NO4 { get; set; }
        public string FORWARD_CONRACT_NO5 { get; set; }
        public string FORWARD_CONRACT_NO6 { get; set; }
        public int? BASE_DAY { get; set; }
        public double? CURRENT_DIS_RATE { get; set; }
        public double? CURRENT_INT_RATE { get; set; }
        public double? Com_Lieu { get; set; }
        public double? ComLieuRate { get; set; }
        public string fb_ccy { get; set; }
        public double? fb_amt { get; set; }
        public double? fb_rate { get; set; }
        public double? fb_amt_thb { get; set; }
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
        public double? TOTAL_NEGO_BALANCE { get; set; }
        public double? TOTAL_NEGO_BAL_THB { get; set; }
        public double? Charge_Ccy { get; set; }
        public double? Charge_Rate { get; set; }
        public double? Charge_Thb { get; set; }
        public double? Total_Charge { get; set; }
        public double? TOTAL_DUE_TO_CUS { get; set; }
        public string PAYMENT_INSTRU { get; set; }
        public string Method { get; set; }
        public double? FcdAmt { get; set; }
        public string FcdAcc { get; set; }
        public double? BahtNet { get; set; }
        public string AcBahtnet { get; set; }
        public double? MTAmt { get; set; }
        public string Debit_credit_flag { get; set; }
        public string ACCOUNT_NO1 { get; set; }
        public string ACCOUNT_NO2 { get; set; }
        public string ACCOUNT_NO3 { get; set; }
        public double? AMT_DEBIT_AC1 { get; set; }
        public double? AMT_DEBIT_AC2 { get; set; }
        public double? AMT_DEBIT_AC3 { get; set; }
        public double? AMT_CREDIT_AC1 { get; set; }
        public double? AMT_CREDIT_AC2 { get; set; }
        public double? AMT_CREDIT_AC3 { get; set; }
        public double? CASH { get; set; }
        public double? CHEQUE_AMT { get; set; }
        public string CHEQUE_NO { get; set; }
        public string CHEQUE_BK_BRN { get; set; }
        public double? TOTAL_AMOUNT { get; set; }
        public string PaymentType { get; set; }
        public string CenterID { get; set; }
    }
}
