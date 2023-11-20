using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.BankFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BankFileController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public BankFileController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<MBankFileRsp>> GetAll(string? bankcode)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", bankcode);
            if (bankcode =="*" || bankcode == null)
            {
                param.Add("@Bank_Code", "*");
            }
            else
            {
                param.Add("@Bank_Code", bankcode);
            }
            var results = await _db.LoadData<MBankFileRsp, dynamic>(
                             storedProcedure: "usp_mbankfileselect",
                             param);
            return results;

        }

        [HttpGet("swiftbank")]  // SwiftBank
        public async Task<IEnumerable<MBankFileGetSwiftRsp>> GetSelSW(string? bankcode, string? Page, string? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", bankcode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (bankcode == "*" || bankcode == null)
            {
                param.Add("@Bank_Code", "");
            }
            else
            {
                param.Add("@Bank_Code", bankcode);
            }
            var results = await _db.LoadData<MBankFileGetSwiftRsp, dynamic>(
                             storedProcedure: "usp_mbankGetSwiftBk",
                             param);
            return results;

        }

        [HttpGet("BNetUID")]  // BNet UID
        public async Task<IEnumerable<MBankFileBNetUIDRsp>> GetSelUID(string? bankcode)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", bankcode);
            if (bankcode == "*" || bankcode == null)
            {
                param.Add("@Bank_Code", "*");
            }
            else
            {
                param.Add("@Bank_Code", bankcode);
            }
            var results = await _db.LoadData<MBankFileBNetUIDRsp, dynamic>(
                             storedProcedure: "usp_mbankGetBNetUID",
                             param);
            return results;

        }

        [HttpGet("BankActive")]
        public async Task<IEnumerable<MBankFileActiveRsp>> GetBankActive(string? BankCode,string? BankName ,string? Page, string? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", BankCode);
            param.Add("@Bank_Name", BankName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (BankCode == null)
            {
                param.Add("@Bank_Code", "");
            }
            if (BankName == null)
            {
                param.Add("@Bank_Name", "");
            }

            var results = await _db.LoadData<MBankFileActiveRsp, dynamic>(
                             storedProcedure: "usp_mBankFileSelect_Active",
                             param);
            return results;

        }

        [HttpGet("BankActiveExport")]
        public async Task<IEnumerable<MBankFileActiveExportRsp>> GetBankActiveExport(string? BankCode, string? BankName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", BankCode);
            param.Add("@Bank_Name", BankName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (BankCode == null)
            {
                param.Add("@Bank_Code", "");
            }
            if (BankName == null)
            {
                param.Add("@Bank_Name", "");
            }

            var results = await _db.LoadData<MBankFileActiveExportRsp, dynamic>(
                             storedProcedure: "usp_mBankFileSelect_Active_Export",
                             param);
            return results;

        }

        [HttpGet("BankNostro")]
        public async Task<IEnumerable<MBankFileBankNostro>> GetBankNostro(string? NostroBank, string? BankName, string? NostroCcy, string? Page, string? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@NostroBank", NostroBank);
            param.Add("@Bank_Name", BankName);
            param.Add("@Nostro_Ccy", NostroCcy);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (NostroBank == null)
            {
                param.Add("@NostroBank", "");
            }
            if (BankName == null)
            {
                param.Add("@Bank_Name", "");
            }
            if (NostroCcy == null)
            {
                param.Add("@Nostro_Ccy", "");
            }

            var results = await _db.LoadData<MBankFileBankNostro, dynamic>(
                             storedProcedure: "usp_mBankFileSelect_BankNostro",
                             param);
            return results;

        }

        [HttpGet("BankWREF")]
        public async Task<IEnumerable<MBankFileBankWREFRsp>> GetBankWREF(string? BankCode, string? BankName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", BankCode);
            param.Add("@Bank_Name", BankName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (BankCode == null)
            {
                param.Add("@Bank_Code", "");
            }
            if (BankName == null)
            {
                param.Add("@Bank_Name", "");
            }

            var results = await _db.LoadData<MBankFileBankWREFRsp, dynamic>(
                             storedProcedure: "usp_mBankFileSelect_BankWREF",
                             param);
            return results;

        }

        [HttpGet("ViewBankLimit")]
        public async Task<IEnumerable<MBankFileViewBankLimitRsp>> GetBankLimit(string? BankCode, string? BankName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", BankCode);
            param.Add("@Bank_Name", BankName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (BankCode == null)
            {
                param.Add("@Bank_Code", "");
            }
            if (BankName == null)
            {
                param.Add("@Bank_Name", "");
            }

            var results = await _db.LoadData<MBankFileViewBankLimitRsp, dynamic>(
                             storedProcedure: "usp_mBankFileSelect_ViewBankLimit",
                             param);
            return results;

        }





        [HttpPost("insert")]
        public async Task<ActionResult<MBankFileRsp>>Insert([FromBody] MBankFileReqInsertUpdate bankfile)
        { 
            DynamicParameters param = new();
            param.Add("@Bank_Code", bankfile.Bank_Code);
            param.Add("@Bank_Name", bankfile.Bank_Name);
            param.Add("@Bank_Flag", bankfile.Bank_Flag);
            param.Add("@Bank_Status", bankfile.Bank_Status);
            param.Add("@Bank_Ccy", bankfile.Bank_Ccy);
            param.Add("@Bank_Swift", bankfile.Bank_Swift);
            param.Add("@Bank_Authen", bankfile.Bank_Authen);
            param.Add("@Bank_Rating", bankfile.Bank_Rating);
            param.Add("@Bank_Add1", bankfile.Bank_Add1);
            param.Add("@Bank_Add2", bankfile.Bank_Add2);
            param.Add("@Bank_Add3", bankfile.Bank_Add3);
            param.Add("@Bank_Add4", bankfile.Bank_Add4);
            param.Add("@Bank_AddSw1", bankfile.Bank_AddSw1);
            param.Add("@Bank_AddSw2", bankfile.Bank_AddSw2);
            param.Add("@Bank_AddSw3", bankfile.Bank_AddSw3);
            param.Add("@Bank_AddSw4", bankfile.Bank_AddSw4);
            param.Add("@Bank_AddSw5", bankfile.Bank_AddSw5);
            param.Add("@Bank_AddSw6", bankfile.Bank_AddSw6);
            param.Add("@Bank_AddSw7", bankfile.Bank_AddSw7);
            param.Add("@Bank_City", bankfile.Bank_City);
            param.Add("@Bank_Zip", bankfile.Bank_Zip);
            param.Add("@Bank_Cnty", bankfile.Bank_Cnty);
            param.Add("@Bank_LimitCode1", bankfile.Bank_LimitCode1);
            param.Add("@Bank_LimitCcy1", bankfile.Bank_LimitCcy1);
            param.Add("@Bank_LimitAmt1", bankfile.Bank_LimitAmt1);
            param.Add("@Bank_LimitCode2", bankfile.Bank_LimitCode2);
            param.Add("@Bank_LimitCcy2", bankfile.Bank_LimitCcy2);
            param.Add("@Bank_LimitAmt2", bankfile.Bank_LimitAmt2);
            param.Add("@Bank_LimitCode3", bankfile.Bank_LimitCode3);
            param.Add("@Bank_LimitCcy3", bankfile.Bank_LimitCcy3);
            param.Add("@Bank_LimitAmt3", bankfile.Bank_LimitAmt3);
            param.Add("@Bank_AcCcy1", bankfile.Bank_AcCcy1);
            param.Add("@Bank_AcCode1", bankfile.Bank_AcCode1);
            param.Add("@Bank_AcName1", bankfile.Bank_AcName1);
            param.Add("@Bank_Nostro1", bankfile.Bank_Nostro1);
            param.Add("@Bank_AcCcy2", bankfile.Bank_AcCcy2);
            param.Add("@Bank_AcCode2", bankfile.Bank_AcCode2);
            param.Add("@Bank_AcName2", bankfile.Bank_AcName2);
            param.Add("@Bank_Nostro2", bankfile.Bank_Nostro2);
            param.Add("@Bank_AcCcy3", bankfile.Bank_AcCcy3);
            param.Add("@Bank_AcCode3", bankfile.Bank_AcCode3);
            param.Add("@Bank_AcName3", bankfile.Bank_AcName3);
            param.Add("@Bank_Nostro3", bankfile.Bank_Nostro3);
            param.Add("@Bank_Rebate", bankfile.Bank_Rebate);
            param.Add("@Bank_Nego", bankfile.Bank_Nego);
            param.Add("@Bank_Outsource", bankfile.Bank_Outsource);
            param.Add("@Bank_Relay", bankfile.Bank_Relay);
            param.Add("@Bank_Reissue", bankfile.Bank_Reissue);
            param.Add("@RecStatus", bankfile.RecStatus);
            param.Add("@Bank_Remark", bankfile.Bank_Remark);
            param.Add("@UserCode", bankfile.UserCode);
            param.Add("@AuthCode", bankfile.AuthCode);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MBankFileRsp, dynamic>(
                    storedProcedure: "usp_mbankfileinsert",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Bank code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<ActionResult<MBankFileRsp>> Update([FromBody] MBankFileReqInsertUpdate bankfile)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", bankfile.Bank_Code);
            param.Add("@Bank_Name", bankfile.Bank_Name);
            param.Add("@Bank_Flag", bankfile.Bank_Flag);
            param.Add("@Bank_Status", bankfile.Bank_Status);
            param.Add("@Bank_Ccy", bankfile.Bank_Ccy);
            param.Add("@Bank_Swift", bankfile.Bank_Swift);
            param.Add("@Bank_Authen", bankfile.Bank_Authen);
            param.Add("@Bank_Rating", bankfile.Bank_Rating);
            param.Add("@Bank_Add1", bankfile.Bank_Add1);
            param.Add("@Bank_Add2", bankfile.Bank_Add2);
            param.Add("@Bank_Add3", bankfile.Bank_Add3);
            param.Add("@Bank_Add4", bankfile.Bank_Add4);
            param.Add("@Bank_AddSw1", bankfile.Bank_AddSw1);
            param.Add("@Bank_AddSw2", bankfile.Bank_AddSw2);
            param.Add("@Bank_AddSw3", bankfile.Bank_AddSw3);
            param.Add("@Bank_AddSw4", bankfile.Bank_AddSw4);
            param.Add("@Bank_AddSw5", bankfile.Bank_AddSw5);
            param.Add("@Bank_AddSw6", bankfile.Bank_AddSw6);
            param.Add("@Bank_AddSw7", bankfile.Bank_AddSw7);
            param.Add("@Bank_City", bankfile.Bank_City);
            param.Add("@Bank_Zip", bankfile.Bank_Zip);
            param.Add("@Bank_Cnty", bankfile.Bank_Cnty);
            param.Add("@Bank_LimitCode1", bankfile.Bank_LimitCode1);
            param.Add("@Bank_LimitCcy1", bankfile.Bank_LimitCcy1);
            param.Add("@Bank_LimitAmt1", bankfile.Bank_LimitAmt1);
            param.Add("@Bank_LimitCode2", bankfile.Bank_LimitCode2);
            param.Add("@Bank_LimitCcy2", bankfile.Bank_LimitCcy2);
            param.Add("@Bank_LimitAmt2", bankfile.Bank_LimitAmt2);
            param.Add("@Bank_LimitCode3", bankfile.Bank_LimitCode3);
            param.Add("@Bank_LimitCcy3", bankfile.Bank_LimitCcy3);
            param.Add("@Bank_LimitAmt3", bankfile.Bank_LimitAmt3);
            param.Add("@Bank_AcCcy1", bankfile.Bank_AcCcy1);
            param.Add("@Bank_AcCode1", bankfile.Bank_AcCode1);
            param.Add("@Bank_AcName1", bankfile.Bank_AcName1);
            param.Add("@Bank_Nostro1", bankfile.Bank_Nostro1);
            param.Add("@Bank_AcCcy2", bankfile.Bank_AcCcy2);
            param.Add("@Bank_AcCode2", bankfile.Bank_AcCode2);
            param.Add("@Bank_AcName2", bankfile.Bank_AcName2);
            param.Add("@Bank_Nostro2", bankfile.Bank_Nostro2);
            param.Add("@Bank_AcCcy3", bankfile.Bank_AcCcy3);
            param.Add("@Bank_AcCode3", bankfile.Bank_AcCode3);
            param.Add("@Bank_AcName3", bankfile.Bank_AcName3);
            param.Add("@Bank_Nostro3", bankfile.Bank_Nostro3);
            param.Add("@Bank_Rebate", bankfile.Bank_Rebate);
            param.Add("@Bank_Nego", bankfile.Bank_Nego);
            param.Add("@Bank_Outsource", bankfile.Bank_Outsource);
            param.Add("@Bank_Relay", bankfile.Bank_Relay);
            param.Add("@Bank_Reissue", bankfile.Bank_Reissue);
            param.Add("@RecStatus", bankfile.RecStatus);
            param.Add("@Bank_Remark", bankfile.Bank_Remark);
            param.Add("@UserCode", bankfile.UserCode);
            param.Add("@AuthCode", bankfile.AuthCode);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MBankFileRsp, dynamic>(
                    storedProcedure: "usp_mbankfileupdate",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                    //return Ok("Bank File code deleted");
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Bank File code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] MBankFileReq bankcodereq)
        {
            DynamicParameters param = new();
            param.Add("@Bank_Code", bankcodereq.Bank_Code);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mbankfiledelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Bank code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Bank code not exist";
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
