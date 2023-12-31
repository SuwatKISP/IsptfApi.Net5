﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.ExportLC;
using ISPTF.Models.PurchasePayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models.ExportLC.ReverseCollection;
using System.Text.Json;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCReverseCollectionController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "10";
        private const string EVENT_TYPE = "Reverse";
        public EXLCReverseCollectionController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCReverseCollectionListResponse>> List(string? @ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCReverseCollectionListResponse response = new EXLCReverseCollectionListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) ||
                string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(Page) ||
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCReverseCollectionListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXLCReverseCollectionListPageRsp>();
                return BadRequest(response);
            }

            // Call Procedure

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

                var results = await _db.LoadData<Q_EXLCReverseCollectionListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_ReverseCollectionListPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCReverseCollectionListPageRsp>)results;

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
                response.Data = new List<Q_EXLCReverseCollectionListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("select")]
        public async Task<ActionResult<EXLCReverseCollectionSelectResponse>> Select(string? EXPORT_LC_NO, int? EVENT_NO, string? LFROM)
        {
            EXLCReverseCollectionSelectResponse response = new EXLCReverseCollectionSelectResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) ||
                EVENT_NO == null ||
                string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXLCRecordRsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@EVENT_NO", EVENT_NO);
                //param.Add("@RECORD_TYPE", RECORD_TYPE);
                //param.Add("@REC_STATUS", REC_STATUS);
                param.Add("@LFROM", LFROM);

                //var results = await _db.LoadData<PEXLCRsp, dynamic>(
                //            storedProcedure: "usp_pEXLC_ReverseCollection_Select",
                //            param);
                //return results;
                param.Add("@PEXLCRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);
                param.Add("@PEXLCRecordRsp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);

                var results = await _db.LoadData<PEXLCRecordRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_ReverseCollection_Select",
                           param);

                var PEXLCRsp = param.Get<dynamic>("@PEXLCRsp");
                var pexlrecordrsp = param.Get<dynamic>("@PEXLCRecordRsp");


                if (PEXLCRsp > 0 && !string.IsNullOrEmpty(pexlrecordrsp))
                {
                    PEXLCRecordRsp jsonResponse = JsonSerializer.Deserialize<PEXLCRecordRsp>(pexlrecordrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT L/C NO does not exit";
                    response.Data = new PEXLCRecordRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCRecordRsp();
            }
            return BadRequest(response);

        }

        [HttpPost("save")]
        public async Task<ActionResult<PEXLCSaveResponse>> Save([FromBody] PEXLCSaveRequest data)
        {
            PEXLCSaveResponse response = new();
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
                            response.Message = "PEXLC Issue Collect Master does not exists";
                            return BadRequest(response);
                        }

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'P' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");

                        var targetEventNo = pExlcMaster.EVENT_NO + 1;

                        // 2 - Insert EVENT
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlc eventRow = data.PEXLC;


                        // 3 - Select Existing Event
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                (row.REC_STATUS == "P") &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).AsNoTracking().FirstOrDefault();

                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_NO = targetEventNo;
                        eventRow.EVENT_MODE = "E";
                        eventRow.REC_STATUS = "P";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                        eventRow.IN_USE =0;
                        // eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = UpdateDateT; // With Time
                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE =UpdateDateNT; // Without Time


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


                        // GL MOCK WAIT DLL

                        //var glEvent = EVENT_TYPE.ToUpper();
                        //if (eventRow.WithOutFlag == "Y")
                        //{
                        //    if (eventRow.WithOutType == "U")
                        //    {
                        //        glEvent = EVENT_TYPE + "-UNISB";
                        //    }
                        //    else if (eventRow.WithOutType == "A")
                        //    {
                        //        glEvent = EVENT_TYPE + "-UNAGB";
                        //    }
                        //}

                        //var glVouchId = "VOUCH ID FROM GL DLL" + " " + glEvent;
                        //eventRow.VOUCH_ID = glVouchId;
                        //await _context.SaveChangesAsync();

                        transaction.Complete();
                        transaction.Dispose();
                        // Call PrintPostGL (Crystal Report)

                        response.Code = Constants.RESPONSE_OK;

                        PEXLCDataContainer responseData = new();
                        responseData.PEXLC = eventRow;

                        response.Data = responseData;
                        //response.Message = "Export L/C Saved";
                        //return Ok(response);

                        bool resGL;
                        bool resPayD;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = response.Data.PEXLC.EVENT_TYPE;
                        eventDate = response.Data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");

                        resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO,
                        eventDate,
                        response.Data.PEXLC.EVENT_TYPE,
                        response.Data.PEXLC.EVENT_NO,
                        response.Data.PEXLC.EVENT_TYPE,false,"U");
                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                            response.Data.PEXLC.VOUCH_ID = resVoucherID;
                        }
                        else
                        {
                            resGL = false;
                        }

                        response.Message = "Export L/C Saved";
                        return Ok(response);

                    }
                    catch (Exception e)
                    {
                        if (e.InnerException != null &&
                            e.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
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
                                           select row).FirstOrDefault();

                        // 1 - Check if Master Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }


                        // 2 - Update Master
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlcMaster.AUTH_CODE = USER_ID;
                        pExlcMaster.AUTH_DATE = UpdateDateNT; // With Time
                        pExlcMaster.BUSINESS_TYPE = BUSINESS_TYPE;
                        pExlcMaster.EVENT_MODE = "E";
                        pExlcMaster.EVENT_TYPE = EVENT_TYPE;
                        pExlcMaster.USER_ID = USER_ID;
                        pExlcMaster.UPDATE_DATE = UpdateDateT;
                        pExlcMaster.VOUCH_ID = data.PEXLC.VOUCH_ID;
                        pExlcMaster.GENACC_FLAG = "Y";
                        pExlcMaster.GENACC_DATE = data.PEXLC.GENACC_DATE;
                        _context.pExlcs.Update(pExlcMaster);
                        await _context.SaveChangesAsync();

                        // 3 - Update Master/Event PK to Release

                       // await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'C' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");


                        // 4 - Update GL Flag
                        var gls = (from row in _context.pDailyGLs
                                   where row.VouchID == data.PEXLC.VOUCH_ID &&
                                         row.VouchDate == data.PEXLC.EVENT_DATE.GetValueOrDefault().Date
                                   select row).ToListAsync();

                        foreach (var row in await gls)
                        {
                            row.SendFlag = "R";
                        }
                        await _context.SaveChangesAsync();

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


                        // 5 - Update EVENT

                        pExlc eventRow = data.PEXLC;
                        eventRow.REC_STATUS = "P";
                        eventRow.EVENT_MODE = "E";
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.TENOR_TYPE = pExlcMaster.TENOR_TYPE;
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.AUTH_CODE = USER_ID;
                        eventRow.AUTH_DATE = UpdateDateT; // With Time
                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = UpdateDateNT; // Without Time
                        _context.pExlcs.Update(eventRow);
                        await _context.SaveChangesAsync();

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'C' , EVENT_NO = {eventRow.EVENT_NO} WHERE EXPORT_LC_NO = '{eventRow.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R'  WHERE EXPORT_LC_NO = '{eventRow.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE='{EVENT_TYPE}' and  EVENT_NO = {eventRow.EVENT_NO}");

                        transaction.Complete();
                        transaction.Dispose();

                        string resCustLiab;
                        string eventDate;
                        eventDate = data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        resCustLiab = ISPModule.CustLiabEXLC.EXLC_ReverseIssue(eventDate, "COLLECT", "SAVE", data.PEXLC.EXPORT_LC_NO, data.PEXLC.BENE_ID,"","", data.PEXLC.DRAFT_CCY, data.PEXLC.DRAFT_AMT.ToString(), data.PEXLC.TOT_NEGO_AMT.ToString(),"");

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
        public async Task<ActionResult<EXLCResultResponse>> Delete([FromBody] PEXLCDeleteRequest data)
        {
            EXLCResultResponse response = new EXLCResultResponse();
            DynamicParameters param = new();

            // Validate
            if (string.IsNullOrEmpty(data.EXPORT_LC_NO) ||
                string.IsNullOrEmpty(data.EVENT_DATE)
                )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_DATE is required";
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


                        // 1 - Delete Daily GL
                        var dailyGL = (from row in _context.pDailyGLs
                                       where row.VouchID == data.VOUCH_ID &&
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 2 - Update pExlc EVENT
                        var pExlcs = (from row in _context.pExlcs
                                      where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                            row.EVENT_TYPE == EVENT_TYPE &&
                                            row.REC_STATUS == "P" &&
                                            row.RECORD_TYPE == "EVENT"
                                      select row).ToListAsync();

                        foreach (var row in await pExlcs)
                        {
                            _context.pExlcs.Remove(row);
                        }


                        // 3 - Delete PExPayment
                        var targetEventNo = pExlc.EVENT_NO + 1;
                        var pExPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.EXPORT_LC_NO &&
                                                 row.EVENT_TYPE == EVENT_TYPE &&
                                                 row.EVENT_NO == targetEventNo
                                           select row).ToListAsync();

                        foreach (var row in await pExPayments)
                        {
                            _context.pExPayments.Remove(row);
                        }

                        // 4 - Update pExlc Master

                        // Commit
                        await _context.SaveChangesAsync();

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R' WHERE EXPORT_LC_NO = '{data.EXPORT_LC_NO}' AND RECORD_TYPE = 'MASTER'");

                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export L/C Deleted";
                    return Ok(response);
                }
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
