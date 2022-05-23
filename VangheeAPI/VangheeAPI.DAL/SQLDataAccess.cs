using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System;

namespace VangheeAPI.DAL
{
    public class SQLDataAccess : IDisposable
    {
        protected readonly IConfiguration _config;
        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        private IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;
        public void StartTransaction()
        {
            _dbConnection = this.Connection;
            _dbConnection.Open();
            _dbTransaction =_dbConnection.BeginTransaction();
            
        }

        public void SaveDataInTransaction<T>(string storeProcedure, T Parameters)
        {
            _dbConnection.Execute(storeProcedure, Parameters, commandType: CommandType.StoredProcedure, transaction: _dbTransaction);
        }

        public List<T> LoadDataInTransaction<T, U>(string storeProcedure, U parameters)
        {
            List<T> rows= _dbConnection.Query<T>(storeProcedure, parameters,commandType:CommandType.StoredProcedure,transaction:_dbTransaction).ToList();
            return rows;
        }
        public void CommitTransaction()
        {
            _dbTransaction?.Commit();
            _dbConnection?.Close();
        }
        public void RollbackTransaction()
        {
            _dbTransaction?.Rollback();
            _dbConnection?.Close();
        }
        public void Dispose()
        {
            //CommitTransaction();
        }
        
    }
}
