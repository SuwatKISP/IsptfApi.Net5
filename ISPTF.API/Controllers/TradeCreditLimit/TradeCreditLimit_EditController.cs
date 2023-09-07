using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.TradeCreditLimit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.TradeCreditLimit

{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeCreditLimit_EditController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TradeCreditLimit_EditController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("InsGrdPending")]
        public async Task<IEnumerable<InsGrdPendingRsp>> GetInsGrdPending(string? LFacilityNo, string? CustCode, string? CustName, int Page, int PageSize)
        {
            DynamicParameters param = new();

            param.Add("@LFacilityNo", LFacilityNo);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (LFacilityNo == null)
            {
                param.Add("@LFacilityNo", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<InsGrdPendingRsp, dynamic>(
                        storedProcedure: "usp_TredCrLimit_InsGrdPending",
                        param);
            return results;
        }

        [HttpGet("InsGrdFacility")]
        public async Task<IEnumerable<InsGrdFacility_EditCrLimit_Rsp>> GetInsGrdFacility(string? CustCode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);

            var results = await _db.LoadData<InsGrdFacility_EditCrLimit_Rsp, dynamic>(
                        storedProcedure: "usp_TredCrLimit_InsGrdFacility_EditCRLimit",
                        param);
            return results;
        }


        [HttpGet("InsGrdShare")]
        public async Task<IEnumerable<InsGrdShare_EditCrLimitRsp>> InsGrdShare(string? CustCode, string? FacilityNo, string? CallMode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);
            param.Add("Facility_No", FacilityNo);
            param.Add("CallMode", CallMode);

            var results = await _db.LoadData<InsGrdShare_EditCrLimitRsp, dynamic>(
                        storedProcedure: "usp_TredCrLimit_InsGrdShare_EditCRLimit",
                        param);
            return results;
        }

        [HttpGet("InsGrdProduct")]
        public async Task<IEnumerable<InsGrdProduct_EditCrLimit>> GetInsGrdProduct(string? CustCode, string? FacilityNo, string? CallMode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);
            param.Add("Facility_No", FacilityNo);
            param.Add("CallMode", CallMode);

            var results = await _db.LoadData<InsGrdProduct_EditCrLimit, dynamic>(
                        storedProcedure: "usp_TredCrLimit_InsGrdProduct_EditCRLimit",
                        param);
            return results;
        }


        [HttpGet("InsGrdCCS")]
        public async Task<IEnumerable<InsGrdCCS_EditCrLimitRsp>> GetInsGrdCCS(string? CustCode, string? FacilityNo, string? CallMode)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);
            param.Add("Facility_No", FacilityNo);
            param.Add("CallMode", CallMode);

            var results = await _db.LoadData<InsGrdCCS_EditCrLimitRsp, dynamic>(
                        storedProcedure: "usp_TredCrLimit_InsGrdCCS_EditCRLimit",
                        param);
            return results;
        }

        [HttpGet("newselect")]
        //public async Task<IEnumerable<ReleaseCustLisPageRsp>> GetSelect(string? CustCode, string? FacilityNo)
        public async Task<ActionResult<PCustLimitRsp>> GetNewSelect(string? Cust_Code, string? Facility_No)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", Cust_Code);
            param.Add("@Facility_No", Facility_No);

            param.Add("@PCustLimitRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<PCustLimitRsp, dynamic>(
                        storedProcedure: "usp_pCustLimit_Select",
                        param);
            var PCustLimitRsp = param.Get<dynamic>("@PCustLimitRsp");

            return Ok(PCustLimitRsp);
        }

        [HttpGet("select")]
        //public async Task<IEnumerable<ReleaseCustLisPageRsp>> GetSelect(string? CustCode, string? FacilityNo)
        public async Task<ActionResult<PCLogLimitRsp>> GetSelect(string? LCust_Code, string? LFacility_No)
        {
            DynamicParameters param = new();

            param.Add("@LCust_Code", LCust_Code);
            param.Add("@LFacility_No", LFacility_No);

            param.Add("@PCLogLimitRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<PCLogLimitRsp, dynamic>(
                        storedProcedure: "usp_pCLogLimit_Select",
                        param);
            var PCLogLimitRsp = param.Get<dynamic>("@PCLogLimitRsp");

            return Ok(PCLogLimitRsp);
        }


        [HttpPost("save")]
        public async Task<ActionResult<PCLogLimitRsp>> Save([FromBody] PCLogLimitReq pCLogLimitReq)
        {
            DynamicParameters param = new();
            param.Add("@LRecType", pCLogLimitReq.pcloglimit.LRecType);
            param.Add("@LLogSeq", pCLogLimitReq.pcloglimit.LLogSeq);
            param.Add("@LCust_Code", pCLogLimitReq.pcloglimit.LCust_Code);
            param.Add("@LFacility_No", pCLogLimitReq.pcloglimit.LFacility_No);
            param.Add("@LCCS_No", pCLogLimitReq.pcloglimit.LCCS_No);
            param.Add("@LLimit_Code", pCLogLimitReq.pcloglimit.LLimit_Code);
            param.Add("@LUpdNo", pCLogLimitReq.pcloglimit.LUpdNo);
            param.Add("@LStatus", pCLogLimitReq.pcloglimit.LStatus);
            param.Add("@LStartDate", pCLogLimitReq.pcloglimit.LStartDate);
            param.Add("@LExpiryDate", pCLogLimitReq.pcloglimit.LExpiryDate);
            param.Add("@LFacility_Type", pCLogLimitReq.pcloglimit.LFacility_Type);
            param.Add("@LRevol_Flag", pCLogLimitReq.pcloglimit.LRevol_Flag);
            param.Add("@LShare_Flag", pCLogLimitReq.pcloglimit.LShare_Flag);
            param.Add("@LShare_Type", pCLogLimitReq.pcloglimit.LShare_Type);
            param.Add("@LCredit_Ccy", pCLogLimitReq.pcloglimit.LCredit_Ccy);
            param.Add("@LCredit_Amount", pCLogLimitReq.pcloglimit.LCredit_Amount);
            param.Add("@LCredit_Share", pCLogLimitReq.pcloglimit.LCredit_Share);
            param.Add("@LRemark", pCLogLimitReq.pcloglimit.LRemark);
            param.Add("@LBlock_Code", pCLogLimitReq.pcloglimit.LBlock_Code);
            param.Add("@LBlockDate", pCLogLimitReq.pcloglimit.LBlockDate);
            param.Add("@LBlock_Note", pCLogLimitReq.pcloglimit.LBlock_Note);
            param.Add("@LHold_Amount", pCLogLimitReq.pcloglimit.LHold_Amount);
            param.Add("@LEar_Amount", pCLogLimitReq.pcloglimit.LEar_Amount);
            param.Add("@RecStatus", pCLogLimitReq.pcloglimit.RecStatus);
            param.Add("@CreateDate", pCLogLimitReq.pcloglimit.CreateDate);
            //param.Add("@UpdateDate", pCLogLimitReq.pcloglimit.UpdateDate);
            param.Add("@UserCode", pCLogLimitReq.pcloglimit.UserCode);
            //param.Add("@AuthDate", pCLogLimitReq.pcloglimit.AuthDate);
            //param.Add("@AuthCode", pCLogLimitReq.pcloglimit.AuthCode);
            param.Add("@LParent_Id", pCLogLimitReq.pcloglimit.LParent_Id);
            param.Add("@LSseqno", pCLogLimitReq.pcloglimit.LSseqno);
            param.Add("@LCondition", pCLogLimitReq.pcloglimit.LCondition);
            param.Add("@LOrigin_Amount", pCLogLimitReq.pcloglimit.LOrigin_Amount);
            param.Add("@LCFRRate", pCLogLimitReq.pcloglimit.LCFRRate);
            param.Add("@LCFRSpread", pCLogLimitReq.pcloglimit.LCFRSpread);
            param.Add("@LCFRAmount", pCLogLimitReq.pcloglimit.LCFRAmount);
            param.Add("@LCampaign_Code", pCLogLimitReq.pcloglimit.LCampaign_Code);
            param.Add("@LCampaign_EffDate", pCLogLimitReq.pcloglimit.LCampaign_EffDate);

            var dtCust = new DataTable();
            //-----pCLogShare-------------
            dtCust.Columns.Add("@LRecType", typeof(string));
            dtCust.Columns.Add("@LLogSeq", typeof(int));
            dtCust.Columns.Add("@LCust_Code", typeof(string));
            dtCust.Columns.Add("@LFacility_No", typeof(string));
            dtCust.Columns.Add("@LSeqNo", typeof(int));
            dtCust.Columns.Add("@LShare_Cust", typeof(string));
            dtCust.Columns.Add("@LShare_Imp", typeof(string));
            dtCust.Columns.Add("@LShare_Exp", typeof(string));
            dtCust.Columns.Add("@LShare_Dlc", typeof(string));
            dtCust.Columns.Add("@LShare_LG", typeof(string));
            dtCust.Columns.Add("@LShare_Limit", typeof(string));
            dtCust.Columns.Add("@LShare_Credit", typeof(double));
            dtCust.Columns.Add("@LShare_Used", typeof(double));
            dtCust.Columns.Add("@LShare_CCS", typeof(string));
            dtCust.Columns.Add("@LShare_Mode", typeof(string));
            dtCust.Columns.Add("@Status", typeof(string));

            if (pCLogLimitReq.pclogshare != null)
            {
                for (int i = 0; i < pCLogLimitReq.pclogshare.Length; i++)
                {
                    dtCust.Rows.Add(
                        pCLogLimitReq.pclogshare[i].LRecType
                        , pCLogLimitReq.pclogshare[i].LLogSeq
                        , pCLogLimitReq.pclogshare[i].LCust_Code
                        , pCLogLimitReq.pclogshare[i].LFacility_No
                        , pCLogLimitReq.pclogshare[i].LSeqNo
                        , pCLogLimitReq.pclogshare[i].LShare_Cust
                        , pCLogLimitReq.pclogshare[i].LShare_Imp
                        , pCLogLimitReq.pclogshare[i].LShare_Exp
                        , pCLogLimitReq.pclogshare[i].LShare_Dlc
                        , pCLogLimitReq.pclogshare[i].LShare_LG
                        , pCLogLimitReq.pclogshare[i].LShare_Limit
                        , pCLogLimitReq.pclogshare[i].LShare_Credit
                        , pCLogLimitReq.pclogshare[i].LShare_Used
                        , pCLogLimitReq.pclogshare[i].LShare_CCS
                        , pCLogLimitReq.pclogshare[i].LShare_Mode
                        , pCLogLimitReq.pclogshare[i].Status
                        );
                }
            }
            param.Add("@CLogShare", dtCust.AsTableValuedParameter("Type_pCLogShare"));

            //-----pCLogLmProduct
            dtCust = new DataTable();
            dtCust.Columns.Add("@LRecType", typeof(string));
            dtCust.Columns.Add("@LLogSeq", typeof(int));
            dtCust.Columns.Add("@LCust_Code", typeof(string));
            dtCust.Columns.Add("@LFacility_No", typeof(string));
            dtCust.Columns.Add("@LseqNo", typeof(int));
            dtCust.Columns.Add("@LProd_Code", typeof(string));
            dtCust.Columns.Add("@LProd_Limit", typeof(string));
            dtCust.Columns.Add("@LStartDate", typeof(DateTime));
            dtCust.Columns.Add("@LExpiryDate", typeof(DateTime));
            dtCust.Columns.Add("@LProdAmount", typeof(double));
            dtCust.Columns.Add("@LCCS_No", typeof(string));
            dtCust.Columns.Add("@LCCS_Ref", typeof(string));
            dtCust.Columns.Add("@LCCS_Limit", typeof(string));
            if (pCLogLimitReq.pcloglmproduct != null)
            {
                for (int i = 0; i < pCLogLimitReq.pcloglmproduct.Length; i++)
                {
                    dtCust.Rows.Add(
                          pCLogLimitReq.pcloglmproduct[i].LRecType
                        , pCLogLimitReq.pcloglmproduct[i].LLogSeq
                        , pCLogLimitReq.pcloglmproduct[i].LCust_Code
                        , pCLogLimitReq.pcloglmproduct[i].LFacility_No
                        , pCLogLimitReq.pcloglmproduct[i].LseqNo
                        , pCLogLimitReq.pcloglmproduct[i].LProd_Code
                        , pCLogLimitReq.pcloglmproduct[i].LProd_Limit
                        , pCLogLimitReq.pcloglmproduct[i].LStartDate
                        , pCLogLimitReq.pcloglmproduct[i].LExpiryDate
                        , pCLogLimitReq.pcloglmproduct[i].LProdAmount
                        , pCLogLimitReq.pcloglmproduct[i].LCCS_No
                        , pCLogLimitReq.pcloglmproduct[i].LCCS_Ref
                        , pCLogLimitReq.pcloglmproduct[i].LCCS_Limit
                        );
                }
            }
            param.Add("@CLogProduct", dtCust.AsTableValuedParameter("Type_pCLogLmProduct"));

            //-----pCLogLmCCS
            dtCust = new DataTable();
            dtCust.Columns.Add("@LRecType", typeof(string));
            dtCust.Columns.Add("@LLogSeq", typeof(int));
            dtCust.Columns.Add("@LCust_Code", typeof(string));
            dtCust.Columns.Add("@LFacility_No", typeof(string));
            dtCust.Columns.Add("@LseqNo", typeof(int));
            dtCust.Columns.Add("@LProd_Mod", typeof(string));
            dtCust.Columns.Add("@LProd_Ref", typeof(string));
            dtCust.Columns.Add("@LCCS_Ccy", typeof(string));
            dtCust.Columns.Add("@LCCS_DocStat", typeof(string));
            dtCust.Columns.Add("@LCCS_Stat", typeof(string));
            dtCust.Columns.Add("@LCCS_No", typeof(string));
            dtCust.Columns.Add("@LCCS_LmType", typeof(string));
            if (pCLogLimitReq.pcloglmccs != null)
            {
                for (int i = 0; i < pCLogLimitReq.pcloglmccs.Length; i++)
                {
                    dtCust.Rows.Add(
                          pCLogLimitReq.pcloglmccs[i].LRecType
                        , pCLogLimitReq.pcloglmccs[i].LLogSeq
                        , pCLogLimitReq.pcloglmccs[i].LCust_Code
                        , pCLogLimitReq.pcloglmccs[i].LFacility_No
                        , pCLogLimitReq.pcloglmccs[i].LseqNo
                        , pCLogLimitReq.pcloglmccs[i].LProd_Mod
                        , pCLogLimitReq.pcloglmccs[i].LProd_Ref
                        , pCLogLimitReq.pcloglmccs[i].LCCS_Ccy
                        , pCLogLimitReq.pcloglmccs[i].LCCS_DocStat
                        , pCLogLimitReq.pcloglmccs[i].LCCS_Stat
                        , pCLogLimitReq.pcloglmccs[i].LCCS_No
                        , pCLogLimitReq.pcloglmccs[i].LCCS_LmType
                        );
                }
            }
            param.Add("@CLogCCS", dtCust.AsTableValuedParameter("Type_pCLogLmCCS"));

            //-----CFR_RateLog
            dtCust = new DataTable();
            dtCust.Columns.Add("LCustCode", typeof(string));
            dtCust.Columns.Add("LCurCode", typeof(string));
            dtCust.Columns.Add("Lprdcode", typeof(string));
            dtCust.Columns.Add("Lrate_type", typeof(string));
            dtCust.Columns.Add("Lsign", typeof(string));
            dtCust.Columns.Add("Lspread", typeof(double));
            dtCust.Columns.Add("LFacility_No", typeof(string));
            dtCust.Columns.Add("Lremark", typeof(string));
            dtCust.Columns.Add("LApproveDate", typeof(DateTime));
            dtCust.Columns.Add("LInputDate", typeof(DateTime));
            dtCust.Columns.Add("LExpiryDate", typeof(DateTime));
            dtCust.Columns.Add("LDelete_Flag", typeof(string));
            dtCust.Columns.Add("LZZUser", typeof(string));
            dtCust.Columns.Add("LZZStrdate", typeof(DateTime));
            dtCust.Columns.Add("LZZDate", typeof(DateTime));
            if (pCLogLimitReq.cfrratelog != null)
            {
                for (int i = 0; i < pCLogLimitReq.cfrratelog.Length; i++)
                {
                    dtCust.Rows.Add(
                            pCLogLimitReq.cfrratelog[i].LCustCode
                          , pCLogLimitReq.cfrratelog[i].LCurCode
                          , pCLogLimitReq.cfrratelog[i].Lprdcode
                          , pCLogLimitReq.cfrratelog[i].Lrate_type
                          , pCLogLimitReq.cfrratelog[i].Lsign
                          , pCLogLimitReq.cfrratelog[i].Lspread
                          , pCLogLimitReq.cfrratelog[i].LFacility_No
                          , pCLogLimitReq.cfrratelog[i].Lremark
                          , pCLogLimitReq.cfrratelog[i].LApproveDate
                          , pCLogLimitReq.cfrratelog[i].LInputDate
                          , pCLogLimitReq.cfrratelog[i].LExpiryDate
                          , pCLogLimitReq.cfrratelog[i].LDelete_Flag
                          , pCLogLimitReq.cfrratelog[i].LZZUser
                          , pCLogLimitReq.cfrratelog[i].LZZStrdate
                          , pCLogLimitReq.cfrratelog[i].LZZDate
                        );
                }
            }
            param.Add("@CFR_RateLog", dtCust.AsTableValuedParameter("Type_CFR_RateLog"));

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            param.Add("@PCLogLimitRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            try
            {
                var results = await _db.LoadData<PCLogLimitRsp, dynamic>(
                    storedProcedure: "usp_pCustLimit_Edit_Save",
                    param);

                var PCLogLimitRsp = param.Get<dynamic>("@PCLogLimitRsp");

                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(PCLogLimitRsp);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Save Customer Credit Limit Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("release")]
        public async Task<ActionResult<string>> Release([FromBody] PCustLimitReleaseReq pCustLimitReleaseReq)
        {
            DynamicParameters param = new();
            param.Add("@Cust_Code", pCustLimitReleaseReq.Cust_Code);
            param.Add("@Facility_No", pCustLimitReleaseReq.Facility_No);
            param.Add("@AuthCode", pCustLimitReleaseReq.UserCode);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pCustLimit_Edit_Release", param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Release Customer Credit Limit Complete";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    //response.Message = "Export BC No Not Exist";
                    response.Message = resp.ToString();
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetCombineLineAmt")]
        public async Task<IEnumerable<SumAmountCustRsp>> SumAmtCust(string? CustCode, string? SumType)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);
            param.Add("@SumType", SumType);

            var results = await _db.LoadData<SumAmountCustRsp, dynamic>(
                        storedProcedure: "usp_GetSumAmtCust",
                        param);
            return results;
        }

        [HttpGet("GetLiabilityAmt")]
        public async Task<IEnumerable<LiabilityAmtCustRsp>> GetLiabilityAmt(string? CustCode, string? facility_no)
        {
            DynamicParameters param = new();

            param.Add("@Cust_Code", CustCode);
            param.Add("@facility_no", facility_no);

            var results = await _db.LoadData<LiabilityAmtCustRsp, dynamic>(
                        storedProcedure: "usp_GetLiabilityAmt",
                        param);
            return results;
        }




    }
}
