using ISPTF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

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
                using (SqlCommand command = new SqlCommand("SELECT GETDATE()", connection))
                {
                    DateTime currentDate = (DateTime)command.ExecuteScalar();
                    return currentDate;
                }
            }
        }
    }
}
