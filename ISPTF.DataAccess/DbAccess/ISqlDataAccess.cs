using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISPTF.DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure, 
            U parameters, 
            string connectionId = "DefaultConnection");

        //Task<IEnumerable<T>> NewData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultConnection");
        
        Task SaveData<T>(
            string storedProcedure, 
            T parameters, 
            string connectionId = "DefaultConnection");

        Task<IEnumerable<T>> LoadDataInTransaction<T, U>(
            string storedProcedure,
            U parameters
        );

        Task SaveDataInTransaction<T>(
            string storedProcedure,
            T parameters);

        void StartTransaction(string connectionId = "DefaultConnection");

        void CommitTransaction();

        void RollbackTransaction();
    }
}