﻿using ISPTF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Transactions;
using ISPTF.Commons;
namespace ISPTF.API.Controllers.ExportLC
{
    public class ExportLCHelper
    {
        public static string GenerateRandomReceiptNo(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }

        public static async Task<bool> GLBalance(ISPTFContext context, DateTime VOUCH_DATE, string VOUCH_ID)
        {
            var dailyGLTranD = await (from row in context.pDailyGLs
                                      where row.VouchDate.Date == VOUCH_DATE.Date &&
                                      row.VouchID == VOUCH_ID &&
                                      row.TranNature == "D"
                                      select row).ToListAsync();

            var dailyGLTranC = await (from row in context.pDailyGLs
                                      where row.VouchDate.Date == VOUCH_DATE.Date &&
                                      row.VouchID == VOUCH_ID &&
                                      row.TranNature == "C"
                                      select row).ToListAsync();

            decimal sumAmtDRN = (decimal)dailyGLTranD.Sum(row => row.TranAmount);
            decimal sumAmtCRN = (decimal)dailyGLTranC.Sum(row => row.TranAmount);

            if (sumAmtDRN == sumAmtCRN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static DateTime GetSysDate(ISPTFContext context)
        {
            string connectionString = context.Database.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT dbo.SystemDateTime()", connection))
                {
                    DateTime currentDate = (DateTime)command.ExecuteScalar();
                    return currentDate;
                }
            }
        }
        public static DateTime GetSysDateNT(ISPTFContext context)
        {
            string connectionString = context.Database.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT dbo.SystemDateTime2()", connection))
                {
                    DateTime currentDate = (DateTime)command.ExecuteScalar();
                    return currentDate;
                }
            }
        }
        public static double GetExchangeRate(ISPTFContext _context, string CCY, int? cType = null)
        {

            var pExchange = (from row in _context.pExchanges
                             where row.Exch_Date == DateTime.Today && 
                                   row.Exch_Ccy == CCY
                             orderby row.Exch_Time descending
                             select row).FirstOrDefault();

            if(pExchange.Exch_Time != null)
            {
                if (cType == 1)
                {
                    return (double)pExchange.Exch_TRate1;
                }
                else if (cType == 2)
                {
                    return (double)pExchange.Exch_TRate2;
                }
                else
                {
                    return (double)pExchange.Exch_TRate3;
                }
            }
            return 0;
        }

        public static string GenRefNo(ISPTFContext _context, string USER_CENTER_ID, string USER_ID, string docType, DateTime UpdateT, DateTime UpdateNT)
        {

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    string genRefNo = "";
                    //var sysDate = GetSysDate(_context);
                    string currentYear = UpdateT.Year.ToString();
                  //  string currentYear = custNo;
                    var pRefNo = (from row in _context.pReferenceNos
                                  where row.pRefTrans == docType &&
                                        row.pRefBran == USER_CENTER_ID &&  
                                        row.pRefYear == currentYear
                                  select row).FirstOrDefault();

                    if (pRefNo != null)
                    {
                        if (pRefNo.InUse == false)
                        {
                            pRefNo.InUse = true;
                            _context.pReferenceNos.Update(pRefNo);
                           _context.SaveChanges();

                            var currentRunNo = 0;
                            if (pRefNo.pRefSeq != null)
                            {
                                currentRunNo = (int)pRefNo.pRefSeq;
                            }

                            int runNo = currentRunNo + 1;

                            genRefNo = USER_CENTER_ID + pRefNo.pRefPrefix + currentYear.Substring(currentYear.Length - 2) + runNo.ToString("000000");

                            pRefNo.pRefSeq = runNo;
                            pRefNo.LastUpdate = UpdateT;
                            pRefNo.UserCode = USER_ID;
                            pRefNo.InUse = false;
                            _context.pReferenceNos.Update(pRefNo);
                            _context.SaveChanges();

                            transaction.Complete();
                            return genRefNo;


                        }
                    }
                    else
                    {
                        // select prefix
                        string docType1 = "PAID";
                        var mControl = (from row in _context.mControls
                                      where row.CTL_Type == "FUNCT" &&
                                            row.CTL_Code == docType1 && 
                                            row.CTL_ID == docType
                                      select row).FirstOrDefault();
                        if(mControl != null)
                        {
                            string prefix = mControl.CTL_Note1;

                            pReferenceNo initialRunNo = new();
                            initialRunNo.pRefTrans = docType;
                            initialRunNo.pRefYear = currentYear;
                            initialRunNo.pRefPrefix = prefix;
                            initialRunNo.pRefSeq = 0;
                            initialRunNo.LastUpdate = DateTime.Now;
                            initialRunNo.UserCode = USER_ID;
                            initialRunNo.pRefBran = USER_CENTER_ID;
                            initialRunNo.InUse = false;
                            _context.pReferenceNos.Add(initialRunNo);
                            _context.SaveChanges();
                            transaction.Complete();
                            return GenRefNo(_context, USER_CENTER_ID, USER_ID, docType,  UpdateT,  UpdateNT);
                        }
                        else
                        {
                            return "ERROR GET PREFIX FROM MCONTROL";
                        }
                    }
                }
                catch (Exception e)
                {
                    // Rollback
                    return e.ToString();
                }
            }
            return "ERROR";
        }

        public static string GenRefNo2(ISPTFContext _context, string USER_CENTER_ID, string USER_ID, string docType, DateTime UpdateT, DateTime UpdateNT)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    string genRefNo = "";
                    //var sysDate = GetSysDate(_context);
                    string currentYear = UpdateT.Year.ToString();
                    //  string currentYear = custNo;
                    var pRefNo = (from row in _context.pReferenceNos
                                  where row.pRefTrans == docType &&
                                        row.pRefBran == USER_CENTER_ID &&
                                        row.pRefYear == currentYear
                                  select row).FirstOrDefault();

                    if (pRefNo != null)
                    {
                        if (pRefNo.InUse == false)
                        {
                            pRefNo.InUse = true;
                            _context.pReferenceNos.Update(pRefNo);
                            _context.SaveChanges();

                            var currentRunNo = 0;
                            if (pRefNo.pRefSeq != null)
                            {
                                currentRunNo = (int)pRefNo.pRefSeq;
                            }

                            int runNo = currentRunNo + 1;

                            genRefNo = USER_CENTER_ID + pRefNo.pRefPrefix + currentYear.Substring(currentYear.Length - 2) + runNo.ToString("000000");

                            pRefNo.pRefSeq = runNo;
                            pRefNo.LastUpdate = UpdateT;
                            pRefNo.UserCode = USER_ID;
                            pRefNo.InUse = false;
                            _context.pReferenceNos.Update(pRefNo);
                            _context.SaveChanges();

                            transaction.Complete();
                            return genRefNo;


                        }
                    }
                    else
                    {
                        // select prefix
                        string docType1 = "PAID";
                        var mControl = (from row in _context.mControls
                                        where row.CTL_Type == "FUNCT" &&
                                              row.CTL_Code == docType1 &&
                                              row.CTL_ID == docType
                                        select row).FirstOrDefault();
                        if (mControl != null)
                        {
                            string prefix = mControl.CTL_Note1;

                            pReferenceNo initialRunNo = new();
                            initialRunNo.pRefTrans = docType;
                            initialRunNo.pRefYear = currentYear;
                            initialRunNo.pRefPrefix = prefix;
                            initialRunNo.pRefSeq = 0;
                            initialRunNo.LastUpdate = UpdateT;
                            initialRunNo.UserCode = USER_ID;
                            initialRunNo.pRefBran = USER_CENTER_ID;
                            initialRunNo.InUse = false;
                            _context.pReferenceNos.Add(initialRunNo);
                            _context.SaveChanges();
                            transaction.Complete();
                            return GenRefNo(_context, USER_CENTER_ID, USER_ID, docType,UpdateT,UpdateNT);
                        }
                        else
                        {
                            return "ERROR GET PREFIX FROM MCONTROL";
                        }
                    }
                }
                catch (Exception e)
                {
                    // Rollback
                    return e.ToString();
                }
            }
            return "ERROR";
        }
        public static string GetReceiptFCD(ISPTFContext _context, string USER_CENTER_ID, string USER_ID, string docType, DateTime UpdateDateT, DateTime UpdateDateNT)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    string genRefNo = "";
                  //  var sysDate = GetSysDate(_context);
                    string currentYear = UpdateDateT.Year.ToString();
                    var pRefNo = (from row in _context.pReferenceNos
                                  where row.pRefTrans == docType &&
                                        row.pRefBran == USER_CENTER_ID &&
                                        row.pRefYear == currentYear
                                  select row).FirstOrDefault();

                    if (pRefNo != null)
                    {
                        if (pRefNo.InUse != true)
                        {
                            pRefNo.InUse = true;
                            _context.pReferenceNos.Update(pRefNo);
                            _context.SaveChanges();

                            var currentRunNo = 0;
                            if (pRefNo.pRefSeq != null)
                            {
                                currentRunNo = (int)pRefNo.pRefSeq;
                            }

                            int runNo = currentRunNo + 1;

                            genRefNo = USER_CENTER_ID + pRefNo.pRefPrefix + currentYear.Substring(currentYear.Length - 2) + runNo.ToString("000000");

                            pRefNo.pRefSeq = runNo;
                            pRefNo.InUse =false;
                            pRefNo.LastUpdate = UpdateDateT;
                            pRefNo.UserCode = USER_ID;

                            _context.pReferenceNos.Update(pRefNo);
                            _context.SaveChanges();

                            transaction.Complete();
                            return genRefNo;


                        }
                    }
                    else
                    {
                        // select prefix
                        string docType1 = "PAID";
                        if (docType.Contains("PAID"))
                        {
                            docType1 = docType;
                        }

                        var mControl = (from row in _context.mControls
                                        where row.CTL_Type == "FUNCT" &&
                                              row.CTL_Code == docType1 &&
                                              row.CTL_ID == docType
                                        select row).FirstOrDefault();
                        if (mControl != null)
                        {
                            string prefix = mControl.CTL_Note1;

                            pReferenceNo initialRunNo = new();
                            initialRunNo.pRefTrans = docType;
                            initialRunNo.pRefYear = currentYear;
                            initialRunNo.pRefPrefix = prefix;
                            initialRunNo.pRefSeq = 0;
                            initialRunNo.LastUpdate = UpdateDateT;
                            initialRunNo.UserCode = USER_ID;
                            initialRunNo.pRefBran = USER_CENTER_ID;
                            initialRunNo.InUse = false;
                            _context.pReferenceNos.Add(initialRunNo);
                            _context.SaveChanges();
                            transaction.Complete();
                            return GetReceiptFCD(_context, USER_CENTER_ID, USER_ID, docType,UpdateDateT,UpdateDateNT);
                        }
                        else
                        {
                            return "ERROR GET PREFIX FROM MCONTROL";
                        }
                    }
                }
                catch (Exception e)
                {
                    // Rollback
                    return e.ToString();
                }
            }

            return "ERROR";
        }

        //LC
        public static string SavePayment(ISPTFContext _context, string USER_CENTER_ID, string USER_ID, pExlc lc, pPayment payment, DateTime UpdateT, DateTime UpdateNT)
        {
         //  DateTime GetSysDate = ModDate.GetSystemDateTime();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //string RECEIPT_NO = GenRefNo(_context, USER_CENTER_ID, USER_ID, PAYF_FLAG, UpdateT, UpdateNT);
                    //if (PAYF_FLAG == "FPAIDC")
                    //{
                    //    RECEIPT_NO = GetReceiptFCD(_context, USER_CENTER_ID, USER_ID, PAYF_FLAG, UpdateT, UpdateNT);
                    //}
                    //else
                    //{
                    //    RECEIPT_NO = GenRefNo(_context, USER_CENTER_ID, USER_ID, PAYF_FLAG, UpdateT, UpdateNT);
                    //}
                    string RECEIPT_NO = lc.RECEIVED_NO;
                    var existingPPayment = (from row in _context.pPayments
                                            where row.RpReceiptNo == lc.RECEIVED_NO
                                            select row).AsNoTracking().FirstOrDefault();

                    if (existingPPayment == null)
                    {

                        payment.RpReceiptNo = RECEIPT_NO;
                        payment.RpDocNo = lc.EXPORT_LC_NO;
                        payment.RpEvent = lc.EVENT_NO.ToString();
                        
                    }
                    else
                    {
                        payment.RpReceiptNo = RECEIPT_NO;
                        RECEIPT_NO = lc.RECEIVED_NO;
                    }
                    payment.RpDocNo = lc.EXPORT_LC_NO;
                    payment.RpModule = "EXLC";
                    payment.RpCustCode = lc.BENE_ID;
                    payment.RpNote = "";
                    if (payment.RpApplicant==null)
                    {
                        payment.RpApplicant ="";
                    }
                    else
                    {
                        payment.RpApplicant = payment.RpApplicant.ToUpper();
                    }

                    if (payment.RpChqNo == null)
                    {
                        payment.RpChqNo = "";
                    }
                    else
                    {
                        payment.RpChqNo = payment.RpChqNo.ToUpper();
                    }

                    if (payment.RpChqBank == null)
                    {
                        payment.RpChqBank = "";
                    }
                    else
                    {
                        payment.RpChqBank = payment.RpChqBank.ToUpper();
                    }

                    if (payment.RpChqBranch == null)
                    {
                        payment.RpChqBranch = "";
                    }
                    else
                    {
                        payment.RpChqBranch = payment.RpChqBranch.ToUpper();
                    }
                    if (payment.RpChqBranch == null)
                    {
                        payment.RpChqBranch = "";
                    }
                    else
                    {
                        payment.RpChqBranch = payment.RpChqBranch.ToUpper();
                    }

                    if (payment.RpCustAc1 == null)
                    {
                        payment.RpCustAc1 = "";
                    }
                    else
                    {
                        payment.RpCustAc1 = payment.RpCustAc1;
                    }

                    if (payment.RpCustAc2 == null)
                    {
                        payment.RpCustAc2 = "";
                    }
                    else
                    {
                        payment.RpCustAc2 = payment.RpCustAc2;
                    }

                    if (payment.RpCustAc3 == null)
                    {
                        payment.RpCustAc3 = "";
                    }
                    else
                    {
                        payment.RpCustAc3 = payment.RpCustAc3;
                    }

                    if (payment.RpPayDate == null)
                    {
                        payment.RpPayDate = lc.EVENT_DATE;
                    }
                    else
                    {
                        payment.RpPayDate = payment.RpPayDate;
                    }

                   payment.RpRecStatus = lc.REC_STATUS;
                    payment.RpStatus = "A";
                    payment.UserCode = lc.USER_ID;
                    payment.UpdateDate = UpdateT;

                    if (existingPPayment == null)
                    {
                        _context.pPayments.Add(payment);
                    }
                    else
                    {
                        _context.pPayments.Update(payment);

                    }

                    _context.SaveChanges();

                    transaction.Complete();
                    return RECEIPT_NO;

                }
                catch (Exception e)
                {
                    // Rollback
                    return "ERROR";
                }

            }
        }

        public static string HistInterest(ISPTFContext _context, string USER_CENTER_ID, string USER_ID, pExlc lc, pExPayment payment)
        {
            //  DateTime GetSysDate = ModDate.GetSystemDateTime();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    int cSeqNo;
                    int maxSeq = 0;
                    var maxSeqRow = (from row in _context.pEXInterests
                                     where row.Login == "EXLC" &&
                                      row.DocNo == lc.EXPORT_LC_NO
                                     select row).ToList().OrderByDescending(x => x.Seqno);
                    foreach (var row in maxSeqRow)
                    {
                        maxSeq = row.Seqno;
                        break;
                    }
                    if (maxSeq == 0)
                    {
                        cSeqNo = 1;
                    }
                    else
                    {
                        cSeqNo = maxSeq + 1;
                    }
                    var pEXInterests = (from row in _context.pEXInterests
                                  where row.Login == "EXLC" &&
                                  row.DocNo == lc.EXPORT_LC_NO &&
                                  row.EventNo == payment.EVENT_NO &&
                                  row.Seqno == cSeqNo
                                  select row).AsNoTracking().FirstOrDefault();
                    pEXInterest exinterest = new pEXInterest();
                    if (pEXInterests==null)
                    {
                      //  cAddNew = True

                        exinterest.DocNo = payment.DOCNUMBER;
                        exinterest.Login = "EXLC";
                        exinterest.Event = "";
                        exinterest.EventNo = payment.EVENT_NO;
                    }
                
                    exinterest.CenterID = USER_CENTER_ID;
                    exinterest.Seqno = cSeqNo;
                    exinterest.CalDate = payment.EVENT_DATE;
                    if (lc.TENOR_OF_COLL ==1)
                    {
                        exinterest.IntFrom = lc.SIGHT_START_DATE;
                    }
                    else
                    {
                        exinterest.IntFrom = lc.TERM_DUE_DATE;
                    }

                    exinterest.IntTo = payment.PAYMENT_DATE;
                    exinterest.Ccy = lc.DRAFT_CCY;
                    exinterest.IntDay = payment.int_day;
                    exinterest.CurIntRate = payment.CURRENT_INT_RATE;
                    exinterest.IntCCy = payment.int_paid_amt;
                    exinterest.IntAmt = payment.int_paid_thb;
                    exinterest.IntExchRate = payment.int_exch_rate;
                    exinterest.BaseDay = payment.BASE_DAY;
                    if (payment.PARTIAL_FULL_RATE==2) // ' full rate
                    {
                        if (payment.SETTLEMENT_CREDIT==0) //'fcd to thb
                        {
                            if (lc.TENOR_OF_COLL ==1)
                            {
                                exinterest.BalCcy = payment.SIGHT_PAID_AMT;
                            }
                            else
                            {
                                exinterest.BalCcy = payment.TERM_PAID_AMT;
                            }
                        } // FCD TO THB
                        else
                        {
                            if (lc.TENOR_OF_COLL == 1)
                            {
                                exinterest.BalCcy = payment.SIGHT_PAID_THB;
                            }
                            else
                            {
                                exinterest.BalCcy = payment.TERM_PAID_THB;
                            }
                        }
                    }
                    else
                    {
                        if (payment.SETTLEMENT_CREDIT == 0 || payment.SETTLEMENT_CREDIT == 1)//fcy to thb
                        {
                            exinterest.BalCcy = payment.PARTIAL_AMT1.Value + payment.PARTIAL_AMT2.Value +
                                payment.PARTIAL_AMT3.Value + payment.PARTIAL_AMT4.Value +
                                payment.PARTIAL_AMT5.Value + payment.PARTIAL_AMT6.Value;
                        }
                        else if (payment.SETTLEMENT_CREDIT == 2)//fcy to thb
                        {
                            exinterest.BalCcy = payment.PARTIAL_AMT1_THB.Value + payment.PARTIAL_AMT2_THB.Value +
                                payment.PARTIAL_AMT3_THB.Value + payment.PARTIAL_AMT4_THB.Value +
                                payment.PARTIAL_AMT5_THB.Value + payment.PARTIAL_AMT6_THB.Value;
                        }
                    }
                    
                    

                    if (pEXInterests == null)
                    {
                        _context.pEXInterests.Add(exinterest);
                    }
                    else
                    {
                        _context.pEXInterests.Update(exinterest);

                    }

                    _context.SaveChanges();

                    transaction.Complete();
                    return "OK";

                }
                catch (Exception e)
                {
                    // Rollback
                    return "ERROR";
                }

            }
        }

        public static string HistInterestPC(ISPTFContext _context, string USER_CENTER_ID, string USER_ID, pExpc pc)
        {
            //  DateTime GetSysDate = ModDate.GetSystemDateTime();
             IFormatProvider engDateFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    int cSeqNo;
                    int maxSeq = 0;
                    var maxSeqRow = (from row in _context.pEXInterests
                                     where row.Login == "EXPC" &&
                                      row.DocNo == pc.PACKING_NO
                                     select row).ToList().OrderByDescending(x => x.Seqno);
                    foreach (var row in maxSeqRow)
                    {
                        maxSeq = row.Seqno;
                        break;
                    }
                    if (maxSeq == 0)
                    {
                        cSeqNo = 1;
                    }
                    else
                    {
                        cSeqNo = maxSeq + 1;
                    }
                    var pEXInterests = (from row in _context.pEXInterests
                                        where row.Login == "EXPC" &&
                                        row.DocNo == pc.PACKING_NO &&
                                        row.EventNo == pc.event_no &&
                                        row.Seqno == cSeqNo
                                        select row).AsNoTracking().FirstOrDefault();
                    pEXInterest exinterest = new pEXInterest();
                    if (pEXInterests == null)
                    {
                        //  cAddNew = True
                        exinterest.DocNo = pc.PACKING_NO;
                        exinterest.Login = "EXPC";
                        exinterest.Event = pc.event_type;
                        exinterest.EventNo = pc.event_no;
                    }

                    exinterest.CenterID = USER_CENTER_ID;
                    exinterest.Seqno = cSeqNo;
                    exinterest.CalDate = pc.event_date;
                    exinterest.IntTo = pc.ValueDate;
                    if (pc.PcIntType == "0")
                    {
                        exinterest.IntDay = (pc.ValueDate - pc.pc_start_date).Value.Days;
                        exinterest.IntFrom = pc.pc_start_date;
                    }
                    else if  (pc.PcIntType == "1")
                    {
                        exinterest.IntTo = pc.ValueDate;
                        exinterest.IntDay = (pc.ValueDate - pc.CalIntDate).Value.Days;
                        exinterest.IntFrom = pc.CalIntDate;
                     }
                    exinterest.CurIntRate = pc.current_intrate;
                    exinterest.IntRate = pc.pc_int_rate;
                    exinterest.Spread = pc.spread_rate;
                    exinterest.IntAmt = pc.interest_thb2;
                    if (pc.packing_for == "T")
                    {
                        exinterest.BaseDay = 365;
                        if (pc.principle_amt_thb2 == 0)
                        {
                            exinterest.BalCcy = pc.principle_amt_thb1;
                        }
                        else
                        {
                            exinterest.BalCcy = pc.principle_amt_thb2;
                        }

                        exinterest.IntExchRate = 1;
                        exinterest.Ccy = "THB";
                        exinterest.IntCCy = pc.interest_thb2;
                    }
                    else
                    {
                        exinterest.BaseDay = 360;
                        if (pc.principle_amt_ccy2 == 0)
                        {
                            exinterest.BalCcy = pc.principle_amt_ccy1;
                        }
                        else
                        {
                            exinterest.BalCcy = pc.principle_amt_ccy2;
                        }

                        exinterest.IntExchRate = pc.exch_rate3;
                        exinterest.Ccy = pc.doc_ccy;
                        exinterest.IntCCy = pc.interest_ccy2;
                    }

                    if (pEXInterests == null)
                    {
                        _context.pEXInterests.Add(exinterest);
                    }
                    else
                    {
                        _context.pEXInterests.Update(exinterest);

                    }

                    _context.SaveChanges();

                    transaction.Complete();
                    return "OK";

                }
                catch (Exception e)
                {
                    // Rollback
                    return "ERROR";
                }

            }
        }
        public static string HistInterestODU(ISPTFContext _context, string USER_CENTER_ID, string USER_ID, pExlc lc, pExPayment payment)
        {
            //  DateTime GetSysDate = ModDate.GetSystemDateTime();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    int cSeqNo;
                    int maxSeq = 0;
                    var maxSeqRow = (from row in _context.pEXInterests
                                     where row.Login == "EXLC" &&
                                      row.DocNo == lc.EXPORT_LC_NO
                                     select row).ToList().OrderByDescending(x => x.Seqno);
                    foreach (var row in maxSeqRow)
                    {
                        maxSeq = row.Seqno;
                        break;
                    }
                    if (maxSeq == 0)
                    {
                        cSeqNo = 1;
                    }
                    else
                    {
                        cSeqNo = maxSeq + 1;
                    }
                    var pEXInterests = (from row in _context.pEXInterests
                                        where row.Login == "EXLC" &&
                                        row.DocNo == lc.EXPORT_LC_NO &&
                                        row.EventNo == payment.EVENT_NO &&
                                        row.Seqno == cSeqNo
                                        select row).AsNoTracking().FirstOrDefault();
                    pEXInterest exinterest = new pEXInterest();
                    if (pEXInterests == null)
                    {
                        //  cAddNew = True

                        exinterest.DocNo = payment.DOCNUMBER;
                        exinterest.Login = "EXLC";
                        exinterest.Event = payment.EVENT_TYPE;
                        exinterest.EventNo = payment.EVENT_NO;
                    }

                    exinterest.CenterID = USER_CENTER_ID;
                    exinterest.Seqno = cSeqNo;
                    exinterest.CalDate = payment.EVENT_DATE;
                    exinterest.IntFrom = lc.LASTINTDATE;
                    exinterest.IntTo = lc.ValueDate;

                    exinterest.BalCcy = lc.PRNBALANCE;

                    exinterest.IntCode = lc.INTCODE;
                    exinterest.IntRate = lc.OINTRATE;
                    exinterest.Spread = lc.OINTSPDRATE;
                    exinterest.CurIntRate = lc.OINTCURRATE;
                    exinterest.IntDay = lc.OINTDAY;
                    exinterest.BaseDay = lc.OBASEDAY;
                    exinterest.IntCCy = 0;
                    exinterest.IntExchRate = 0;
                    exinterest.IntAmt = payment.int_paid_thb;
                    exinterest.Ccy = payment.fb_ccy;
                    


                    if (pEXInterests == null)
                    {
                        _context.pEXInterests.Add(exinterest);
                    }
                    else
                    {
                        _context.pEXInterests.Update(exinterest);

                    }

                    _context.SaveChanges();

                    transaction.Complete();
                    return "OK";

                }
                catch (Exception e)
                {
                    // Rollback
                    return "ERROR";
                }

            }
        }

        public static string HistInterestIssueODU(ISPTFContext _context, string USER_CENTER_ID, string USER_ID, pExlc lc)
        {
            //  DateTime GetSysDate = ModDate.GetSystemDateTime();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //var maxSeq5 = (from row in _context.pEXInterests
                    //              where row.Login == "EXLC" &&
                    //              row.DocNo == lc.EXPORT_LC_NO
                    //              select row).Max(x => x.Seqno);
                    int cSeqNo;
                    int maxSeq=0;
                    var maxSeqRow = (from row in _context.pEXInterests
                                   where row.Login == "EXLC" &&
                                    row.DocNo == lc.EXPORT_LC_NO
                                   select row).ToList().OrderByDescending(x=>x.Seqno);
                    foreach (var row in maxSeqRow)
                    {
                        maxSeq = row.Seqno;
                        break;
                    }
                    if (maxSeq == 0)
                    {
                        cSeqNo = 1;
                    }
                    else
                    {
                        cSeqNo = maxSeq + 1;
                    }
                    var pEXInterests = (from row in _context.pEXInterests
                                        where row.Login == "EXLC" &&
                                        row.Event == "OVERDUE" &&
                                        row.DocNo == lc.EXPORT_LC_NO &&
                                        row.EventNo == lc.EVENT_NO &&
                                        row.Seqno == cSeqNo
                                        select row).AsNoTracking().FirstOrDefault();
                    pEXInterest exinterest = new pEXInterest();
                    if (pEXInterests == null)
                    {
                        //  cAddNew = True

                        exinterest.DocNo = lc.EXPORT_LC_NO;
                        exinterest.Login = "EXLC";
                        exinterest.Event = "OVERDUE";
                        exinterest.EventNo = lc.EVENT_NO;
                    }
  
                    exinterest.CenterID = USER_CENTER_ID;
                    exinterest.Seqno = cSeqNo;
                    exinterest.CalDate = lc.EVENT_DATE;
                    exinterest.IntFrom = lc.LASTINTDATE;
                    exinterest.IntTo = lc.VALUE_DATE;

                    exinterest.BalCcy = lc.PURCHASE_AMT;

                    exinterest.IntCode = "CCY";
                    exinterest.IntRate = lc.CURRENT_INT_RATE;
                    exinterest.Spread = 0;
                    exinterest.CurIntRate = lc.CURRENT_INT_RATE;
                    exinterest.IntDay = lc.OINTDAY;
                    exinterest.BaseDay = lc.BASE_DAY;
                    exinterest.IntCCy = lc.PARTIAL_AMT1;
                    exinterest.IntExchRate = lc.PARTIAL_RATE1;
                    exinterest.IntAmt = lc.PARTIAL_AMT1_THB;
                    exinterest.Ccy =lc.DRAFT_CCY;
                    


                    if (pEXInterests == null)
                    {
                        _context.pEXInterests.Add(exinterest);
                    }
                    else
                    {
                        _context.pEXInterests.Update(exinterest);

                    }

                    _context.SaveChanges();

                    transaction.Complete();
                    return "OK";

                }
                catch (Exception e)
                {
                    // Rollback
                    return "ERROR";
                }

            }
        }
        public static bool SavePaymentDetail2(ISPTFContext _context, pExlc lc, pPayDetail[] payDetails)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var existingPPayment = (from row in _context.pPayments
                                            where row.RpReceiptNo == lc.RECEIVED_NO
                                            select row).FirstOrDefault();

                    if (existingPPayment == null)
                    {
                        return false;
                    }

                    var existingPPayDetail = (from row in _context.pPayDetails
                                              where row.DpReceiptNo == lc.RECEIVED_NO
                                              select row).ToList();

                    foreach (var row in existingPPayDetail)
                    {
                        _context.pPayDetails.Remove(row);
                    }

                    _context.SaveChanges();

                    // Save PayDetails[]

                    foreach (var row in payDetails)
                    {
                        _context.pPayDetails.Add(row);
                    }

                    _context.SaveChanges();

                    transaction.Complete();
                    return true;
                }
                catch (Exception e)
                {
                    // Rollback
                    return false;
                }

            }
        }
        public static bool UpdateCustomerLiability(ISPTFContext _context, pExlc data)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    // 0 - Select EXLC Master
                    var pExlcMaster = (from row in _context.pExlcs
                                       where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                             row.RECORD_TYPE == "MASTER"
                                       select row).FirstOrDefault();

                    // 1 - Check if Master Exists
                    if (pExlcMaster == null)
                    {
                        return false;
                    }

                    var approveFacility = pExlcMaster.FACNO;
                    if (string.IsNullOrEmpty(approveFacility))
                    {
                        approveFacility = "TFL9999";
                    }

                    // 2 - Update PCustLiability ODU
                    var cCCY = "ODU";
                    var exchangeRate = 1;
                    var CCYAmt = data.PRNBALANCE;
                    var BHTAmt = CCYAmt * exchangeRate;

                    var pCustLiabODU = (from row in _context.pCustLiabs
                                              where row.Cust_Code == data.BENE_ID &&
                                                    row.Facility_No == approveFacility &&
                                                    row.Currency == cCCY
                                              select row).FirstOrDefault();

                    if (pCustLiabODU != null)
                    {
                        if (pCustLiabODU.XLCP_Amt == null)
                        {
                            pCustLiabODU.XLCP_Amt = 0;
                        }
                        pCustLiabODU.XLCP_Amt = pCustLiabODU.XLCP_Amt - CCYAmt;
                        pCustLiabODU.UpdateDate = DateTime.Now; // With Time
                    }


                    // 3 - Update PCustLiability THB
                    cCCY = "THB";
                    var pCustLiabTHB = (from row in _context.pCustLiabs
                                              where row.Cust_Code == data.BENE_ID &&
                                                    row.Facility_No == approveFacility &&
                                                    row.Currency == cCCY
                                              select row).FirstOrDefault();
                    if (pCustLiabTHB == null)
                    {
                        pCustLiab row = new();
                        row.Cust_Code = data.BENE_ID;
                        row.Facility_No = approveFacility;
                        row.Currency = cCCY;
                        row.UpdateDate = DateTime.Now;
                        row.XLCP_Amt = CCYAmt;
                        _context.pCustLiabs.Add(row);
                    }
                    else if (pCustLiabTHB != null)
                    {
                        if (pCustLiabTHB.XLCP_Amt == null)
                        {
                            pCustLiabTHB.XLCP_Amt = 0;
                        }
                        pCustLiabTHB.XLCP_Amt = pCustLiabTHB.XLCP_Amt + CCYAmt;
                        pCustLiabTHB.UpdateDate = DateTime.Now; // With Time
                    }

                    _context.SaveChanges();


                    if (approveFacility.Contains("MX"))
                    {
                        UpdateGroupWork(data.BENE_ID, approveFacility, true, _context);
                    }
                    else
                    {
                        UpdateGroupWork(data.BENE_ID, approveFacility, false, _context);
                    }


                    transaction.Complete();
                    return true;
                }
                catch (Exception e)
                {
                    // Rollback
                    return false;
                }
            }
        }

        public static bool UpdateGroupWork(string customerCode, string facilityNo, bool isGroup, ISPTFContext _context)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    double liabilityAmount = 0;
                    double shareUse = 0;
                    string shareType = "";
                    string shareFlag = "";
                    double partialAvailableAmount = 0;
                    double groupAmount = 0;
                    string parentCode = "";
                    string parentFacility = "";
                    string childCode = "";
                    string CCY = "";
                    double amount = 0;
                    double cAmountTHB = 0;

                    // 1 - Select Parent Code, Facility
                    if (isGroup == true)
                    {
                        var custLimit = (from row in _context.pCustLimits
                                               where row.Cust_Code == customerCode &&
                                                     row.Facility_No == facilityNo
                                               select row).FirstOrDefault();
                        if (custLimit != null)
                        {
                            parentCode = custLimit.Cust_Code;
                            parentFacility = custLimit.Facility_No;
                        }
                    }
                    else if (isGroup == false)
                    {
                        parentCode = customerCode;
                        parentFacility = facilityNo;
                    }

                    // 2 - Select Share Type / Flag
                    var custLimitChild = (from row in _context.pCustLimits
                                                where row.Cust_Code == parentCode &&
                                                      row.Facility_No == parentFacility
                                                select row).FirstOrDefault();

                    if (custLimitChild != null)
                    {
                        shareType = custLimitChild.Share_Type;
                        shareFlag = custLimitChild.Share_Flag;
                    }
                    else
                    {
                        shareFlag = "N";
                    }

                    if (shareFlag == "N")
                    {
                        return true;
                    }

                    // Call RevalueLiab(ParentCode)

                    // 3 - Update Credit_Amount,Origin_Amount (child)
                    var custShareChilds = (from row in _context.pCustShares
                                                 where row.Cust_Code == parentCode &&
                                                       row.Facility_No == parentFacility
                                                 select row).ToList();

                    foreach (var row in custShareChilds)
                    {
                        var custLimitChilds = (from row2 in _context.pCustLimits
                                                     where row2.Cust_Code == row.Share_Cust &&
                                                           row2.Refer_Cust == row.Cust_Code &&
                                                           row2.Facility_No == row.Facility_No
                                                     select row2).ToList();
                        foreach (var row2 in custLimitChilds)
                        {
                            row2.Ear_Amount = 0;
                            row2.Credit_Amount = row.Share_Credit;
                            row2.Origin_Amount = row.Share_Credit;
                        }
                    }

                    _context.SaveChanges();

                    // 4 - UPDATE Share_Amount =0 ,Share_Used =0 (parent)
                    var custLimitParents = (from row in _context.pCustLimits
                                                  where row.Refer_Cust == parentCode &&
                                                        row.Refer_Facility == parentFacility &&
                                                        !string.IsNullOrEmpty(row.Refer_Cust) &&
                                                        !string.IsNullOrEmpty(row.Refer_Facility)
                                                  select row).Distinct().ToList();
                    foreach (var row3 in custLimitParents)
                    {
                        var subCustLimits = (from row in _context.pCustLimits
                                                   where row.Cust_Code == row3.Refer_Cust &&
                                                         row.Facility_No == row3.Refer_Facility
                                                   select row).ToList();

                        foreach (var row in subCustLimits)
                        {
                            row.Share_Amount = 0;
                        }

                        var subCustShares = (from row in _context.pCustShares
                                                   where row.Cust_Code == row3.Refer_Cust &&
                                                         row.Facility_No == row3.Refer_Facility
                                                   select row).ToList();

                        foreach (var row in subCustShares)
                        {
                            row.Share_Used = 0;
                        }
                    }

                    _context.SaveChanges();

                    // 5 - Revaluate Liability
                    var custLimits = (from row in _context.pCustLimits
                                            where row.Facility_No.Substring(0, 2) == "MX" &&
                                                  (row.Status == "A" || row.Status == "U") &&
                                                    row.Refer_Cust == parentCode &&
                                                    row.Refer_Facility == parentFacility
                                            select row).ToList();

                    // Call RevalueLiab(rs!cust_code)
                    foreach (var row in custLimits)
                    {
                        var result = (from c in _context.pCustLSums
                                      where c.Cust_Code == row.Cust_Code && c.Facility_No == row.Facility_No
                                      select new
                                      {
                                          LiabAmt = (
                                              (c.IMLC_Amt ?? 0) + (c.DBE_Amt ?? 0) + (c.DLC_Amt ?? 0) + (c.IBLS_Amt ?? 0) +
                                              (c.IBLT_Amt ?? 0) + (c.IMTR_Amt ?? 0) + ((c.SGBC_Amt ?? 0) - (c.SGBC_Issued ?? 0)) +
                                              (c.EXPC_Amt ?? 0) + (c.XLCP_Amt ?? 0) + (c.XBCP_Amt ?? 0) + (c.IMLC_Book ?? 0) +
                                              (c.IMTR_Book ?? 0) + (c.DLC_Book ?? 0) + (c.SGBC_Book ?? 0) + (c.EXPC_Book ?? 0) +
                                              (c.XLCP_Book ?? 0) + (c.SBLC_Book ?? 0) + (c.LG_Book ?? 0) + (c.SBLC_Amt ?? 0) +
                                              (c.LG_Amt ?? 0) + (c.XBCP_Book ?? 0) + (c.IMBL_Over ?? 0) + (c.NCTR_Book ?? 0)
                                          )
                                      }).FirstOrDefault()?.LiabAmt ?? 0;

                        liabilityAmount = result;

                        row.Susp_Amount = liabilityAmount;

                        // 6 - Update selected Facility No. mother
                        var custLimitMothers = (from rowMother in _context.pCustLimits
                                                      where rowMother.Refer_Cust == parentCode &&
                                                            rowMother.Refer_Facility == parentFacility
                                                      select rowMother).ToList();
                        foreach (var row2 in custLimitMothers)
                        {
                            if (row2.Share_Amount == null)
                            {
                                row2.Share_Amount = 0;
                            }
                            row2.Share_Amount = (double)row2.Share_Amount + liabilityAmount;
                            shareUse = (double)row2.Share_Amount;

                            if (row2.Share_Type == null)
                            {
                                row2.Share_Type = "";
                            }
                            shareType = row2.Share_Type;

                            if (row2.Facility_Type == "T" && row2.Revol_Flag == "N")
                            {
                                row2.Credit_Amount = row2.Credit_Amount - liabilityAmount;
                            }
                        }

                        // 7 - CustShares
                        var custShares = (from row3 in _context.pCustShares
                                                where row3.Cust_Code == row.Refer_Cust &&
                                                      row3.Share_Cust == row.Cust_Code &&
                                                      row3.Facility_No == row.Facility_No
                                                select row3).ToList();

                        foreach (var row3 in custShares)
                        {
                            if (row3.Share_Used == null)
                            {
                                row3.Share_Used = 0;
                            }
                            row3.Share_Used = row3.Share_Used + liabilityAmount;
                        }



                    }

                    _context.SaveChanges();

                    // 8 - For none fix
                    var custLimitNones = (from row in _context.pCustLimits
                                                where row.Share_Flag == "Y" &&
                                                      row.Share_Type == "N" &&
                                                      row.Status != "D" &&
                                                      row.Cust_Code == parentCode &&
                                                      row.Facility_No == parentFacility
                                                select row).ToList();

                    // No Use as of
                    //'        ParentCode = rsTmp!Cust_Code
                    //'        ParentFac = rsTmp!facility_no


                    // 9 - Update Share Group Child (Liability Child)

                    var viewCustLiabilities = (from row in _context.ViewCustLiabs
                                                     where row.Facility_No.StartsWith("MX") &&
                                                           row.Refer_Cust == parentCode &&
                                                           row.Refer_Facility == parentFacility
                                                     select row).ToList();

                    foreach (var row in viewCustLiabilities)
                    {
                        childCode = row.Cust_Code;
                        facilityNo = row.Facility_No;
                        CCY = row.Currency;
                        amount = row.Liability;

                        if (CCY == "ODU" ||
                            CCY == "PDU" ||
                            CCY == "THB")
                        {
                            cAmountTHB = Math.Truncate(amount * 100) / 100;
                        }
                        else
                        {
                            /** GetRateExChange(CCY)*/
                            cAmountTHB = Math.Truncate(amount * 100) / 100;
                        }
                    }


                    var custLimitChilds2 = (from row in _context.pCustLimits
                                                  where row.Refer_Cust == parentCode &&
                                                        row.Status != "I" &&
                                                        row.Cust_Code != childCode &&
                                                        row.Facility_No == parentFacility
                                                  select row).ToList();

                    foreach (var row in custLimitChilds2)
                    {
                        if (row.Ear_Amount == null)
                        {
                            row.Ear_Amount = 0;
                        }
                        row.Ear_Amount = row.Ear_Amount + cAmountTHB;
                        if (row.Ear_Amount < 0)
                        {
                            row.Ear_Amount = 0;
                        }
                        row.Share_Amount = 0;
                    }


                    // 10 - Update Share Group Parent

                    var viewCustLiabilityParents = (from row in _context.ViewCustLiabs
                                                          where row.Cust_Code == parentCode &&
                                                                row.Facility_No == parentFacility
                                                          select row).ToList();
                    foreach (var row in viewCustLiabilityParents)
                    {
                        childCode = row.Cust_Code;
                        facilityNo = row.Facility_No;
                        CCY = row.Currency;
                        amount = row.Liability;

                        if (CCY == "ODU" ||
                            CCY == "PDU" ||
                            CCY == "THB")
                        {
                            cAmountTHB = Math.Truncate(amount * 100) / 100;
                        }
                        else
                        {
                            /** GetRateExChange(CCY)*/
                            cAmountTHB = Math.Truncate(amount * 100) / 100;
                        }
                    }

                    var custLimitParents2 = (from row in _context.pCustLimits
                                                   where row.Refer_Cust == parentCode &&
                                                         row.Status != "I" &&
                                                         row.Cust_Code != childCode &&
                                                         row.Facility_No == parentFacility
                                                   select row).ToList();

                    foreach (var row in custLimitParents2)
                    {
                        if (row.Ear_Amount == null)
                        {
                            row.Ear_Amount = 0;
                        }
                        row.Ear_Amount = row.Ear_Amount + cAmountTHB;
                        if (row.Ear_Amount < 0)
                        {
                            row.Ear_Amount = 0;
                        }
                        row.Share_Amount = 0;
                    }

                    _context.SaveChanges();

                    // 11 - Update Group Amount

                    var groupCustLimits = (from row in _context.pCustLimits
                                                 where !row.Facility_No.StartsWith("MX") &&
                                                       row.Share_Flag == "Y" &&
                                                       row.Share_Type == "F" &&
                                                       row.Cust_Code != childCode &&
                                                       row.Facility_No == parentFacility
                                                 select row).ToList();

                    foreach (var row in groupCustLimits)
                    {
                        var result = (from c in _context.ViewCreditLimits
                                      where c.Cust_Code == parentCode &&
                                            c.Facility_No == parentFacility
                                      select new
                                      {
                                          Credit_Share = c.Credit_Share ?? 0,
                                          Available_Amt = c.Available_Amt
                                      }).FirstOrDefault();

                        partialAvailableAmount = result.Available_Amt;
                    }

                    var groupCustLimitPartials = (from row in _context.pCustLimits
                                                        where row.Status != "I" &&
                                                              row.Refer_Cust != parentCode &&
                                                              row.Refer_Facility == parentFacility
                                                        select row).ToList();

                    foreach (var row in groupCustLimitPartials)
                    {
                        groupAmount = (double)(row.Credit_Amount - row.Susp_Amount - partialAvailableAmount);
                        if (groupAmount < 0)
                        {
                            groupAmount = 0;
                        }
                        row.Ear_Amount = groupAmount;
                    }

                    return true;
                }
                catch (Exception e)
                {
                    // Rollback
                    return false;
                }
            }
        }

        public async static Task<bool> UpdateBankLiability(ISPTFContext _context, pExlc data)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    // 0 - Select EXLC Master
                    var pExlcMaster = (from row in _context.pExlcs
                                       where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                             row.RECORD_TYPE == "MASTER"
                                       select row).FirstOrDefault();

                    // 1 - Check if Master Exists
                    if (pExlcMaster == null)
                    {
                        return false;
                    }


                    // 2 - CCY
                    double CCYAmt = 0;
                    var SettlementCredit = data.PARTIAL_FULL_RATE;

                    var approveFacility = pExlcMaster.FACNO;
                    if (string.IsNullOrEmpty(approveFacility))
                    {
                        approveFacility = "TFL9999";
                    }

                    /*
                      If optFullRate(2).Value Then 'full rate
                           If optSettCredit(0).Value Then 'fcd to thb
                                If optTnor(1).Value Then
                                    CCyAmt = Val(num(txtSightPay.Text))
                                ElseIf optTnor(2).Value Then
                                    CCyAmt = Val(num(txtTermPay.Text))
                                End If
                            Else 'thb
                                If optTnor(1).Value Then
                                    CCyAmt = Val(num(txtSightPayBth.Text))
                                ElseIf optTnor(2).Value Then
                                    CCyAmt = Val(num(txtTermPayBth.Text))
                                End If
                            End If
                        Else
                            If optSettCredit(0).Value Then 'fcd to thb
                                For i% = txtPartAmt.LBound To txtPartAmt.UBound
                                    CCyAmt = CCyAmt + Val(num(txtPartAmt(i%).Text))
                                Next
                            Else
                                For i% = txtResultAmt.LBound To txtResultAmt.UBound
                                    CCyAmt = CCyAmt + Val(num(txtResultAmt(i%).Text))
                                Next
                            End If
                        End If
                     */


                    var cCCY = "THB";
                    var existingBankLiabilityRows = (from row in _context.pBankLiabs
                                                     where row.Bank_Code == data.Wref_Bank_ID &&
                                                           row.Facility_No == approveFacility &&
                                                           row.Currency == cCCY
                                                     select row).ToListAsync();
                    foreach (var row in await existingBankLiabilityRows)
                    {
                        if (row.XLCP_Amt == null)
                        {
                            row.XLCP_Amt = 0;
                        }
                        row.XLCP_Amt = row.XLCP_Amt - CCYAmt;
                        row.UpdateDate = DateTime.Now;

                    }
                    await _context.SaveChangesAsync();

                    // RevalueBankLiab(as_bank As String, as_facno As String)
                    var revalueBankLiabilityRows = await (from row in _context.pBankLiabs
                                                          where row.Bank_Code == data.Wref_Bank_ID &&
                                                                row.Facility_No == approveFacility
                                                          group row by new { row.Bank_Code, row.Facility_No, row.Currency } into g
                                                          select new
                                                          {
                                                              g.Key.Bank_Code,
                                                              g.Key.Facility_No,
                                                              g.Key.Currency,
                                                              IMLC_Amt = g.Sum(r => r.IMLC_Amt ?? 0),
                                                              IBLS_Amt = g.Sum(r => r.IBLS_Amt ?? 0),
                                                              IBLT_Amt = g.Sum(r => r.IBLT_Amt ?? 0),
                                                              IMTR_Amt = g.Sum(r => r.IMTR_Amt ?? 0),
                                                              SGBC_Amt = g.Sum(r => r.SGBC_Amt ?? 0),
                                                              SGLC_Amt = g.Sum(r => r.SGLC_Amt ?? 0),
                                                              IMBC_Amt = g.Sum(r => r.IMBC_Amt ?? 0),
                                                              EXPC_Amt = g.Sum(r => r.EXPC_Amt ?? 0),
                                                              XLCP_Amt = g.Sum(r => r.XLCP_Amt ?? 0),
                                                              XLCC_Amt = g.Sum(r => r.XLCC_Amt ?? 0),
                                                              XBCP_Amt = g.Sum(r => r.XBCP_Amt ?? 0),
                                                              XBCC_Amt = g.Sum(r => r.XBCC_Amt ?? 0),
                                                              IMLC_Book = g.Sum(r => r.IMLC_Book ?? 0),
                                                              IBLS_Book = g.Sum(r => r.IBLS_Book ?? 0),
                                                              IBLT_Book = g.Sum(r => r.IBLT_Book ?? 0),
                                                              IMTR_Book = g.Sum(r => r.IMTR_Book ?? 0),
                                                              SGBC_Book = g.Sum(r => r.SGBC_Book ?? 0),
                                                              SGLC_Book = g.Sum(r => r.SGLC_Book ?? 0),
                                                              IMBC_Book = g.Sum(r => r.IMBC_Book ?? 0),
                                                              EXPC_Book = g.Sum(r => r.EXPC_Book ?? 0),
                                                              XLCP_Book = g.Sum(r => r.XLCP_Book ?? 0),
                                                              XLCC_Book = g.Sum(r => r.XLCC_Book ?? 0),
                                                              XBCP_Book = g.Sum(r => r.XBCP_Book ?? 0),
                                                              XBCC_Book = g.Sum(r => r.XBCC_Book ?? 0),
                                                              IMBL_Over = g.Sum(r => r.IMBL_Over ?? 0),
                                                              NLTR_Book = g.Sum(r => r.NLTR_Book ?? 0),
                                                              NTTR_Book = g.Sum(r => r.NTTR_book ?? 0),
                                                              DLC_Amt = g.Sum(r => r.DLC_Amt ?? 0),
                                                              DLC_Book = g.Sum(r => r.DLC_Book ?? 0),
                                                              NDTR_Book = g.Sum(r => r.NDTR_Book ?? 0),
                                                              DBE_Amt = g.Sum(r => r.DBE_Amt ?? 0),
                                                              DBE_Book = g.Sum(r => r.DBE_Book ?? 0),
                                                              SBLC_Amt = g.Sum(r => r.SBLC_Amt ?? 0),
                                                              SBLC_Book = g.Sum(r => r.SBLC_Book ?? 0),
                                                              LG_Amt = g.Sum(r => r.LG_Amt ?? 0),
                                                              LG_Book = g.Sum(r => r.LG_Book ?? 0),
                                                              TROA_Amt = g.Sum(r => r.TROA_Amt ?? 0),
                                                              TRLC_Amt = g.Sum(r => r.TRLC_Amt ?? 0),
                                                              TRBC_Amt = g.Sum(r => r.TRBC_Amt ?? 0),
                                                              TRDLC_Amt = g.Sum(r => r.TRDLC_Amt ?? 0),
                                                              NCTR_Book = g.Sum(r => r.NCTR_Book ?? 0),
                                                              SGBC_Issued = g.Sum(r => r.SGBC_Issued ?? 0)
                                                          }).ToListAsync();

                    double cRateEx1 = 0;
                    double cRateEx2 = 0;
                    double cRateEx3 = 0;
                    var tmpCust = "";
                    foreach (var row in revalueBankLiabilityRows)
                    {
                        if (row.Currency == "THB" || row.Currency == "ODU")
                        {
                            cRateEx1 = 1;
                            cRateEx2 = 1;
                            cRateEx3 = 1;
                        }
                        else
                        {
                            cRateEx3 = GetExchangeRate(_context, row.Currency);
                        }

                        // Delete First
                        if (row.Bank_Code != tmpCust)
                        {
                            var pBankLsumRow = (from row2 in _context.pBankLSums
                                                where row2.Bank_Code == row.Bank_Code &&
                                                      row2.Facility_No == approveFacility
                                                select row2).ToListAsync();
                            foreach (var row3 in await pBankLsumRow)
                            {
                                _context.Remove(row3);
                            }
                            await _context.SaveChangesAsync();
                        }

                        // Add if not exists
                        var isPBankLsumsExists = (from row2 in _context.pBankLSums
                                                  where row2.Bank_Code == row.Bank_Code &&
                                                        row2.Facility_No == approveFacility
                                                  select row2).Count();
                        if (isPBankLsumsExists == 0)
                        {
                            pBankLSum newRow = new();
                            newRow.Bank_Code = row.Bank_Code;
                            newRow.Facility_No = approveFacility;

                            newRow.IMLC_Amt = (newRow.IMLC_Amt ?? 0) + (row.IMLC_Amt * cRateEx3);
                            newRow.IBLS_Amt = (newRow.IBLS_Amt ?? 0) + (row.IBLS_Amt * cRateEx3);
                            newRow.IBLT_Amt = (newRow.IBLT_Amt ?? 0) + (row.IBLT_Amt * cRateEx3);
                            newRow.IMTR_Amt = (newRow.IMTR_Amt ?? 0) + (row.IMTR_Amt * cRateEx3);
                            newRow.SGBC_Amt = (newRow.SGBC_Amt ?? 0) + (row.SGBC_Amt * cRateEx3);
                            newRow.IMBC_Amt = (newRow.IMBC_Amt ?? 0) + (row.IMBC_Amt * cRateEx3);
                            newRow.SGLC_Amt = (newRow.SGLC_Amt ?? 0) + (row.SGLC_Amt * cRateEx3);
                            newRow.EXPC_Amt = (newRow.EXPC_Amt ?? 0) + (row.EXPC_Amt * cRateEx3);
                            newRow.XLCP_Amt = (newRow.XLCP_Amt ?? 0) + (row.XLCP_Amt * cRateEx3);
                            newRow.XLCC_Amt = (newRow.XLCC_Amt ?? 0) + (row.XLCC_Amt * cRateEx3);
                            newRow.XBCP_Amt = (newRow.XBCP_Amt ?? 0) + (row.XBCP_Amt * cRateEx3);
                            newRow.XBCC_Amt = (newRow.XBCC_Amt ?? 0) + (row.XBCC_Amt * cRateEx3);
                            newRow.DLC_Amt = (newRow.DLC_Amt ?? 0) + (row.DLC_Amt * cRateEx3);
                            newRow.DBE_Amt = (newRow.DBE_Amt ?? 0) + (row.DBE_Amt * cRateEx3);
                            newRow.SBLC_Amt = (newRow.SBLC_Amt ?? 0) + (row.SBLC_Amt * cRateEx3);
                            newRow.LG_Amt = (newRow.LG_Amt ?? 0) + (row.LG_Amt * cRateEx3);
                            newRow.TRLC_Amt = (newRow.TRLC_Amt ?? 0) + (row.TRLC_Amt * cRateEx3);
                            newRow.TRDLC_Amt = (newRow.TRDLC_Amt ?? 0) + (row.TRDLC_Amt * cRateEx3);
                            newRow.TRBC_Amt = (newRow.TRBC_Amt ?? 0) + (row.TRBC_Amt * cRateEx3);
                            newRow.TROA_Amt = (newRow.TROA_Amt ?? 0) + (row.TROA_Amt * cRateEx3);

                            newRow.IMLC_Book = (newRow.IMLC_Book ?? 0) + (row.IMLC_Book * cRateEx3);
                            newRow.IBLS_Book = (newRow.IBLS_Book ?? 0) + (row.IBLS_Book * cRateEx3);
                            newRow.IBLT_Book = (newRow.IBLT_Book ?? 0) + (row.IBLT_Book * cRateEx3);
                            newRow.IMTR_Book = (newRow.IMTR_Book ?? 0) + (row.IMTR_Book * cRateEx3);
                            newRow.SGBC_Book = (newRow.SGBC_Book ?? 0) + (row.SGBC_Book * cRateEx3);
                            newRow.DLC_Book = (newRow.DLC_Book ?? 0) + (row.DLC_Book * cRateEx3);
                            newRow.DBE_Book = (newRow.DBE_Book ?? 0) + (row.DBE_Book * cRateEx3);
                            newRow.IMBC_Book = (newRow.IMBC_Book ?? 0) + (row.IMBC_Book * cRateEx3);
                            newRow.SGLC_Book = (newRow.SGLC_Book ?? 0) + (row.SGLC_Book * cRateEx3);
                            newRow.EXPC_Book = (newRow.EXPC_Book ?? 0) + (row.EXPC_Book * cRateEx3);
                            newRow.XLCP_Book = (newRow.XLCP_Book ?? 0) + (row.XLCP_Book * cRateEx3);
                            newRow.XLCC_Book = (newRow.XLCC_Book ?? 0) + (row.XLCC_Book * cRateEx3);
                            newRow.XBCP_Book = (newRow.XBCP_Book ?? 0) + (row.XBCP_Book * cRateEx3);
                            newRow.XBCC_Book = (newRow.XBCC_Book ?? 0) + (row.XBCC_Book * cRateEx3);
                            newRow.SBLC_Book = (newRow.SBLC_Book ?? 0) + (row.SBLC_Book * cRateEx3);
                            newRow.LG_Book = (newRow.LG_Book ?? 0) + (row.LG_Book * cRateEx3);

                            newRow.IMBL_Over = (newRow.IMBL_Over ?? 0) + (row.IMBL_Over * cRateEx3);
                            newRow.NLTR_book = (newRow.NLTR_book ?? 0) + (row.NLTR_Book * cRateEx3);
                            newRow.NTTR_Book = (newRow.NTTR_Book ?? 0) + (row.NTTR_Book * cRateEx3);
                            newRow.NCTR_Book = (newRow.NCTR_Book ?? 0) + (row.NCTR_Book * cRateEx3);
                            newRow.NDTR_Book = (newRow.NDTR_Book ?? 0) + (row.NDTR_Book * cRateEx3);
                            newRow.SGBC_Issued = (newRow.SGBC_Issued ?? 0) + (row.SGBC_Issued * cRateEx3);

                            newRow.UpdateDate = GetSysDate(_context);
                            _context.Add(newRow);
                        }

                        await _context.SaveChangesAsync();

                    }

                    transaction.Complete();
                    return true;
                }
                catch (Exception e)
                {
                    // Rollback
                    return false;
                }
            }
        }
        public static bool SaveExDoc(ISPTFContext _context, pExlc lc, pExdoc[] pExdocs)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
    
                    var existingPExDoc = (from row in _context.pExdocs
                                          where row.EXLC_NO == lc.EXPORT_LC_NO && row.EVENT_NO ==lc.EVENT_NO
                                              select row).ToList();

                    foreach (var row in existingPExDoc)
                    {
                        _context.pExdocs.Remove(row);
                    }

                    _context.SaveChanges();
                    
                    // Save pExdocs[]
                    if (pExdocs != null)
                    {
                        for (int i = 0; i < pExdocs.Length; i++)
                        {
                            pExdocs[i].EVENT_NO = lc.EVENT_NO;
                        }
                        foreach (var row in pExdocs)
                        {
                            _context.pExdocs.Add(row);
                        }

                        _context.SaveChanges();
                    }
                    transaction.Complete();
                    return true;
                }
                catch (Exception e)
                {
                    // Rollback
                    return false;
                }

            }
        }//exdoc
    }
}
