using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.PControlPack;
using ISPTF.Models.PIMTRInvoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
 
namespace ISPTF.API.Controllers.LoginRegis
{
    [ApiController]
    [Route("api/[controller]")]
    public class CONTPACKController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public CONTPACKController(ISqlDataAccess db)
        {
            _db = db;
        }
        //[HttpGet("select")]
        //public async Task<IEnumerable<PDocRegister>> GetAll(string? RegDocNo)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@RegDocNo", RegDocNo);

        //    var results = await _db.LoadData<PDocRegister, dynamic>(
        //                storedProcedure: "usp_pDocRegisterSelect",
        //                param);
        //    return results;
        //}

        [HttpGet("Packing/list")]
        public async Task<IEnumerable<Q_Get_pControlPack_Packing_PageRsp>> GetPCList( string? CenterID, string? ContNo, string? CustCode, string? CustName, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            //param.Add("LogType", LogType);
            param.Add("@CenterID", CenterID);
            param.Add("@ContNo", ContNo);
            param.Add("@CustCode", CustCode);
            param.Add("@CustName", CustName);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (ContNo == null)
            {
                param.Add("@ContNo", "");
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            if (CustName == null)
            {
                param.Add("@CustName", "");
            }

            var results = await _db.LoadData<Q_Get_pControlPack_Packing_PageRsp, dynamic>(
                        storedProcedure: "usp_q_Get_pControlPack_SelectPagePC",
                        param);
            return results;
        }


        [HttpGet("Packing/select")]
        public async Task<IEnumerable<PControlPackListRsp>> GetPCSelect( string? ContNo )
        {
            DynamicParameters param = new();

            param.Add("@ContNo", ContNo);

            var results = await _db.LoadData<PControlPackListRsp    , dynamic>(
                        storedProcedure: "usp_pControlPack_Select",
                        param);
            return results;
        }

        [HttpGet("CheckReferenceNo")]
        public async Task<IEnumerable<PControlPack_CheckRep>> CheckReferenceNo(string? ReferLcNo, string? ContNo)
        {
            DynamicParameters param = new();

            param.Add("@ReferLcNo", ReferLcNo);
            param.Add("@ContNo", ContNo);

            var results = await _db.LoadData<PControlPack_CheckRep, dynamic>(
                        storedProcedure: "usp_pControlPack_CheckRefNo",
                        param);
            return results;
        }

        [HttpPost("Packing/save")]
        public async Task<ActionResult<List<PControlPackRsp>>> Save([FromBody] PControlPackSaveReq pControlPack)
        {
            DynamicParameters param = new DynamicParameters();
            //param.Add("@ScreenMenu", pdocregisterreq.ScreenMenu);
            param.Add("@ContNo", pControlPack.ContNo);
            param.Add("@ContDate", pControlPack.ContDate);
            param.Add("@ContTime", pControlPack.ContTime);
            param.Add("@CustCode", pControlPack.CustCode);
            param.Add("@CustInfo", pControlPack.CustInfo);
            param.Add("@CntyCode", pControlPack.CntyCode);
            param.Add("@AppName", pControlPack.AppName);
            param.Add("@GoodCode", pControlPack.GoodCode);
            param.Add("@RelCode", pControlPack.RelCode);
            param.Add("@ShipmentFr", pControlPack.ShipmentFr);
            param.Add("@ShipmentTo", pControlPack.ShipmentTo);
            param.Add("@GoodDesc", pControlPack.GoodDesc);
            param.Add("@PackUnder", pControlPack.PackUnder);
            param.Add("@ReferLcNo", pControlPack.ReferLcNo);
            param.Add("@DocCcy", pControlPack.DocCcy);
            param.Add("@DocAmount", pControlPack.DocAmount);
            param.Add("@DocBalance", pControlPack.DocBalance);
            param.Add("@UseAmount", pControlPack.UseAmount);
            param.Add("@IssueDate", pControlPack.IssueDate);
            param.Add("@Expirydate", pControlPack.Expirydate);
            //param.Add("@UpdateDate", pControlPack.UpdateDate);
            param.Add("@UserCode", pControlPack.UserCode);
            param.Add("@ContStatus", pControlPack.ContStatus);
            param.Add("@InUser", pControlPack.InUser);
            param.Add("@CenterID", pControlPack.CenterID);


            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<PControlPackRsp, dynamic>(
                    storedProcedure: "usp_pControlPack_Save",
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
                    response.Message = "Save CONPACK Error";
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
