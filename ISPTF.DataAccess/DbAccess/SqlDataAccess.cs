using Dapper;
using ISPTF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ISPTF.DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess,IDisposable
    //public class SqlDataAccess :IDisposable
    {
        private readonly IConfiguration _config;
        
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        
        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
        //public async Task NewData<T>(
        //  string storedProcedure,
        //  T parameters,
        //  string connectionId = "DefaultConnection")
        //{

        //    using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        //    await connection.ExecuteAsync(
        //        storedProcedure,
        //        parameters,
        //        commandType: CommandType.StoredProcedure);
        //}
        public async Task SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
            
        
        }
        private bool isClosed = false;
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public void StartTransaction(string connectionId = "DefaultConnection")
        {
            _connection = new SqlConnection(_config.GetConnectionString(connectionId));
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            isClosed = false;
        }

        public async Task <IEnumerable<T>> LoadDataInTransaction<T,U>(
            string storedProcedure, 
            U parameters)
        {
            return await _connection.QueryAsync<T>(
                storedProcedure, 
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);
            //return rows;
        }

        public async Task SaveDataInTransaction<T>(
            string storedProcedure,
            T parameters)
        {
            await _connection.ExecuteAsync(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction);
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();
            isClosed = true;
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();
            isClosed = true;
        }

        public void Dispose()
        {
            if (!isClosed)
            {
                try
                {
                    CommitTransaction();
                }
                catch
                {
                    // TODO: Log this issue
                }
            }
            _transaction = null;
            _connection = null;
        }

        // TODO: Open connection/start transaction method
        // load using the transaction
        // save using the transaction
        // close connection/stop transaction method
        // dispose
    }

}
