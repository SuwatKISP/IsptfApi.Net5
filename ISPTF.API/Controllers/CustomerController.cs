using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ISPTF.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public CustomerController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("checkdupcustregist")]
        public async Task<ActionResult<string>> GetChkDupCustRegist(string custcode, string custregistid)
        {
            DynamicParameters param = new();
            param.Add("@Cust_Code", custcode);
            param.Add("@Cust_RegistId", custregistid);

            param.Add("@CRsp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);
            //param.Add("@CCustRsp", dbType: DbType.String,
            //       direction: System.Data.ParameterDirection.Output,
            //       size: 5215585);

            try
            {
                var results = await _db.LoadData<MCustomerRsp, dynamic>(
                        storedProcedure: "usp_mcustomercheckregistid",
                        param);
                var crsp = param.Get<dynamic>("@CRsp");
                //var ccustrsp = param.Get<dynamic>("@CCustRsp");
                switch (crsp)
                {
                    //case 0:
                    //    return Ok("Customer Code / Customer RegistID not duplicated");
                    case 1:
                        ReturnResponse response = new();
                        response.StatusCode = "1";
                        response.Message = "Customer code - " + custcode + " / Regist ID - " + custregistid + " is duplicated";
                        return BadRequest(response);
                    case 0:
                        ReturnResponse response2 = new();
                        response2.StatusCode = "0";
                        response2.Message = "Customer code - " + custcode + " / Regist ID " + custregistid + " is not duplicated";
                        return BadRequest(response2);
                    //case 3:
                    //    ReturnResponse response3 = new();
                    //    response3.StatusCode = "3";
                    //    response3.Message = "Customer code - " + custcode + " is not duplication and Regist ID - " + custregistid + "is duplicated";
                    //    return BadRequest(response3);
                    //case 4:
                    //    ReturnResponse response4 = new();
                    //    response4.StatusCode = "4";
                    //    response4.Message = "Customer code - " + custcode + " or Regist ID - " + custregistid + " is duplicated";
                    //    return BadRequest(response4);
                    default:
                        ReturnResponse response5 = new();
                        response5.StatusCode = "0";
                        response5.Message = "Customer code - " + custcode + "  and Regist ID - " + custregistid + " is duplicated";
                        return BadRequest(response5);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getcustomer")]
        public async Task<ActionResult<MCustomerNewRsp>> Get(string? custcode, string? custname)
        {
            DynamicParameters param = new();
            if (custcode == "*" || custcode == null)
            {
                param.Add("@Cust_Code", "*");
            }
            else
            {
                param.Add("@Cust_Code", custcode);
            }
            if (custname == "*" || custname == null)
            {
                param.Add("@Cust_Name", "*");
            }
            else
            {
                param.Add("@Cust_Name", custname);
            }
            param.Add("@CRsp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);
            //param.Add("@CCustRsp", dbType: DbType.String,
            //       direction: System.Data.ParameterDirection.Output,
            //       size: 5215585);
            try
            {
                _db.StartTransaction();
                var results = await _db.LoadDataInTransaction<MCustomerRsp, dynamic>(
                    storedProcedure: "usp_mcustomeronly",
                    param);
                var crsp = param.Get<dynamic>("@CRsp");
                if (crsp > 0)
                {
                    _db.CommitTransaction();
                    return Ok(results);
                }
                else
                {
                    _db.RollbackTransaction();
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Customer code or Customer name not exist";
                    return BadRequest(response);
                }
                //var results = await _db.LoadData<MCustomerRsp, dynamic>(
                //        storedProcedure: "usp_mcustomeronly",
                //        param);
                //var crsp = param.Get<dynamic>("@CRsp");
                ////var ccustrsp = param.Get<dynamic>("@CCustRsp");
                //if (crsp > 0)
                //{
                //    //Response.ContentType = "application/json";
                //    //return Ok(ccustrsp);
                //    return Ok(results);
                //}
                //else
                //{

                //    ReturnResponse response = new();
                //    response.StatusCode = "400";
                //    response.Message = "Customer code or Customer name not exist";
                //    return BadRequest(response);
                //}
            }
            catch (Exception ex)
            {
                _db.RollbackTransaction();
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("customeractive")]
        public async Task<ActionResult<MCustomerActive>> GetCustomeActive(string? custcode, string? custname, string Page, string PageSize)
        {
            DynamicParameters param = new();
            if (custcode == "*" || custcode == null)
            {
                param.Add("@Cust_Code", "");
            }
            else
            {
                param.Add("@Cust_Code", custcode);
            }
            if (custname == "*" || custname == null)
            {
                param.Add("@Cust_Name", "");
            }
            else
            {
                param.Add("@Cust_Name", custname);
            }
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);
            param.Add("@CRsp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 12800);
            try
            {
                var results = await _db.LoadData<MCustomerActive, dynamic>(
                        storedProcedure: "usp_mcustomeractive",
                        param);
                var crsp = param.Get<dynamic>("@CRsp");
                //var ccustrsp = param.Get<dynamic>("@CCustRsp");
                if (crsp > 0)
                {
                    //string data = Regex.Replace(results.ToString(), @"\\r\\n", " ");
                    //string finaldata=Regex.Replace(data,@"\\""","");
                    //return Ok(finaldata);
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Customer not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("customerparent")]
        public async Task<IEnumerable<MCustomerParent>> GetCustomerParent(string? custcode, string? pcustcode,string? pcustname, string Page, string PageSize)
        {
            DynamicParameters param = new();
            if (custcode == "*" || custcode == null)
            {
                param.Add("@Cust_Code", "");
            }
            else
            {
                param.Add("@Cust_Code", custcode);
            }
            if (pcustcode == "*" || pcustcode == null)
            {
                param.Add("@pCust_Code", "");
            }
            else
            {
                param.Add("@pCust_Code", pcustcode);
            }
            if (pcustname == "*" || pcustname == null)
            {
                param.Add("@pCust_Name", "");
            }
            else
            {
                param.Add("@pCust_Name", pcustname);
            }
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);
            var results = await _db.LoadData<MCustomerParent, dynamic>(
                        storedProcedure: "usp_mcustomerparent",
                        param);
            return results;
        }

        [HttpGet("customerchild")]
        public async Task<IEnumerable<MCustomerChild>> GetCustomerChild(string? pcustcode, string? scustcode, string? scustname, string Page, string PageSize)
        {
            DynamicParameters param = new();
            if (pcustcode == "*" || pcustcode == null)
            {
                param.Add("@pCust_Code", "");
            }
            else
            {
                param.Add("@pCust_Code", pcustcode);
            }

            if (scustcode == "*" || scustcode == null)
            {
                param.Add("@sCust_Code", "");
            }
            else
            {
                param.Add("@sCust_Code", scustcode);
            }

            if (scustname == "*" || scustname == null)
            {
                param.Add("@sCust_Name", "");
            }
            else
            {
                param.Add("@sCust_Name", scustname);
            }
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);
            var results = await _db.LoadData<MCustomerChild, dynamic>(
                        storedProcedure: "usp_mcustomerchild",
                        param);
            return results;
        }
        //[HttpGet("customerparent")]
        //public async Task<ActionResult<MCustomerActive>> GetCustomerParent(string? custcode)
        //{
        //    DynamicParameters param = new();
        //    if (custcode == "*" || custcode == null)
        //    {
        //        param.Add("@Cust_Code", "*");
        //    }
        //    else
        //    {
        //        param.Add("@Cust_Code", custcode);
        //    }

        //    param.Add("@CRsp", dbType: DbType.Int32,
        //           direction: System.Data.ParameterDirection.Output,
        //           size: 12800);
        //    //param.Add("@CCustRsp", dbType: DbType.String,
        //    //       direction: System.Data.ParameterDirection.Output,
        //    //       size: 5215585);

        //    try
        //    {
        //        var results = await _db.LoadData<MCustomerActive, dynamic>(
        //                storedProcedure: "usp_mcustomerparent",
        //                param);
        //        var crsp = param.Get<dynamic>("@CRsp");
        //        //var ccustrsp = param.Get<dynamic>("@CCustRsp");
        //        if (crsp > 0)
        //        {
        //            //Response.ContentType = "application/json";
        //            //results.ToString().Replace("\r", " ");
        //            return Ok(results.ToString().Replace("\r", " "));
        //        }
        //        else
        //        {

        //            ReturnResponse response = new();
        //            response.StatusCode = "400";
        //            response.Message = "Customer code not exist";
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpGet]
        public async Task<ActionResult<MCustomerNewRsp>> GetAll(string? custcode, string? custname)
        {
            DynamicParameters param = new();
            if (custcode == "*" || custcode == null)
            {
                param.Add("@Cust_Code", "*");
            }
            else
            {
                param.Add("@Cust_Code", custcode);
            }
            if (custname == "*" || custname == null)
            {
                param.Add("@Cust_Name", "*");
            }
            else
            {
                param.Add("@Cust_Name", custname);
            }
            param.Add("@CRsp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);
            param.Add("@CCustRsp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            try
            {
                var results = await _db.LoadData<MCustomerNewRsp, dynamic>(
                        storedProcedure: "usp_mcustomerselect",
                        param);
                var crsp = param.Get<dynamic>("@CRsp");
                var ccustrsp = param.Get<dynamic>("@CCustRsp");
                if (crsp > 0)
                {
                    //Response.ContentType = "application/json";
                    return Content(ccustrsp, "application/json");
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Customer code or Customer name not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("new")]
        //public async Task<ActionResult<string>> New([FromBody] MCustomerCustRate customer)
        public async Task<ActionResult<List<MCustomerNewRsp>>> New([FromBody] MCustomerNewReq customerreq)
        {
            Log.Information("CustomerNew Request : {@customerreq}", customerreq);
            if (customerreq.customer.Cust_Code == "NEW" )
            {
                var dt = new DataTable();

                dt.Columns.Add("Def_Cust", typeof(string));
                dt.Columns.Add("Def_Mod", typeof(string));
                dt.Columns.Add("Def_Exp", typeof(string));
                dt.Columns.Add("Def_Type", typeof(string));
                dt.Columns.Add("Def_Rate", typeof(double));
                dt.Columns.Add("Def_Base", typeof(int));
                dt.Columns.Add("Def_Min", typeof(double));
                dt.Columns.Add("Def_Max", typeof(double));
                //dt.Columns.Add("CreateDate", typeof(DateTime)).DefaultValue = DateTime.Now;
                //dt.Columns.Add("UpdateDate", typeof(DateTime)).DefaultValue = DateTime.Now; ;
                dt.Columns.Add("UserCode", typeof(string));
                dt.Columns.Add("RecStatus", typeof(string));
                dt.Columns.Add("AuthDate", typeof(DateTime)).DefaultValue = DateTime.Now;
                dt.Columns.Add("AuthCode", typeof(string));

                //dt.Rows.Add("NEW", "1", "1", " ", 0, 0, 1, 5,DateTime.Today, DateTime.Now, " ", " ", DateTime.Now, " ");
                //dt.Rows.Add("NEW", "2", "2", " ", 0, 0, 1, 5, DateTime.Now, DateTime.Now, " ", " ", DateTime.Now, " ");
                //dt.Rows.Add("NEW", "3", "2", " ", 0, 0, 1, 5, DateTime.Now, DateTime.Now, " ", " ", DateTime.Now, " ");
                //dt.Rows.Add("NEW", "4", "2", " ", 0, 0, 1, 5, DateTime.Now, DateTime.Now, " ", " ", DateTime.Now, " ");

                System.Diagnostics.Debug.Write(dt);

                for (int i = 0; i < customerreq.custRate.Length; i++)
                {
                    dt.Rows.Add(
                        customerreq.custRate[i].Def_Cust
                        , customerreq.custRate[i].Def_Mod
                        , customerreq.custRate[i].Def_Exp
                        , customerreq.custRate[i].Def_Type
                        , customerreq.custRate[i].Def_Rate
                        , customerreq.custRate[i].Def_Base
                        , customerreq.custRate[i].Def_Min
                        , customerreq.custRate[i].Def_Max
                        //, DateTime.Now
                        //, DateTime.Now
                        , customerreq.custRate[i].UserCode
                        , customerreq.custRate[i].RecStatus
                        , DateTime.Now
                        , customerreq.custRate[i].AuthCode
                        );
                }
                DynamicParameters param = new();

                //param.Add("@Cust_Code", customerreq.customer.Cust_Code);
                param.Add("@Cust_Code", "NEW");
                param.Add("@RecStatus", customerreq.customer.RecStatus);
                param.Add("@Cust_Status", customerreq.customer.Cust_Status);
                param.Add("@Cust_CCID", customerreq.customer.Cust_CCID);
                param.Add("@Cust_CIF", customerreq.customer.Cust_CIF);
                param.Add("@Cust_T24", customerreq.customer.Cust_T24);
                param.Add("@CNUM", customerreq.customer.CNUM);
                param.Add("@CCS_REF", customerreq.customer.CCS_REF);
                param.Add("@Cust_Title", customerreq.customer.Cust_Title);
                param.Add("@Cust_Name", customerreq.customer.Cust_Name);
                param.Add("@Cust_LastName", customerreq.customer.Cust_LastName);
                param.Add("@Cust_TTitle", customerreq.customer.Cust_TTitle);
                param.Add("@Cust_TName", customerreq.customer.Cust_TName);
                param.Add("@Cust_TLastName", customerreq.customer.Cust_TLastName);
                param.Add("@Cust_Type", customerreq.customer.Cust_Type);
                param.Add("@Cust_Nation", customerreq.customer.Cust_Nation);
                param.Add("@Cust_Group", customerreq.customer.Cust_Group);
                param.Add("@Cust_Parent", customerreq.customer.Cust_Parent);
                param.Add("@Cust_Bran", customerreq.customer.Cust_Bran);
                param.Add("@Cust_Rating", customerreq.customer.Cust_Rating);
                param.Add("@Cust_Lo", customerreq.customer.Cust_Lo);
                param.Add("@Cust_Ao", customerreq.customer.Cust_Ao);
                param.Add("@Cust_BOI", customerreq.customer.Cust_BOI);
                param.Add("@Cust_CsType", customerreq.customer.Cust_CsType);
                param.Add("@Cust_BuType", customerreq.customer.Cust_BuType);
                param.Add("@Cust_Size", customerreq.customer.Cust_Size);
                param.Add("@IRateTHB", customerreq.customer.IRateTHB);
                param.Add("@IRateCcy", customerreq.customer.IRateCcy);
                param.Add("@IRateFlag", customerreq.customer.IRateFlag);
                //param.Add("@Cust_EntDate", DateTime.Now);
                param.Add("@Cust_EntDate", customerreq.customer.Cust_EntDate);
                param.Add("@Cust_RegistID", customerreq.customer.Cust_RegistID);
                //param.Add("@Cust_RegistDate", DateTime.Now);
                param.Add("@Cust_RegistDate", customerreq.customer.Cust_RegistDate);
                param.Add("@Cust_TaxID", customerreq.customer.Cust_TaxID);
                param.Add("@Cust_Contact", customerreq.customer.Cust_Contact);
                param.Add("@Cust_Remark", customerreq.customer.Cust_Remark);
                param.Add("@Cust_Add1_Line1", customerreq.customer.Cust_Add1_Line1);
                param.Add("@Cust_Add1_Line2", customerreq.customer.Cust_Add1_Line2);
                param.Add("@Cust_Add1_Line3", customerreq.customer.Cust_Add1_Line3);
                param.Add("@Cust_Add1_Line4", customerreq.customer.Cust_Add1_Line4);
                param.Add("@Cust_Add1_Prov", customerreq.customer.Cust_Add1_Prov);
                param.Add("@Cust_Add1_Cnty", customerreq.customer.Cust_Add1_Cnty);
                param.Add("@Cust_Add1_Telno", customerreq.customer.Cust_Add1_Telno);
                param.Add("@Cust_Add1_Faxno", customerreq.customer.Cust_Add1_Faxno);
                param.Add("@Cust_Add1_Email", customerreq.customer.Cust_Add1_Email);
                param.Add("@Cust_Add2_Line1", customerreq.customer.Cust_Add2_Line1);
                param.Add("@Cust_Add2_Line2", customerreq.customer.Cust_Add2_Line2);
                param.Add("@Cust_Add2_Line3", customerreq.customer.Cust_Add2_Line3);
                param.Add("@Cust_Add2_Line4", customerreq.customer.Cust_Add2_Line4);
                param.Add("@Cust_Add2_prov", customerreq.customer.Cust_Add2_prov);
                param.Add("@Cust_Add2_Cnty", customerreq.customer.Cust_Add2_Cnty);
                param.Add("@Cust_Add2_Telno", customerreq.customer.Cust_Add2_Telno);
                param.Add("@Cust_Add2_Faxno", customerreq.customer.Cust_Add2_Faxno);
                param.Add("@Cust_AcNo1", customerreq.customer.Cust_AcNo1);
                param.Add("@Cust_AcName1", customerreq.customer.Cust_AcName1);
                param.Add("@Cust_AcType1", customerreq.customer.Cust_AcType1);
                param.Add("@Cust_AcFlag1", customerreq.customer.Cust_AcFlag1);
                param.Add("@Cust_AcCcy1", customerreq.customer.Cust_AcCcy1);
                param.Add("@Cust_AcBran1", customerreq.customer.Cust_AcBran1);
                param.Add("@cust_AcRelation1", customerreq.customer.cust_AcRelation1);
                param.Add("@Cust_AcNo2", customerreq.customer.Cust_AcNo2);
                param.Add("@Cust_AcName2", customerreq.customer.Cust_AcName2);
                param.Add("@Cust_AcType2", customerreq.customer.Cust_AcType2);
                param.Add("@Cust_AcFlag2", customerreq.customer.Cust_AcFlag2);
                param.Add("@Cust_AcCcy2", customerreq.customer.Cust_AcCcy2);
                param.Add("@Cust_AcBran2", customerreq.customer.Cust_AcBran2);
                param.Add("@cust_Acrelation2", customerreq.customer.cust_AcRelation2);
                param.Add("@Cust_AcNo3", customerreq.customer.Cust_AcNo3);
                param.Add("@Cust_AcName3", customerreq.customer.Cust_AcName3);
                param.Add("@Cust_AcType3", customerreq.customer.Cust_AcType3);
                param.Add("@Cust_AcFlag3", customerreq.customer.Cust_AcFlag3);
                param.Add("@Cust_AcCcy3", customerreq.customer.Cust_AcCcy3);
                param.Add("@Cust_AcBran3", customerreq.customer.Cust_AcBran3);
                param.Add("@cust_AcRelation3", customerreq.customer.cust_AcRelation3);
                param.Add("@Cust_AcNo4", customerreq.customer.Cust_AcNo4);
                param.Add("@Cust_AcName4", customerreq.customer.Cust_AcName4);
                param.Add("@Cust_AcType4", customerreq.customer.Cust_AcType4);
                param.Add("@Cust_AcFlag4", customerreq.customer.Cust_AcFlag4);
                param.Add("@Cust_AcCcy4", customerreq.customer.Cust_AcCcy4);
                param.Add("@Cust_AcBran4", customerreq.customer.Cust_AcBran4);
                param.Add("@cust_AcRelation4", customerreq.customer.cust_AcRelation4);
                param.Add("@Cust_CommLC", customerreq.customer.Cust_CommLC);

                //param.Add("@CreateDate", DateTime.Now);
                //param.Add("@UpdateDate", DateTime.Now);
                param.Add("@UserCode", customerreq.customer.UserCode);
                param.Add("@AuthDate", customerreq.customer.AuthDate);
                param.Add("@AuthCode", customerreq.customer.AuthCode);
                param.Add("@DMS", customerreq.customer.DMS);
                param.Add("@Cust_CCEmail", customerreq.customer.Cust_CCEmail);
                param.Add("@Online_Flag", customerreq.customer.Online_Flag);
                param.Add("@CLMS_Flag", customerreq.customer.CLMS_Flag);
                param.Add("@Cust_FilePassword", customerreq.customer.Cust_FilePassword);
                param.Add("@Cust_SBU", customerreq.customer.Cust_SBU);
                param.Add("@Cust_GFMSSBUCode", customerreq.customer.Cust_GFMSSBUCode);
                param.Add("@Cust_RCCode", customerreq.customer.Cust_RCCode);
                param.Add("@Cust_RMCode", customerreq.customer.Cust_RMCode);
                param.Add("@CustRate", dt.AsTableValuedParameter("type_custrate"));

                param.Add("@CRsp", dbType: DbType.Int32,
                    direction: System.Data.ParameterDirection.Output,
                    size: 12800);

                param.Add("@CCustRsp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);

                try
                {
                    var results = await _db.LoadData<MCustomerNewReq, dynamic>(
                        storedProcedure: "usp_mcustomernew",
                        param);
                    var crsp = param.Get<dynamic>("@CRsp");
                    var ccustrsp = param.Get<dynamic>("@CCustRsp");
                    //Log.Information("CustomerNew Request : {@customerreq}",customerreq);
                    if (crsp > 0)
                    {
                        Log.Information("CustomerNew Response : {@ccustrsp}", ccustrsp);
                        return Content(ccustrsp, "application/json");
                    }
                    else
                    {

                        ReturnResponse response = new();
                        response.StatusCode = "400";
                        response.Message = "New Customer code not generate";
                        Log.Information("CustomerNew Response BadRequest : {@response}", response);
                        return BadRequest(response);
                    }
                }
                catch (Exception ex)
                {
                    Log.Information("CustomerNew Response BadRequest : {@exception}", ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Not NEW Customer Code or NEW Def Cust");
            }
        }
        [HttpPost("new2")]
        //public async Task<ActionResult<string>> New([FromBody] MCustomerCustRate customer)
        public async Task<ActionResult<List<MCustomerNewRsp>>> New2([FromBody] MCustomerNewReq customerreq)
        {
            Log.Information("CustomerNew Request : {@customerreq}", customerreq);
            if (customerreq.customer.Cust_Code == "NEW" 
                && (customerreq.custRate[0].Def_Cust == "NEW" || customerreq.custRate[0].Def_Cust == "NONE"))
            {
                var dt = new DataTable();

                dt.Columns.Add("Def_Cust", typeof(string));
                dt.Columns.Add("Def_Mod", typeof(string));
                dt.Columns.Add("Def_Exp", typeof(string));
                dt.Columns.Add("Def_Type", typeof(string));
                dt.Columns.Add("Def_Rate", typeof(double));
                dt.Columns.Add("Def_Base", typeof(int));
                dt.Columns.Add("Def_Min", typeof(double));
                dt.Columns.Add("Def_Max", typeof(double));
                //dt.Columns.Add("CreateDate", typeof(DateTime)).DefaultValue = DateTime.Now;
                //dt.Columns.Add("UpdateDate", typeof(DateTime)).DefaultValue = DateTime.Now; ;
                dt.Columns.Add("UserCode", typeof(string));
                dt.Columns.Add("RecStatus", typeof(string));
                dt.Columns.Add("AuthDate", typeof(DateTime)).DefaultValue = DateTime.Now;
                dt.Columns.Add("AuthCode", typeof(string));

                System.Diagnostics.Debug.Write(dt);

                for (int i = 0; i < customerreq.custRate.Length; i++)
                {
                    dt.Rows.Add(
                        "NEW"
                        , customerreq.custRate[i].Def_Mod
                        , customerreq.custRate[i].Def_Exp
                        , customerreq.custRate[i].Def_Type
                        , customerreq.custRate[i].Def_Rate
                        , customerreq.custRate[i].Def_Base
                        , customerreq.custRate[i].Def_Min
                        , customerreq.custRate[i].Def_Max
                        //, DateTime.Now
                        //, DateTime.Now
                        , customerreq.custRate[i].UserCode
                        , customerreq.custRate[i].RecStatus
                        , customerreq.custRate[i].AuthDate
                        , customerreq.custRate[i].AuthCode
                        );
                }
                DynamicParameters param = new();

                //param.Add("@Cust_Code", customerreq.customer.Cust_Code);
                param.Add("@Cust_Code", "NEW");
                param.Add("@RecStatus", customerreq.customer.RecStatus);
                param.Add("@Cust_Status", customerreq.customer.Cust_Status);
                param.Add("@Cust_CCID", customerreq.customer.Cust_CCID);
                param.Add("@Cust_CIF", customerreq.customer.Cust_CIF);
                param.Add("@Cust_T24", customerreq.customer.Cust_T24);
                param.Add("@CNUM", customerreq.customer.CNUM);
                param.Add("@CCS_REF", customerreq.customer.CCS_REF);
                param.Add("@Cust_Title", customerreq.customer.Cust_Title);
                param.Add("@Cust_Name", customerreq.customer.Cust_Name);
                param.Add("@Cust_LastName", customerreq.customer.Cust_LastName);
                param.Add("@Cust_TTitle", customerreq.customer.Cust_TTitle);
                param.Add("@Cust_TName", customerreq.customer.Cust_TName);
                param.Add("@Cust_TLastName", customerreq.customer.Cust_TLastName);
                param.Add("@Cust_Type", customerreq.customer.Cust_Type);
                param.Add("@Cust_Nation", customerreq.customer.Cust_Nation);
                param.Add("@Cust_Group", customerreq.customer.Cust_Group);
                param.Add("@Cust_Parent", customerreq.customer.Cust_Parent);
                param.Add("@Cust_Bran", customerreq.customer.Cust_Bran);
                param.Add("@Cust_Rating", customerreq.customer.Cust_Rating);
                param.Add("@Cust_Lo", customerreq.customer.Cust_Lo);
                param.Add("@Cust_Ao", customerreq.customer.Cust_Ao);
                param.Add("@Cust_BOI", customerreq.customer.Cust_BOI);
                param.Add("@Cust_CsType", customerreq.customer.Cust_CsType);
                param.Add("@Cust_BuType", customerreq.customer.Cust_BuType);
                param.Add("@Cust_Size", customerreq.customer.Cust_Size);
                param.Add("@IRateTHB", customerreq.customer.IRateTHB);
                param.Add("@IRateCcy", customerreq.customer.IRateCcy);
                param.Add("@IRateFlag", customerreq.customer.IRateFlag);
                //param.Add("@Cust_EntDate", DateTime.Now);
                param.Add("@Cust_EntDate", customerreq.customer.Cust_EntDate);
                param.Add("@Cust_RegistID", customerreq.customer.Cust_RegistID);
                //param.Add("@Cust_RegistDate", DateTime.Now);
                param.Add("@Cust_RegistDate", customerreq.customer.Cust_RegistDate);
                param.Add("@Cust_TaxID", customerreq.customer.Cust_TaxID);
                param.Add("@Cust_Contact", customerreq.customer.Cust_Contact);
                param.Add("@Cust_Remark", customerreq.customer.Cust_Remark);
                param.Add("@Cust_Add1_Line1", customerreq.customer.Cust_Add1_Line1);
                param.Add("@Cust_Add1_Line2", customerreq.customer.Cust_Add1_Line2);
                param.Add("@Cust_Add1_Line3", customerreq.customer.Cust_Add1_Line3);
                param.Add("@Cust_Add1_Line4", customerreq.customer.Cust_Add1_Line4);
                param.Add("@Cust_Add1_Prov", customerreq.customer.Cust_Add1_Prov);
                param.Add("@Cust_Add1_Cnty", customerreq.customer.Cust_Add1_Cnty);
                param.Add("@Cust_Add1_Telno", customerreq.customer.Cust_Add1_Telno);
                param.Add("@Cust_Add1_Faxno", customerreq.customer.Cust_Add1_Faxno);
                param.Add("@Cust_Add1_Email", customerreq.customer.Cust_Add1_Email);
                param.Add("@Cust_Add2_Line1", customerreq.customer.Cust_Add2_Line1);
                param.Add("@Cust_Add2_Line2", customerreq.customer.Cust_Add2_Line2);
                param.Add("@Cust_Add2_Line3", customerreq.customer.Cust_Add2_Line3);
                param.Add("@Cust_Add2_Line4", customerreq.customer.Cust_Add2_Line4);
                param.Add("@Cust_Add2_prov", customerreq.customer.Cust_Add2_prov);
                param.Add("@Cust_Add2_Cnty", customerreq.customer.Cust_Add2_Cnty);
                param.Add("@Cust_Add2_Telno", customerreq.customer.Cust_Add2_Telno);
                param.Add("@Cust_Add2_Faxno", customerreq.customer.Cust_Add2_Faxno);
                param.Add("@Cust_AcNo1", customerreq.customer.Cust_AcNo1);
                param.Add("@Cust_AcName1", customerreq.customer.Cust_AcName1);
                param.Add("@Cust_AcType1", customerreq.customer.Cust_AcType1);
                param.Add("@Cust_AcFlag1", customerreq.customer.Cust_AcFlag1);
                param.Add("@Cust_AcCcy1", customerreq.customer.Cust_AcCcy1);
                param.Add("@Cust_AcBran1", customerreq.customer.Cust_AcBran1);
                param.Add("@cust_AcRelation1", customerreq.customer.cust_AcRelation1);
                param.Add("@Cust_AcNo2", customerreq.customer.Cust_AcNo2);
                param.Add("@Cust_AcName2", customerreq.customer.Cust_AcName2);
                param.Add("@Cust_AcType2", customerreq.customer.Cust_AcType2);
                param.Add("@Cust_AcFlag2", customerreq.customer.Cust_AcFlag2);
                param.Add("@Cust_AcCcy2", customerreq.customer.Cust_AcCcy2);
                param.Add("@Cust_AcBran2", customerreq.customer.Cust_AcBran2);
                param.Add("@cust_Acrelation2", customerreq.customer.cust_AcRelation2);
                param.Add("@Cust_AcNo3", customerreq.customer.Cust_AcNo3);
                param.Add("@Cust_AcName3", customerreq.customer.Cust_AcName3);
                param.Add("@Cust_AcType3", customerreq.customer.Cust_AcType3);
                param.Add("@Cust_AcFlag3", customerreq.customer.Cust_AcFlag3);
                param.Add("@Cust_AcCcy3", customerreq.customer.Cust_AcCcy3);
                param.Add("@Cust_AcBran3", customerreq.customer.Cust_AcBran3);
                param.Add("@cust_AcRelation3", customerreq.customer.cust_AcRelation3);
                param.Add("@Cust_AcNo4", customerreq.customer.Cust_AcNo4);
                param.Add("@Cust_AcName4", customerreq.customer.Cust_AcName4);
                param.Add("@Cust_AcType4", customerreq.customer.Cust_AcType4);
                param.Add("@Cust_AcFlag4", customerreq.customer.Cust_AcFlag4);
                param.Add("@Cust_AcCcy4", customerreq.customer.Cust_AcCcy4);
                param.Add("@Cust_AcBran4", customerreq.customer.Cust_AcBran4);
                param.Add("@cust_AcRelation4", customerreq.customer.cust_AcRelation4);
                param.Add("@Cust_CommLC", customerreq.customer.Cust_CommLC);

                //param.Add("@CreateDate", DateTime.Now);
                //param.Add("@UpdateDate", DateTime.Now);
                param.Add("@UserCode", customerreq.customer.UserCode);
                param.Add("@AuthDate", customerreq.customer.AuthDate);
                param.Add("@AuthCode", customerreq.customer.AuthCode);
                param.Add("@DMS", customerreq.customer.DMS);
                param.Add("@Cust_CCEmail", customerreq.customer.Cust_CCEmail);
                param.Add("@Online_Flag", customerreq.customer.Online_Flag);
                param.Add("@CLMS_Flag", customerreq.customer.CLMS_Flag);
                param.Add("@Cust_FilePassword", customerreq.customer.Cust_FilePassword);
                param.Add("@Cust_SBU", customerreq.customer.Cust_SBU);
                param.Add("@Cust_GFMSSBUCode", customerreq.customer.Cust_GFMSSBUCode);
                param.Add("@Cust_RCCode", customerreq.customer.Cust_RCCode);
                param.Add("@Cust_RMCode", customerreq.customer.Cust_RMCode);
                //param.Add("@CustRate", dt.AsTableValuedParameter("type_custrate"));

                param.Add("@CRsp", dbType: DbType.Int32,
                    direction: System.Data.ParameterDirection.Output,
                    size: 12800);

                param.Add("@CCustRsp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
                _db.StartTransaction();
                try
                {
                    var results = await _db.LoadDataInTransaction<MCustomer, dynamic>(
                        storedProcedure: "usp_mcustomernew2",
                        param);
                    var crsp = param.Get<dynamic>("@CRsp");
                    var ccustrsp = param.Get<dynamic>("@CCustRsp");
                    //Log.Information("CustomerNew Request : {@customerreq}",customerreq);
                    if (crsp > 0)
                    {
                        Log.Information("CustomerNew Response : {@ccustrsp}", ccustrsp);
                        //return Ok(ccustrsp);
                        DynamicParameters param2 = new();
                        param2.Add("@Cust_Code", ccustrsp.customer.cust_code);
                        param2.Add("@CRsp", dbType: DbType.Int32,
                            direction: System.Data.ParameterDirection.Output,
                            size: 12800);

                        param.Add("@CCustRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                        try
                        {
                            var results2 = await _db.LoadDataInTransaction<MCustRate, dynamic>(
                               storedProcedure: "usp_mcustratenew2",
                               param);
                            var crsp2 = param.Get<dynamic>("@CRsp");
                            var ccustrsp2 = param.Get<dynamic>("@CCustRsp");
                            //Log.Information("CustomerNew Request : {@customerreq}",customerreq);
                            if (crsp > 0)
                            {
                                _db.CommitTransaction();
                                Log.Information("CustRate Response : {@ccustrsp}", ccustrsp2);
                                return Content(ccustrsp2, "application/json");
                            }
                            else
                            {
                                _db.RollbackTransaction();
                                ReturnResponse response = new();
                                response.StatusCode = "400";
                                response.Message = "New Custrate code not generate";
                                Log.Information("CustRate Response BadRequest : {@response}", response);
                                return BadRequest(response);
                            }
                        }
                        catch (Exception ex)
                        {
                            _db.RollbackTransaction();
                            Log.Information("CustRate Response BadRequest : {@exception}", ex.Message);
                            return BadRequest(ex.Message);
                        }
                    }
                    else
                    {
                        _db.RollbackTransaction();
                        ReturnResponse response = new();
                        response.StatusCode = "400";
                        response.Message = "New Customer code not generate";
                        Log.Information("CustomerNew Response BadRequest : {@response}", response);
                        return BadRequest(response);
                    }
                }
                catch (Exception ex)
                {
                    _db.RollbackTransaction();
                    Log.Information("CustomerNew Response BadRequest : {@exception}", ex.Message);
                    return BadRequest(ex.Message);
                };

                //_db.CommitTransaction();
            }
            else
            {
                return BadRequest("Not NEW Customer Code or NEW Def Cust");
            }
        }
        //[HttpPost("insert")]
        //public async Task<ActionResult<List<MCustomerNewRsp>>> Insert([FromBody] MCustomerNewReq customerreq)
        //{
        //    var dt = new DataTable();

        //    dt.Columns.Add("Def_Cust", typeof(string));
        //    dt.Columns.Add("Def_Mod", typeof(string));
        //    dt.Columns.Add("Def_Exp", typeof(string));
        //    dt.Columns.Add("Def_Type", typeof(string));
        //    dt.Columns.Add("Def_Rate", typeof(double));
        //    dt.Columns.Add("Def_Base", typeof(int));
        //    dt.Columns.Add("Def_Min", typeof(double));
        //    dt.Columns.Add("Def_Max", typeof(double));
        //    dt.Columns.Add("CreateDate", typeof(DateTime)).DefaultValue = DateTime.Now;
        //    dt.Columns.Add("UpdateDate", typeof(DateTime)).DefaultValue = DateTime.Now; ;
        //    dt.Columns.Add("UserCode", typeof(string));
        //    dt.Columns.Add("RecStatus", typeof(string));
        //    dt.Columns.Add("AuthDate", typeof(DateTime)).DefaultValue = DateTime.Now;
        //    dt.Columns.Add("AuthCode", typeof(string));

        //    //dt.Rows.Add("NEW", "1", "1", " ", 0, 0, 1, 5,DateTime.Today, DateTime.Now, " ", " ", DateTime.Now, " ");
        //    //dt.Rows.Add("NEW", "2", "2", " ", 0, 0, 1, 5, DateTime.Now, DateTime.Now, " ", " ", DateTime.Now, " ");
        //    //dt.Rows.Add("NEW", "3", "2", " ", 0, 0, 1, 5, DateTime.Now, DateTime.Now, " ", " ", DateTime.Now, " ");
        //    //dt.Rows.Add("NEW", "4", "2", " ", 0, 0, 1, 5, DateTime.Now, DateTime.Now, " ", " ", DateTime.Now, " ");

        //    System.Diagnostics.Debug.Write(dt);

        //    for (int i = 0; i < customerreq.custRate.Length; i++)
        //    {
        //        dt.Rows.Add(
        //            customerreq.custRate[i].Def_Cust
        //            , customerreq.custRate[i].Def_Mod
        //            , customerreq.custRate[i].Def_Exp
        //            , customerreq.custRate[i].Def_Type
        //            , customerreq.custRate[i].Def_Rate
        //            , customerreq.custRate[i].Def_Base
        //            , customerreq.custRate[i].Def_Min
        //            , customerreq.custRate[i].Def_Max
        //            , DateTime.Now
        //            , DateTime.Now
        //            , customerreq.custRate[i].UserCode
        //            , customerreq.custRate[i].RecStatus
        //            , DateTime.Now
        //            , customerreq.custRate[i].AuthCode
        //            );
        //    }
        //    DynamicParameters param = new();

        //    param.Add("@Cust_Code", customerreq.customer.Cust_Code);
        //    param.Add("@RecStatus", customerreq.customer.RecStatus);
        //    param.Add("@Cust_Status", customerreq.customer.Cust_Status);
        //    param.Add("@Cust_CCID", customerreq.customer.Cust_CCID);
        //    param.Add("@Cust_CIF", customerreq.customer.Cust_CIF);
        //    param.Add("@Cust_T24", customerreq.customer.Cust_T24);
        //    param.Add("@CNUM", customerreq.customer.CNUM);
        //    param.Add("@CCS_REF", customerreq.customer.CCS_REF);
        //    param.Add("@Cust_Title", customerreq.customer.Cust_Title);
        //    param.Add("@Cust_Name", customerreq.customer.Cust_Name);
        //    param.Add("@Cust_LastName", customerreq.customer.Cust_LastName);
        //    param.Add("@Cust_TTitle", customerreq.customer.Cust_TTitle);
        //    param.Add("@Cust_TName", customerreq.customer.Cust_TName);
        //    param.Add("@Cust_TLastName", customerreq.customer.Cust_TLastName);
        //    param.Add("@Cust_Type", customerreq.customer.Cust_Type);
        //    param.Add("@Cust_Nation", customerreq.customer.Cust_Nation);
        //    param.Add("@Cust_Group", customerreq.customer.Cust_Group);
        //    param.Add("@Cust_Parent", customerreq.customer.Cust_Parent);
        //    param.Add("@Cust_Bran", customerreq.customer.Cust_Bran);
        //    param.Add("@Cust_Rating", customerreq.customer.Cust_Rating);
        //    param.Add("@Cust_Lo", customerreq.customer.Cust_Lo);
        //    param.Add("@Cust_Ao", customerreq.customer.Cust_Ao);
        //    param.Add("@Cust_BOI", customerreq.customer.Cust_BOI);
        //    param.Add("@Cust_CsType", customerreq.customer.Cust_CsType);
        //    param.Add("@Cust_BuType", customerreq.customer.Cust_BuType);
        //    param.Add("@Cust_Size", customerreq.customer.Cust_Size);
        //    param.Add("@IRateTHB", customerreq.customer.IRateTHB);
        //    param.Add("@IRateCcy", customerreq.customer.IRateCcy);
        //    param.Add("@IRateFlag", customerreq.customer.IRateFlag);
        //    //param.Add("@Cust_EntDate", DateTime.Now);
        //    param.Add("@Cust_EntDate", customerreq.customer.Cust_EntDate);
        //    param.Add("@Cust_RegistID", customerreq.customer.Cust_RegistID);
        //    //param.Add("@Cust_RegistDate", DateTime.Now);
        //    param.Add("@Cust_RegistDate", customerreq.customer.Cust_RegistDate);
        //    param.Add("@Cust_TaxID", customerreq.customer.Cust_TaxID);
        //    param.Add("@Cust_Contact", customerreq.customer.Cust_Contact);
        //    param.Add("@Cust_Remark", customerreq.customer.Cust_Remark);
        //    param.Add("@Cust_Add1_Line1", customerreq.customer.Cust_Add1_Line1);
        //    param.Add("@Cust_Add1_Line2", customerreq.customer.Cust_Add1_Line2);
        //    param.Add("@Cust_Add1_Line3", customerreq.customer.Cust_Add1_Line3);
        //    param.Add("@Cust_Add1_Line4", customerreq.customer.Cust_Add1_Line4);
        //    param.Add("@Cust_Add1_Prov", customerreq.customer.Cust_Add1_Prov);
        //    param.Add("@Cust_Add1_Cnty", customerreq.customer.Cust_Add1_Cnty);
        //    param.Add("@Cust_Add1_Telno", customerreq.customer.Cust_Add1_Telno);
        //    param.Add("@Cust_Add1_Faxno", customerreq.customer.Cust_Add1_Faxno);
        //    param.Add("@Cust_Add1_Email", customerreq.customer.Cust_Add1_Email);
        //    param.Add("@Cust_Add2_Line1", customerreq.customer.Cust_Add2_Line1);
        //    param.Add("@Cust_Add2_Line2", customerreq.customer.Cust_Add2_Line2);
        //    param.Add("@Cust_Add2_Line3", customerreq.customer.Cust_Add2_Line3);
        //    param.Add("@Cust_Add2_Line4", customerreq.customer.Cust_Add2_Line4);
        //    param.Add("@Cust_Add2_prov", customerreq.customer.Cust_Add2_prov);
        //    param.Add("@Cust_Add2_Cnty", customerreq.customer.Cust_Add2_Cnty);
        //    param.Add("@Cust_Add2_Telno", customerreq.customer.Cust_Add2_Telno);
        //    param.Add("@Cust_Add2_Faxno", customerreq.customer.Cust_Add2_Faxno);
        //    param.Add("@Cust_AcNo1", customerreq.customer.Cust_AcNo1);
        //    param.Add("@Cust_AcName1", customerreq.customer.Cust_AcName1);
        //    param.Add("@Cust_AcType1", customerreq.customer.Cust_AcType1);
        //    param.Add("@Cust_AcFlag1", customerreq.customer.Cust_AcFlag1);
        //    param.Add("@Cust_AcCcy1", customerreq.customer.Cust_AcCcy1);
        //    param.Add("@Cust_AcBran1", customerreq.customer.Cust_AcBran1);
        //    param.Add("@cust_AcRelation1", customerreq.customer.cust_AcRelation1);
        //    param.Add("@Cust_AcNo2", customerreq.customer.Cust_AcNo2);
        //    param.Add("@Cust_AcName2", customerreq.customer.Cust_AcName2);
        //    param.Add("@Cust_AcType2", customerreq.customer.Cust_AcType2);
        //    param.Add("@Cust_AcFlag2", customerreq.customer.Cust_AcFlag2);
        //    param.Add("@Cust_AcCcy2", customerreq.customer.Cust_AcCcy2);
        //    param.Add("@Cust_AcBran2", customerreq.customer.Cust_AcBran2);
        //    param.Add("@cust_Acrelation2", customerreq.customer.cust_AcRelation2);
        //    param.Add("@Cust_AcNo3", customerreq.customer.Cust_AcNo3);
        //    param.Add("@Cust_AcName3", customerreq.customer.Cust_AcName3);
        //    param.Add("@Cust_AcType3", customerreq.customer.Cust_AcType3);
        //    param.Add("@Cust_AcFlag3", customerreq.customer.Cust_AcFlag3);
        //    param.Add("@Cust_AcCcy3", customerreq.customer.Cust_AcCcy3);
        //    param.Add("@Cust_AcBran3", customerreq.customer.Cust_AcBran3);
        //    param.Add("@cust_AcRelation3", customerreq.customer.cust_AcRelation3);
        //    param.Add("@Cust_AcNo4", customerreq.customer.Cust_AcNo4);
        //    param.Add("@Cust_AcName4", customerreq.customer.Cust_AcName4);
        //    param.Add("@Cust_AcType4", customerreq.customer.Cust_AcType4);
        //    param.Add("@Cust_AcFlag4", customerreq.customer.Cust_AcFlag4);
        //    param.Add("@Cust_AcCcy4", customerreq.customer.Cust_AcCcy4);
        //    param.Add("@Cust_AcBran4", customerreq.customer.Cust_AcBran4);
        //    param.Add("@cust_AcRelation4", customerreq.customer.cust_AcRelation4);
        //    param.Add("@Cust_CommLC", customerreq.customer.Cust_CommLC);

        //    param.Add("@CreateDate", DateTime.Now);
        //    param.Add("@UpdateDate", DateTime.Now);
        //    param.Add("@UserCode", customerreq.customer.UserCode);
        //    param.Add("@AuthDate", DateTime.Now);
        //    //param.Add("@CreateDate", customerreq.customer.CreateDate);
        //    //param.Add("@UpdateDate", customerreq.customer.UpdateDate);
        //    //param.Add("@UserCode", customer.Customer[0].UserCode);
        //    //param.Add("@AuthDate", customer.Customer[0].AuthDate);
        //    param.Add("@AuthCode", customerreq.customer.AuthCode);
        //    param.Add("@DMS", customerreq.customer.DMS);
        //    param.Add("@Cust_CCEmail", customerreq.customer.Cust_CCEmail);
        //    param.Add("@Online_Flag", customerreq.customer.Online_Flag);
        //    param.Add("@CLMS_Flag", customerreq.customer.CLMS_Flag);
        //    param.Add("@Cust_FilePassword", customerreq.customer.Cust_FilePassword);
        //    param.Add("@Cust_SBU", customerreq.customer.Cust_SBU);
        //    param.Add("@Cust_GFMSSBUCode", customerreq.customer.Cust_GFMSSBUCode);
        //    param.Add("@Cust_RCCode", customerreq.customer.Cust_RCCode);
        //    param.Add("@Cust_RMCode", customerreq.customer.Cust_RMCode);

        //    //param.Add("@CustRate", dt.AsTableValuedParameter("type_custrate"));

        //    //for (int i = 0; i < customer.CustRate.Length; i++)
        //    //{
        //    //    param.Add("@Def_Cust", customer.CustRate[i].Def_Cust);
        //    //    param.Add("@Def_Mod", customer.CustRate[i].Def_Mod);
        //    //    param.Add("@Def_Exp", customer.CustRate[i].Def_Exp);
        //    //    param.Add("@Def_Type", customer.CustRate[i].Def_Type);
        //    //    param.Add("@Def_Rate", customer.CustRate[i].Def_Rate);
        //    //    param.Add("@Def_Base", customer.CustRate[i].Def_Base);
        //    //    param.Add("@Def_Min", customer.CustRate[i].Def_Min);
        //    //    param.Add("@Def_Max", customer.CustRate[i].Def_Max);
        //    //    param.Add("@CreateDate", customer.CustRate[i].CreateDate);
        //    //    param.Add("@UpdateDate", customer.CustRate[i].CreateDate);
        //    //    param.Add("@UserCode", customer.CustRate[i].UserCode);
        //    //    param.Add("@AuthDate", customer.CustRate[i].CreateDate);
        //    //    param.Add("@AuthCode", customer.CustRate[i].AuthCode);
        //    //    param.Add("@RecStatus", customer.CustRate[i].RecStatus);
        //    //}
        //    param.Add("@CustCode", dbType: DbType.Int32,
        //        direction: System.Data.ParameterDirection.Output,
        //        size: 5215585);
        //    try
        //    {
        //        var results = await _db.LoadData<MCustomer, dynamic>(
        //            storedProcedure: "usp_mcustomerinsert2",
        //            param);
        //        var resp = param.Get<int>("@CCode");
        //        if (resp == 1)
        //        {
        //            return Ok(results);
        //        }
        //        else
        //        {

        //            ReturnResponse response = new();
        //            response.StatusCode = "400";
        //            response.Message = "Customer code exist";
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpPost("update")]
        public async Task<ActionResult<List<MCustomerNewRsp>>> Update([FromBody] MCustomerNewReq customerreq)
        {

            var dt = new DataTable();

            dt.Columns.Add("Def_Cust", typeof(string));
            dt.Columns.Add("Def_Mod", typeof(string));
            dt.Columns.Add("Def_Exp", typeof(string));
            dt.Columns.Add("Def_Type", typeof(string));
            dt.Columns.Add("Def_Rate", typeof(double));
            dt.Columns.Add("Def_Base", typeof(int));
            dt.Columns.Add("Def_Min", typeof(double));
            dt.Columns.Add("Def_Max", typeof(double));
            //dt.Columns.Add("CreateDate", typeof(DateTime)).DefaultValue = DateTime.Now;
            //dt.Columns.Add("UpdateDate", typeof(DateTime)).DefaultValue = DateTime.Now; ;
            dt.Columns.Add("UserCode", typeof(string));
            dt.Columns.Add("RecStatus", typeof(string));
            dt.Columns.Add("AuthDate", typeof(DateTime)).DefaultValue = DateTime.Now;
            dt.Columns.Add("AuthCode", typeof(string));

            //dt.Rows.Add("NEW", "1", "1", " ", 0, 0, 1, 5,DateTime.Today, DateTime.Now, " ", " ", DateTime.Now, " ");
            //dt.Rows.Add("NEW", "2", "2", " ", 0, 0, 1, 5, DateTime.Now, DateTime.Now, " ", " ", DateTime.Now, " ");
            //dt.Rows.Add("NEW", "3", "2", " ", 0, 0, 1, 5, DateTime.Now, DateTime.Now, " ", " ", DateTime.Now, " ");
            //dt.Rows.Add("NEW", "4", "2", " ", 0, 0, 1, 5, DateTime.Now, DateTime.Now, " ", " ", DateTime.Now, " ");

            System.Diagnostics.Debug.Write(dt);

            for (int i = 0; i < customerreq.custRate.Length; i++)
            {
                dt.Rows.Add(
                    customerreq.custRate[i].Def_Cust
                    , customerreq.custRate[i].Def_Mod
                    , customerreq.custRate[i].Def_Exp
                    , customerreq.custRate[i].Def_Type
                    , customerreq.custRate[i].Def_Rate
                    , customerreq.custRate[i].Def_Base
                    , customerreq.custRate[i].Def_Min
                    , customerreq.custRate[i].Def_Max
                    //, DateTime.Now
                    //, DateTime.Now
                    , customerreq.custRate[i].UserCode
                    , customerreq.custRate[i].RecStatus
                    , DateTime.Now
                    , customerreq.custRate[i].AuthCode
                    );
            }

            DynamicParameters param = new();

            param.Add("@Cust_Code", customerreq.customer.Cust_Code);
            param.Add("@RecStatus", customerreq.customer.RecStatus);
            param.Add("@Cust_Status", customerreq.customer.Cust_Status);
            param.Add("@Cust_CCID", customerreq.customer.Cust_CCID);
            param.Add("@Cust_CIF", customerreq.customer.Cust_CIF);
            param.Add("@Cust_T24", customerreq.customer.Cust_T24);
            param.Add("@CNUM", customerreq.customer.CNUM);
            param.Add("@CCS_REF", customerreq.customer.CCS_REF);
            param.Add("@Cust_Title", customerreq.customer.Cust_Title);
            param.Add("@Cust_Name", customerreq.customer.Cust_Name);
            param.Add("@Cust_LastName", customerreq.customer.Cust_LastName);
            param.Add("@Cust_TTitle", customerreq.customer.Cust_TTitle);
            param.Add("@Cust_TName", customerreq.customer.Cust_TName);
            param.Add("@Cust_TLastName", customerreq.customer.Cust_TLastName);
            param.Add("@Cust_Type", customerreq.customer.Cust_Type);
            param.Add("@Cust_Nation", customerreq.customer.Cust_Nation);
            param.Add("@Cust_Group", customerreq.customer.Cust_Group);
            param.Add("@Cust_Parent", customerreq.customer.Cust_Parent);
            param.Add("@Cust_Bran", customerreq.customer.Cust_Bran);
            param.Add("@Cust_Rating", customerreq.customer.Cust_Rating);
            param.Add("@Cust_Lo", customerreq.customer.Cust_Lo);
            param.Add("@Cust_Ao", customerreq.customer.Cust_Ao);
            param.Add("@Cust_BOI", customerreq.customer.Cust_BOI);
            param.Add("@Cust_CsType", customerreq.customer.Cust_CsType);
            param.Add("@Cust_BuType", customerreq.customer.Cust_BuType);
            param.Add("@Cust_Size", customerreq.customer.Cust_Size);
            param.Add("@IRateTHB", customerreq.customer.IRateTHB);
            param.Add("@IRateCcy", customerreq.customer.IRateCcy);
            param.Add("@IRateFlag", customerreq.customer.IRateFlag);
            //param.Add("@Cust_EntDate", DateTime.Now);
            param.Add("@Cust_EntDate", customerreq.customer.Cust_EntDate);
            param.Add("@Cust_RegistID", customerreq.customer.Cust_RegistID);
            //param.Add("@Cust_RegistDate", DateTime.Now);
            param.Add("@Cust_RegistDate", customerreq.customer.Cust_RegistDate);
            param.Add("@Cust_TaxID", customerreq.customer.Cust_TaxID);
            param.Add("@Cust_Contact", customerreq.customer.Cust_Contact);
            param.Add("@Cust_Remark", customerreq.customer.Cust_Remark);
            param.Add("@Cust_Add1_Line1", customerreq.customer.Cust_Add1_Line1);
            param.Add("@Cust_Add1_Line2", customerreq.customer.Cust_Add1_Line2);
            param.Add("@Cust_Add1_Line3", customerreq.customer.Cust_Add1_Line3);
            param.Add("@Cust_Add1_Line4", customerreq.customer.Cust_Add1_Line4);
            param.Add("@Cust_Add1_Prov", customerreq.customer.Cust_Add1_Prov);
            param.Add("@Cust_Add1_Cnty", customerreq.customer.Cust_Add1_Cnty);
            param.Add("@Cust_Add1_Telno", customerreq.customer.Cust_Add1_Telno);
            param.Add("@Cust_Add1_Faxno", customerreq.customer.Cust_Add1_Faxno);
            param.Add("@Cust_Add1_Email", customerreq.customer.Cust_Add1_Email);
            param.Add("@Cust_Add2_Line1", customerreq.customer.Cust_Add2_Line1);
            param.Add("@Cust_Add2_Line2", customerreq.customer.Cust_Add2_Line2);
            param.Add("@Cust_Add2_Line3", customerreq.customer.Cust_Add2_Line3);
            param.Add("@Cust_Add2_Line4", customerreq.customer.Cust_Add2_Line4);
            param.Add("@Cust_Add2_prov", customerreq.customer.Cust_Add2_prov);
            param.Add("@Cust_Add2_Cnty", customerreq.customer.Cust_Add2_Cnty);
            param.Add("@Cust_Add2_Telno", customerreq.customer.Cust_Add2_Telno);
            param.Add("@Cust_Add2_Faxno", customerreq.customer.Cust_Add2_Faxno);
            param.Add("@Cust_AcNo1", customerreq.customer.Cust_AcNo1);
            param.Add("@Cust_AcName1", customerreq.customer.Cust_AcName1);
            param.Add("@Cust_AcType1", customerreq.customer.Cust_AcType1);
            param.Add("@Cust_AcFlag1", customerreq.customer.Cust_AcFlag1);
            param.Add("@Cust_AcCcy1", customerreq.customer.Cust_AcCcy1);
            param.Add("@Cust_AcBran1", customerreq.customer.Cust_AcBran1);
            param.Add("@cust_AcRelation1", customerreq.customer.cust_AcRelation1);
            param.Add("@Cust_AcNo2", customerreq.customer.Cust_AcNo2);
            param.Add("@Cust_AcName2", customerreq.customer.Cust_AcName2);
            param.Add("@Cust_AcType2", customerreq.customer.Cust_AcType2);
            param.Add("@Cust_AcFlag2", customerreq.customer.Cust_AcFlag2);
            param.Add("@Cust_AcCcy2", customerreq.customer.Cust_AcCcy2);
            param.Add("@Cust_AcBran2", customerreq.customer.Cust_AcBran2);
            param.Add("@cust_Acrelation2", customerreq.customer.cust_AcRelation2);
            param.Add("@Cust_AcNo3", customerreq.customer.Cust_AcNo3);
            param.Add("@Cust_AcName3", customerreq.customer.Cust_AcName3);
            param.Add("@Cust_AcType3", customerreq.customer.Cust_AcType3);
            param.Add("@Cust_AcFlag3", customerreq.customer.Cust_AcFlag3);
            param.Add("@Cust_AcCcy3", customerreq.customer.Cust_AcCcy3);
            param.Add("@Cust_AcBran3", customerreq.customer.Cust_AcBran3);
            param.Add("@cust_AcRelation3", customerreq.customer.cust_AcRelation3);
            param.Add("@Cust_AcNo4", customerreq.customer.Cust_AcNo4);
            param.Add("@Cust_AcName4", customerreq.customer.Cust_AcName4);
            param.Add("@Cust_AcType4", customerreq.customer.Cust_AcType4);
            param.Add("@Cust_AcFlag4", customerreq.customer.Cust_AcFlag4);
            param.Add("@Cust_AcCcy4", customerreq.customer.Cust_AcCcy4);
            param.Add("@Cust_AcBran4", customerreq.customer.Cust_AcBran4);
            param.Add("@cust_AcRelation4", customerreq.customer.cust_AcRelation4);
            param.Add("@Cust_CommLC", customerreq.customer.Cust_CommLC);

            //param.Add("@CreateDate", DateTime.Now);
            //param.Add("@UpdateDate", DateTime.Now);
            param.Add("@UserCode", customerreq.customer.UserCode);
            param.Add("@AuthDate", DateTime.Now);
            //param.Add("@CreateDate", customerreq.customer.CreateDate);
            //param.Add("@UpdateDate", customerreq.customer.UpdateDate);
            //param.Add("@UserCode", customer.Customer[0].UserCode);
            //param.Add("@AuthDate", customer.Customer[0].AuthDate);
            param.Add("@AuthCode", customerreq.customer.AuthCode);
            param.Add("@DMS", customerreq.customer.DMS);
            param.Add("@Cust_CCEmail", customerreq.customer.Cust_CCEmail);
            param.Add("@Online_Flag", customerreq.customer.Online_Flag);
            param.Add("@CLMS_Flag", customerreq.customer.CLMS_Flag);
            param.Add("@Cust_FilePassword", customerreq.customer.Cust_FilePassword);
            param.Add("@Cust_SBU", customerreq.customer.Cust_SBU);
            param.Add("@Cust_GFMSSBUCode", customerreq.customer.Cust_GFMSSBUCode);
            param.Add("@Cust_RCCode", customerreq.customer.Cust_RCCode);
            param.Add("@Cust_RMCode", customerreq.customer.Cust_RMCode);
            param.Add("@CustRate", dt.AsTableValuedParameter("type_custrate"));

            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 12800);

            param.Add("@CCustRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MCustomerNewReq, dynamic>(
                    storedProcedure: "usp_mcustomerupdate",
                    param);
                var ccode = param.Get<dynamic>("@CRsp");
                var ccustrsp = param.Get<dynamic>("@CCustRsp");
                Log.Information("AccountUpdate Request : {@customerreq}", customerreq);
                if (ccode > 0)
                {
                    Log.Information("AccountUpdate Response : {@ccustrsp}", ccustrsp);
                    return Content(ccustrsp, "application/json");
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Customer code not exist";
                    Log.Information("AccountUpdate Response BadRequest : {@response}", response);
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                Log.Information("AccountUpdate Response BadRequest : {@exception}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] MCustCode custcode)
        {
            DynamicParameters param = new();
            param.Add("@Cust_Code", custcode.Cust_Code);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 12800);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mcustomerdelete", param);
                var crsp = param.Get<dynamic>("@CRsp");
                if (crsp > 0)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Customer code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Customer code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
