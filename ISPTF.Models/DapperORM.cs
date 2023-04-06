using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class DapperORM 
    {
        public static IConfiguration Configuration;

        //public static async void ExecuteWithoutReturn(
        // string procedureName,
        // DynamicParameters param = null)
        //{
        public static void ExecuteWithoutReturn(
            string procedureName,
            DynamicParameters param = null)
        {
            using (var connection = new SqlConnection (Configuration.GetConnectionString("DefaultConnection")))
            {
                //await connection.ExecuteAsync(procedureName,
                //  param,
                //  commandType: CommandType.StoredProcedure
                //  );
                connection.Execute(procedureName,
                    param,
                    commandType: CommandType.StoredProcedure
                    );
            }

        }
        //public static async Task<T> ExecuteReturnScalar<T>(
        //     string procedureName,
        //     DynamicParameters param=null)
        //{
        public static T ExecuteReturnScalar<T>(
            string procedureName,
            DynamicParameters param = null)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                //var result=await connection.ExecuteScalarAsync(procedureName,
                //    param,
                //    commandType: CommandType.StoredProcedure);
                //return (T)Convert.ChangeType(result, typeof(T));
                return (T)Convert.ChangeType(connection.ExecuteScalar(procedureName,
                    param,
                    commandType: CommandType.StoredProcedure), typeof(T)
                    );
            }

        }

        // DapperORM.QueryReturnList<T>
        //public static async Task<IEnumerable<T>> QueryReturnList<T>(
        //    string procedureName,
        //    DynamicParameters param = null)
        //{
        public static IEnumerable<T> QueryReturnList<T>(
             string procedureName,
             DynamicParameters param = null)
        {
            using (var connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                //var results = await connection.QueryAsync<T>(procedureName,
                //    param,
                //    commandType: CommandType.StoredProcedure
                //    );
                //return results;

                //return await connection.QueryAsync<T>(procedureName,
                //  param,
                //  commandType: CommandType.StoredProcedure
                //  );

                return connection.Query<T>(procedureName,
                    param,
                    commandType: CommandType.StoredProcedure
                    );
            }

        }

    }
}
