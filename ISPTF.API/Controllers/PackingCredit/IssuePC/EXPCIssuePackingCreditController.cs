using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExportLC;
using ISPTF.Models.PackingCredit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ISPTF.Models.LoginRegis;
using System.Transactions;
using System.Reflection;

namespace ISPTF.API.Controllers.PackingCredit
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXPCIssuePackingCreditController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        private const string BUSINESS_TYPE = "1";
        private const string EVENT_TYPE = "ISSUE";

        public EXPCIssuePackingCreditController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("newlist")]
        public async Task<ActionResult<IssuePCNewListPageResponse>> NewList(string? CenterID, string? RegDocNo,string? CustCode , string? @CustName, string? Page, string? PageSize)
        {
            IssuePCNewListPageResponse response = new IssuePCNewListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_IssuePCNewListPageRsp>();
                return BadRequest(response);
            }
            //if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "USER_ID is required";
            //    response.Data = new List<Q_IssuePCNewListPageRsp>();
            //    return BadRequest(response);
            //}

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                //param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@RegDocNo", RegDocNo);
                param.Add("@CustName", @CustName);
                param.Add("@CustCode", @CustCode);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (RegDocNo == null)
                {
                    param.Add("@RegDocNo", "");
                }
                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }

                var results = await _db.LoadData<Q_IssuePCNewListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_IssuePackingNewListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IssuePCNewListPageRsp>)results;

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
                response.Data = new List<Q_IssuePCNewListPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("list")]
        public async Task<ActionResult<IssuePCListPageResponse>> List(string? ListType,string? CenterID, string? @PackingNo, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            IssuePCListPageResponse response = new IssuePCListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_IssuePCListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_IssuePCListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@PackingNo", PackingNo);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (PackingNo == null)
                {
                    param.Add("@PackingNo", "");
                }
                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }

                var results = await _db.LoadData<Q_IssuePCListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXPC_IssuePackingListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IssuePCListPageRsp>)results;

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
                response.Data = new List<Q_IssuePCListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("newselect")]
        public async Task<ActionResult<PEXPCPPaymentResponse>> GetNewSelect(string? RegDocNo)
        {
            PEXPCPPaymentResponse response = new();
            // Validate
            if (string.IsNullOrEmpty(RegDocNo))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new();
                return BadRequest(response);
            }

            try
            {
                var pDocReg = (from row in _context.pDocRegisters
                               where row.Reg_Docno == RegDocNo
                               select row).AsNoTracking().FirstOrDefault();
                pExpc pExpc = new();
                pExpc.PACKING_NO = pDocReg.Reg_Docno;
                pExpc.cust_id = pDocReg.Reg_CustCode;
                var mCustomer = (from row in _context.mCustomers
                                 where row.Cust_Code == pDocReg.Reg_CustCode
                                 select row).AsNoTracking().FirstOrDefault();
                if (mCustomer!=null)
                {
                    string cus_info = "";
                    if (mCustomer.Cust_Add1_Line1 != null)
                        cus_info = mCustomer.Cust_Add1_Line1;
                    if (mCustomer.Cust_Add1_Line2 != null)
                        cus_info = cus_info + System.Environment.NewLine + mCustomer.Cust_Add1_Line2;
                    if (mCustomer.Cust_Add1_Line3 != null)
                        cus_info = cus_info + System.Environment.NewLine + mCustomer.Cust_Add1_Line3;
                    if (mCustomer.Cust_Add1_Line4 != null)
                        cus_info = cus_info + System.Environment.NewLine + mCustomer.Cust_Add1_Line4;
                    pExpc.cust_info = cus_info;
                }
                pExpc.refer_lcno = pDocReg.Reg_RefNo;
                pExpc.packing_for = pDocReg.Reg_DocType;
                pExpc.doc_amount = pDocReg.Reg_CcyAmt;
                pExpc.pack_ccy = pDocReg.Reg_CcyBal;
                pExpc.rate = pDocReg.Reg_Plus;
                pExpc.exch_rate = pDocReg.Reg_ExchRate;
                pExpc.pack_thb = pDocReg.Reg_BhtAmt;
                pExpc.pn_no = pDocReg.Reg_RefNo2;
                pExpc.total_credit_ac = pDocReg.Reg_BhtAmt;

                response.Code = Constants.RESPONSE_OK;
                response.Data = new();
                response.Data.PEXPC = pExpc;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new();
            }
            return BadRequest(response);
        }












    }
}
