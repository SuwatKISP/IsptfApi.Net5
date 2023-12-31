﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.ExportLC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCCoveringLetterController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "3";
        private const string EVENT_TYPE = "Covering";
        public EXLCCoveringLetterController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCCoveringLetterListResponse>> GetAllList(string? @ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCCoveringLetterListResponse response = new EXLCCoveringLetterListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(@ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCCoveringLetterListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@ListType", @ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENName", BENName);
                param.Add("@USER_ID", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENName == null)
                {
                    param.Add("@BENName", "");
                }

                var results = await _db.LoadData<Q_EXLCCoveringLetterListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_CoveringLetterListPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCCoveringLetterListPageRsp>)results;

                try
                {
                    response.Page = int.Parse(Page);
                    response.Total = response.Data[0].RCount;
                    response.TotalPage = Convert.ToInt32(Math.Ceiling(response.Total / decimal.Parse(PageSize)));
                }
                catch (Exception)
                {
                    response.Page = 0;
                    response.Total = 0;
                    response.TotalPage = 0;
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<Q_EXLCCoveringLetterListPageRsp>();
            }
            return response;
        }

        //[HttpGet("query")]
        //public async Task<IEnumerable<Q_EXBCCoveringLetterQueryPageRsp>> GetAllQuery(string? @ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@ListType", @ListType);
        //    param.Add("@CenterID", CenterID);
        //    param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
        //    param.Add("@BENName", BENName);
        //    param.Add("@USER_ID", USER_ID);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (EXPORT_BC_NO == null)
        //    {
        //        param.Add("@EXPORT_BC_NO", "");
        //    }
        //    if (BENName == null)
        //    {
        //        param.Add("@BENName", "");
        //    }

        //    var results = await _db.LoadData<Q_EXBCCoveringLetterQueryPageRsp, dynamic>(
        //                storedProcedure: "usp_q_EXLC_CoveringLetterQueryPage",
        //                param);
        //    return results;
        //}


        [HttpGet("select")]
        public async Task<ActionResult<EXLCCoveringLetterSelectResponse>> GetAllSelect(string? EXPORT_LC_NO, int? EVENT_NO, string? RECORD_TYPE, string? REC_STATUS, string? LFROM)
        {
            EXLCCoveringLetterSelectResponse response = new EXLCCoveringLetterSelectResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) || EVENT_NO == null || string.IsNullOrEmpty(REC_STATUS) || string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, EVENT_NO, REC_STATUS, LFROM is required";
                response.Data = new PEXLC_PSWExport_PEXDOC_Rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@EVENT_NO", EVENT_NO);
                param.Add("@RECORD_TYPE", RECORD_TYPE);
                param.Add("@REC_STATUS", REC_STATUS);
                param.Add("@LFROM", LFROM);

                param.Add("@CoveringRsp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);
                param.Add("@CoveringLetterJSONRsp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);


                var results = await _db.LoadData<PEXLC_PSWExport_PEXDOC_Rsp, dynamic>(
                               storedProcedure: "usp_pEXLC_CoveringLetter_Select",
                               param);

                var CoveringRsp = param.Get<dynamic>("@CoveringRsp");
                var coveringletterjsonrsp = param.Get<dynamic>("@CoveringLetterJSONRsp");

                if (CoveringRsp > 0 && !string.IsNullOrEmpty(coveringletterjsonrsp))
                {
                    PEXLC_PSWExport_PEXDOC_Rsp jsonResponse = JsonSerializer.Deserialize<PEXLC_PSWExport_PEXDOC_Rsp>(coveringletterjsonrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Error selecting covering letter";
                    response.Data = new PEXLC_PSWExport_PEXDOC_Rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLC_PSWExport_PEXDOC_Rsp();
            }
            return BadRequest(response);
        }

        [HttpGet("GetBeneCovering")]
        public async Task<IEnumerable<PEXLCGetBeneCovering>> GetAddr(string? as_bene )
        {
            DynamicParameters param = new();
            EXLCCoveringLetterSelectResponse response = new EXLCCoveringLetterSelectResponse();
            param.Add("@as_bene", as_bene);

            var results = await _db.LoadData<PEXLCGetBeneCovering, dynamic>(
                           storedProcedure: "usp_pEXBC_CoveringLetter_GetBeneCovering",
                           param);
            return results;
        }
        [HttpPost("save")]
        public async Task<ActionResult<PEXLCSaveCoveringResponse>> Save([FromBody] PEXLCSaveCoveringRequest data)
        {
            PEXLCSaveCoveringResponse response = new();
            // Class validate
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {

                        // 0 - Select EXLC Master
                        var pExlcMaster = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                 row.RECORD_TYPE == "MASTER"
                                           select row).FirstOrDefault();

                        // 1 - Check if Master Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }

                        // 2 - Update Master
                        pExlcMaster.DMS = data.PEXLC.DMS;
                        _context.SaveChanges();

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'P' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");


                        var targetEventNo = pExlcMaster.EVENT_NO + 1;

                        // 3 - Select Existing EVENT
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                row.REC_STATUS == "P" &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).AsNoTracking().FirstOrDefault();


                        // 3 - Insert/Update EVENT
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlc eventRow = data.PEXLC;

                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_NO = targetEventNo;
                        eventRow.REC_STATUS = "P";
                        eventRow.EVENT_MODE = "E";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                        eventRow.EVENT_DATE = UpdateDateNT; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = UpdateDateT; // With Time
                        eventRow.IN_USE = 0;

                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = UpdateDateNT; // Without Time
                        eventRow.VOUCH_ID = "COVERING";
                        if (eventRow.NET_PROCEED_CLAIM == null)
                        {
                            eventRow.NET_PROCEED_CLAIM = 0;
                        }
                        if (eventRow.ADJ_TOT_NEGO_AMOUNT == null)
                        {
                            eventRow.ADJ_TOT_NEGO_AMOUNT = 0;
                        }
                        if (eventRow.ADJ_LESS_CHARGE_AMT == null)
                        {
                            eventRow.ADJ_LESS_CHARGE_AMT = 0;
                        }
                        if (eventRow.LESS_AGENT == null)
                        {
                            eventRow.LESS_AGENT = 0;
                        }
                        if (eventRow.BANK_CHARGE_AMT == null)
                        {
                            eventRow.BANK_CHARGE_AMT = 0;
                        }
                        if (eventRow.NEGO_AMT == null)
                        {
                            eventRow.NEGO_AMT = 0;
                        }
                        // Call Save pExDoc


                        bool savepEXDocResult = ExportLCHelper.SaveExDoc(_context, eventRow, data.PEXDOC);

                        //save swift
                        // Save SWIFT
                        if (data.PSWEXPORT!=null)
                        {
                            var pSWExportEvent = (from row in _context.pSWExports
                                                  where row.DocNo == eventRow.EXPORT_LC_NO &&
                                                        row.Event_No == eventRow.EVENT_NO
                                                  select row).AsNoTracking().FirstOrDefault();
                            bool swNew=false;
                            if (pSWExportEvent == null)
                            {
                                swNew = true;
                            }
                            if (swNew==true)
                            {
                                pSWExportEvent = new();
                                pSWExportEvent.AutoNum = EXHelper.GenSWNo(_context);
                                pSWExportEvent.DocNo = eventRow.EXPORT_LC_NO;
                                pSWExportEvent.Event_No = eventRow.EVENT_NO;
                                pSWExportEvent.Event = "COVERING";
                                pSWExportEvent.SwiftFile = "TFF" + eventRow.EXPORT_LC_NO + eventRow.EVENT_NO.ToString("00") + "-" + eventRow.EVENT_DATE.Value.ToString("MMdd") + DateTime.Now.ToString("hhmm");
                                pSWExportEvent.F53A = eventRow.REIMBURSE_BANK_ID;
                                pSWExportEvent.F52A = eventRow.ISSUE_BANK_ID;
                                pSWExportEvent.F52D = data.PSWEXPORT.BankInFo;//note
                                pSWExportEvent.F57A = eventRow.AGENT_BANK_ID;
                                pSWExportEvent.F57D = eventRow.AGENT_BANK_INFO;
                            }
                            pSWExportEvent.RemitCcy = data.PSWEXPORT.RemitCcy;
                            pSWExportEvent.RemitAmt = data.PSWEXPORT.RemitAmt;
                            pSWExportEvent.ValueDate = data.PSWEXPORT.ValueDate;
                            pSWExportEvent.F20 = data.PSWEXPORT.F20;
                            pSWExportEvent.BankID = data.PSWEXPORT.BankID;
                            pSWExportEvent.BankInFo = data.PSWEXPORT.BankInFo;
                            pSWExportEvent.NBankID = data.PSWEXPORT.NBankID;
                            pSWExportEvent.NBankInfo = data.PSWEXPORT.NBankInfo;

                            pSWExportEvent.F31 = eventRow.EVENT_DATE.Value.ToString("yyMMdd");
                            pSWExportEvent.MT742 = "N";
                            pSWExportEvent.MT499 = "N";
                            if (eventRow.CLAIM_FORMAT == "MT742")
                            {
                                pSWExportEvent.MT742 = "Y";
                            }
                            else if (eventRow.CLAIM_FORMAT == "MT499")
                            {
                                pSWExportEvent.MT499 = "Y";
                            }

                            pSWExportEvent.MT799 = data.PSWEXPORT.MT799;
                            pSWExportEvent.MT999 = data.PSWEXPORT.MT999;
                            if (swNew == true)
                            {
                                _context.pSWExports.Add(pSWExportEvent);
                            }
                            else
                            {
                                _context.pSWExports.Update(pSWExportEvent);
                            }
                      
                        }//pswexport 
    


                        // Commit
                        if (pExlcEvent == null)
                        {
                            // Insert
                            _context.pExlcs.Add(eventRow);
                        }
                        else
                        {
                            // Update
                            _context.pExlcs.Update(eventRow);
                        }


                        await _context.SaveChangesAsync();
                        transaction.Complete();

                        response.Code = Constants.RESPONSE_OK;

                        PEXLCSaveCoveringDataContainer responseData = new();
                        responseData.PEXLC = eventRow;
                        responseData.PSWEXPORT = data.PSWEXPORT;
                        responseData.PEXDOC = data.PEXDOC;
                        response.Data = responseData;
                        response.Message = "Export L/C Saved";
                        return Ok(response);
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException != null
                            && e.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
                        {
                            // Key already exists
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC " + EVENT_TYPE + " Event Already exists / Wrong Event State";
                            return BadRequest(response);
                        }
                        else
                        {
                            // Rollback
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = e.ToString();
                            return BadRequest(response);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }
        }


        [HttpPost("release")]
        public async Task<ActionResult<EXLCResultResponse>> Release([FromBody] PEXLCSaveRequest data)
        {
            EXLCResultResponse response = new();
            // Class validate
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {

                        // 0 - Select EXLC Master
                        var pExlcMaster = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                 row.RECORD_TYPE == "MASTER"
                                           select row).AsNoTracking().FirstOrDefault();

                        // 1 - Check if Master Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }

                        var targetEventNo = pExlcMaster.EVENT_NO + 1;

                        // 2 - Select Existing EVENT
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                row.REC_STATUS == "P" &&
                                                row.BUSINESS_TYPE == BUSINESS_TYPE &&
                                                row.EVENT_NO == data.PEXLC.EVENT_NO
                                          select row).AsNoTracking().FirstOrDefault();

                        // 3 - Check Event Exists
                        if (pExlcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC " + EVENT_TYPE + " Event does not exists";
                            return BadRequest(response);
                        }


                        // 3 - Insert/Update EVENT
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlc eventRow =data.PEXLC;

                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_MODE = "E";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                        eventRow.AUTH_CODE = USER_ID;
                        eventRow.AUTH_DATE = UpdateDateT; // With Time

                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = UpdateDateNT; // Without Time
                        eventRow.VOUCH_ID = "COVERING";
                        _context.pExlcs.Update(eventRow);
                        //await _context.SaveChangesAsync();

                        // 4 - Update Master
                        pExlcMaster.GENACC_FLAG = "Y";
                        pExlcMaster.GENACC_DATE = UpdateDateNT; // Without Time
                        pExlcMaster.VOUCH_ID = "COVERING";
                        pExlcMaster.BUSINESS_TYPE = BUSINESS_TYPE;
                        pExlcMaster.EVENT_TYPE = EVENT_TYPE;
                        pExlcMaster.EVENT_MODE = "E";
                        pExlcMaster.VOUCH_ID = "COVERING";
                        pExlcMaster.USER_ID = USER_ID;
                        pExlcMaster.AUTH_CODE = USER_ID;
                        pExlcMaster.AUTH_DATE = UpdateDateT; // With Time
                        pExlcMaster.UPDATE_DATE = UpdateDateT; // With Time
                        pExlcMaster.IN_USE = 0;
                        pExlcMaster.LC_DATE = eventRow.LC_DATE;
                        pExlcMaster.COVERING_DATE = eventRow.COVERING_DATE;
                        pExlcMaster.COVERING_FOR = eventRow.COVERING_FOR;
                        pExlcMaster.ADVICE_ISSUE_BANK = eventRow.ADVICE_ISSUE_BANK;
                        pExlcMaster.ADVICE_FORMAT = eventRow.ADVICE_FORMAT;
                        pExlcMaster.REMIT_CLAIM_TYPE = eventRow.REMIT_CLAIM_TYPE;
                        pExlcMaster.REIMBURSE_BANK_ID = eventRow.REIMBURSE_BANK_ID;
                        pExlcMaster.REIMBURSE_BANK_INFO = eventRow.REIMBURSE_BANK_INFO;
                        pExlcMaster.SWIFT_BANK = eventRow.SWIFT_BANK;
                        pExlcMaster.CLAIM_FORMAT = eventRow.CLAIM_FORMAT;
                        pExlcMaster.ISSUE_BANK_ID = eventRow.ISSUE_BANK_ID;
                        pExlcMaster.AGENT_BANK_ID = eventRow.AGENT_BANK_ID;
                        pExlcMaster.AGENT_BANK_INFO = eventRow.AGENT_BANK_INFO;
                        pExlcMaster.AGENT_BANK_REF = eventRow.AGENT_BANK_REF;
                        pExlcMaster.THIRD_BANK_ID = eventRow.THIRD_BANK_ID;
                        pExlcMaster.THIRD_BANK_INFO = eventRow.THIRD_BANK_INFO;
                        pExlcMaster.ISSUE_BANK_INFO = eventRow.ISSUE_BANK_INFO;
                        pExlcMaster.TXTDOCUMENT = eventRow.TXTDOCUMENT;
                        pExlcMaster.VALUE_DATE = eventRow.VALUE_DATE;
                        pExlcMaster.DISCREPANCY_TYPE = eventRow.DISCREPANCY_TYPE;
                        pExlcMaster.SWIFT_DISC = eventRow.SWIFT_DISC;
                        pExlcMaster.SWIFT_MAIL = eventRow.SWIFT_MAIL;
                        pExlcMaster.DOCUMENT_COPY = eventRow.DOCUMENT_COPY;
                        pExlcMaster.SIGHT_BASIS = eventRow.SIGHT_BASIS;
                        pExlcMaster.ART44A = eventRow.ART44A;
                        pExlcMaster.ENDORSED = eventRow.ENDORSED;
                        pExlcMaster.MT750 = eventRow.MT750;
                        pExlcMaster.ADJ_TOT_NEGO_AMOUNT = eventRow.ADJ_TOT_NEGO_AMOUNT;
                        pExlcMaster.ADJ_LESS_CHARGE_AMT = eventRow.ADJ_LESS_CHARGE_AMT;
                        pExlcMaster.ADJUST_COVERING_AMT = eventRow.ADJUST_COVERING_AMT;
                        pExlcMaster.ADJUST_LC_REF = eventRow.ADJUST_LC_REF;
                        pExlcMaster.ADJUST_TENOR = eventRow.ADJUST_TENOR;
                        pExlcMaster.PAYMENT_INSTRC = eventRow.PAYMENT_INSTRC;
                        pExlcMaster.PAYMENT_INSTRU = eventRow.PAYMENT_INSTRU;

                        _context.pExlcs.Update(pExlcMaster);

                        await _context.SaveChangesAsync();


                        // 5 - Update Master/Event PK to Release
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R' , EVENT_NO = {eventRow.EVENT_NO} WHERE EXPORT_LC_NO = '{eventRow.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R'  WHERE EXPORT_LC_NO = '{eventRow.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE='{EVENT_TYPE}' and  EVENT_NO = {eventRow.EVENT_NO}");


                        transaction.Complete();


                        // TODO: 6 - Copy SWIFT Files


                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export L/C Released";
                        return Ok(response);
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult<EXLCResultResponse>> Delete([FromBody] PEXLCDeleteCoveringRequest data)
        {
            EXLCResultResponse response = new EXLCResultResponse();

            // Validate
            if (string.IsNullOrEmpty(data.EXPORT_LC_NO) ||
                data.IS_AUTO == null
                )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, IS_AUTO is required";
                return BadRequest(response);
            }

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // 0 - Select EXLC MASTER
                        var pExlc = (from row in _context.pExlcs
                                     where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                           row.RECORD_TYPE == "MASTER"
                                     select row).FirstOrDefault();

                        if (pExlc == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export L/C does not exist";
                            return BadRequest(response);
                        }


                        // 1 - Delete Covering EVENT
                        var coveringExlc = (from row in _context.pExlcs
                                            where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                  row.RECORD_TYPE == "EVENT" &&
                                                  row.REC_STATUS == "P" &&
                                                  row.EVENT_TYPE == EVENT_TYPE
                                            select row).ToListAsync();

                        foreach (var row in await coveringExlc)
                        {
                            _context.pExlcs.Remove(row);
                        }

                        // 2 - AUTO Check

                        var targetEventNo = pExlc.EVENT_NO + 1;
                        //if (data.IS_AUTO == false)
                        //{
                        //    //var pExlcNotInUse = (from row in _context.pExlcs
                        //    //                     where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                        //    //                           row.RECORD_TYPE == "MASTER" &&
                        //    //                           row.IN_USE == 0
                        //    //                     select row).FirstOrDefault();
                        //    //pExlcNotInUse.REC_STATUS = "R";
                        //    // 3 - Update PDOCRegister
                        //    var pExlcNotInUse = (from row in _context.pExlcs
                        //                         where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                        //                               row.RECORD_TYPE == "MASTER" 
                        //                         select row).ToListAsync();

                        //    foreach (var row in await pExlcNotInUse)
                        //    {
                        //        row.REC_STATUS = "R";
                        //    }
                        //}
                        //else if (data.IS_AUTO == true)
                        //{
                        //    pExlc.REC_STATUS = "R";
                        //    pExlc.DMS = null;
                        //}
   //                     int targetEventNo2 = targetEventNo;
                        // 3 - Delete pSWExport
                        var pSWExports = (from row in _context.pSWExports
                                          where row.DocNo == data.EXPORT_LC_NO &&
                                                row.Event_No == targetEventNo
                                          select row).ToListAsync();

                        foreach (var row in await pSWExports)
                        {
                            _context.pSWExports.Remove(row);
                        }

                        // 4 - Delete pExdoc
                        var pExDocs = (from row in _context.pExdocs
                                      where row.EXLC_NO == data.EXPORT_LC_NO &&
                                            row.EVENT_NO == targetEventNo
                                      select row).ToListAsync();

                        foreach (var row in await pExDocs)
                        {
                            _context.pExdocs.Remove(row);
                        }
                        await _context.SaveChangesAsync();
                        //await _context.Database.ExecuteSqlRawAsync($"Delete pExlc Where REC_STATUS = 'R', EVENT_NO = {targetEventNo} WHERE EXPORT_LC_NO = '{data.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE='{EVENT_TYPE}'");
                        await _context.Database.ExecuteSqlRawAsync($"update pExlc set DMS =null,REC_STATUS ='R' where EXPORT_LC_NO='{data.EXPORT_LC_NO}' and RECORD_TYPE ='MASTER'");
                        // Commit


                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }
                }
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Export L/C Deleted";
                return Ok(response);

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }
        }
    }
}
