using Dapper;
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
        public async Task<ActionResult<EXLCCoveringLetterListResponse>> GetAllList(string? @ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        {
            EXLCCoveringLetterListResponse response = new EXLCCoveringLetterListResponse();

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

        [HttpPost("save")]
        public async Task<ActionResult<PEXLCSaveResponse>> Save([FromBody] PEXLCSaveRequest data)
        {
            PEXLCSaveResponse response = new();
            // Class validate

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
                        pExlcMaster.REC_STATUS = "P";
                        pExlcMaster.DMS = data.PEXLC.DMS;
                        _context.SaveChanges();

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
                        eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = DateTime.Now; // With Time
                        eventRow.IN_USE = 1;

                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = DateTime.Today; // Without Time
                        eventRow.VOUCH_ID = "COVERING";

                        // Commit
                        if (pExlcEvent == null) {
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

                        PEXLCDataContainer responseData = new();
                        responseData.PEXLC = eventRow;

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
                        if (data.IS_AUTO == false)
                        {
                            var pExlcNotInUse = (from row in _context.pExlcs
                                                 where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                       row.RECORD_TYPE == "MASTER" &&
                                                       row.IN_USE == 0
                                                 select row).FirstOrDefault();
                            pExlcNotInUse.REC_STATUS = "R";
                        }
                        else if (data.IS_AUTO == true)
                        {
                            pExlc.DMS = null;
                        }

                        // 3 - Delete pSWExport
                        var pSWExports = (from row in _context.pSWExports
                                          where row.DocNo == data.EXPORT_LC_NO &&
                                                row.Event_No == targetEventNo
                                          select row).ToListAsync();

                        foreach (var row in await pSWExports)
                        {
                            _context.pSWExports.Remove(row);
                        }

                        // Commit
                        await _context.SaveChangesAsync();
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
