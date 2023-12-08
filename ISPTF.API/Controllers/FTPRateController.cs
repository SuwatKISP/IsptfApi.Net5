using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.DataAccess.DbAccess;
using Dapper;
using System.Globalization;
using System.Threading;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using Serilog;
using ISPTF.Models;
using Microsoft.SqlServer;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ISPTF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FTPRateController : ControllerBase
    {
        private static string cSql;
        private static DataTable dt;

        private readonly ISqlDataAccess _db;
        private readonly ILogger<FTPRateController> _logger;
        private readonly IConfiguration _config;

        public FTPRateController(ISqlDataAccess db, ILogger<FTPRateController> logger, IConfiguration config)
        {
            _db = db;
            _logger = logger;
            _config = config;
        }

        [HttpGet("export")]
        public async Task Export(string RateDate)
        {
            CultureInfo ci = new CultureInfo("en_US");
            Thread.CurrentThread.CurrentCulture = ci;
            var exelDate = string.Format("{0:dd MMM yyyy}",
                Convert.ToDateTime(
                    RateDate.Substring(0, 4) + "/" +
                    RateDate.Substring(4, 2) + "/" +
                    RateDate.Substring(6, 2), ci)
            );
            var exelFile = @"c:\Temp\TPRRate\FTP Rate as at " + exelDate + ".xlsm";
            Log.Information(@"Excel File c:\Temp\TPRRate\FTP Rate as at " + exelDate + ".xlsm");
            //var exelFile = Filename + ".xlsm";
            if (System.IO.File.Exists(exelFile))
            {
                Log.Information(exelFile + " found");
                //Program.LogData(exelFile + " found");
            }
            else
            {
                Log.Information(exelFile + " not found");
                //Program.LogData(exelFile + " not found");
            }
            XSSFWorkbook xssfwb;

            using (FileStream file = new FileStream(exelFile, FileMode.Open, FileAccess.Read))
            {
                xssfwb = new XSSFWorkbook(file);
            }
            cSql = "Delete from TPR_Rate where Rate_Type='TPR' and RateDate between '" + RateDate + " 00:00:00' and '" + RateDate + " 23:59:59'";

            using IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync(cSql);

            ReadExcelSheet(xssfwb, "THB", RateDate);
            ReadExcelSheet(xssfwb, "USD", RateDate);
            ReadExcelSheet(xssfwb, "EUR", RateDate);
            ReadExcelSheet(xssfwb, "JPY", RateDate);

        }
        private void ReadExcelSheet(XSSFWorkbook xssfwb, string sheetname, string RateDate)
        {
            ISheet sheet = xssfwb.GetSheet(sheetname);      // THB USD EUR JPY
            int startRow;
            int endRow;
            if (sheetname == "THB")
            {
                startRow = 14;
                endRow = 27;
            }
            else
            {
                startRow = 9;
                endRow = 22;
            }
            Log.Information("Sheet Name: " + sheetname);
            //Program.LogData("Sheet Name: " + sheetname);
            
            for (int row = startRow; row < endRow; row++)
            {
                if (sheet.GetRow(row) != null)          //null is when the row only contains empty cells
                {
                    Log.Information(string.Format("Row {0} = Tenor:{1} Base:{2} LP:{3} SRR:{4} LCC:{5} COF:{6}",
                        row,
                        sheet.GetRow(row).GetCell(1).StringCellValue,
                        (Convert.ToDecimal(sheet.GetRow(row).GetCell(2).ToString()) * 100).ToString("#0.00"),
                        (Convert.ToDecimal(sheet.GetRow(row).GetCell(3).ToString()) * 100).ToString("#0.00"),
                        (Convert.ToDecimal(sheet.GetRow(row).GetCell(4).ToString()) * 100).ToString("#0.00"),
                        (Convert.ToDecimal(sheet.GetRow(row).GetCell(5).ToString()) * 100).ToString("#0.00"),
                        (Convert.ToDecimal(sheet.GetRow(row).GetCell(6).ToString()) * 100).ToString("#0.00")));
                    string termType = sheet.GetRow(row).GetCell(1).StringCellValue;
                    switch (termType)
                    {
                        case "1W":
                            termType = "1 WEEK";
                            break;
                        case "1M":
                        case "1M/Call":
                            termType = "1 MONTH";
                            break;
                        case "2M":
                            termType = "2 MONTHS";
                            break;
                        case "3M":
                            termType = "3 MONTHS";
                            break;
                        case "4M":
                            termType = "4 MONTHS";
                            break;
                        case "5M":
                            termType = "5 MONTHS";
                            break;
                        case "6M":
                            termType = "6 MONTHS";
                            break;
                        case "7M":
                            termType = "7 MONTHS";
                            break;
                        case "8M":
                            termType = "8 MONTHS";
                            break;
                        case "9M":
                            termType = "9 MONTHS";
                            break;
                        case "10M":
                            termType = "10 MONTHS";
                            break;
                        case "11M":
                            termType = "11 MONTHS";
                            break;
                        case "1Y":
                            termType = "1 YEAR";
                            break;
                    }
                    cSql = "insert into TPR_Rate";
                    cSql += " (Rate_Type,CurCode,TermType,Rate,RateDate,Delete_Flag,Load_Flag,ZZStrdate,ZZDate,ZZUser,FileName) ";
                    cSql += " values ('TPR','" + sheetname + "','" + termType + "',";
                    cSql += "'" + (Convert.ToDecimal(sheet.GetRow(row).GetCell(6).ToString()) * 100).ToString("#0.00") + "',";
                    cSql += "'" + RateDate + "','0','Y','" + RateDate + "','" + RateDate + "','admin','') ";

                    using IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                    connection.Execute(cSql);
                }
            }
        }
    }
}
