
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DapperExtensions;
using Dapper;
using System.Data;

using Newtonsoft.Json;

namespace Db.Isolate
{
    public  class DapperCrud
    {
        private string _connectionString;
        private SqlConnection sqlConnection;
        private SqlTransaction transaction;
        public DapperCrud(string connectionString)
        {
            _connectionString = connectionString;
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool Insert<T>(T parameter, string connectionString) where T : class
        {
            sqlConnection.Open();
            sqlConnection.Insert(parameter);
            sqlConnection.Close();
            return true;
        }

        internal void ExecuteStoredProcedure(string procedureName , string connectionString)
        {
            try
            {
                sqlConnection.Open();
                var RS = sqlConnection.Execute(procedureName, null, null, null, commandType: CommandType.StoredProcedure);
            }
            finally
            {
                sqlConnection.Close();
            }
                   
        }

        internal void ExecuteCommand(string command, string connectionString)
        {            
            try
            {
                sqlConnection.Open();
                sqlConnection.Execute(command);
            }
            finally
            {
                sqlConnection.Close();
            }           
        }

        internal void RollbackTransaction()
        {           
            transaction.Rollback();
        }

        internal void BeginTransaction()
        {
           transaction = sqlConnection.BeginTransaction();
        }

        public bool InsertQuery<T>(T parameter,string query, string connectionString) where T : class
        {
            try
            {
                sqlConnection.Open();
                sqlConnection.Execute(query, parameter);
            }
            finally
            {
                sqlConnection.Close();
            }            
            return true;
            
        }

        public  int InsertWithReturnId<T>(T parameter, string connectionString) where T : class
        {
            int recordId;
            try
            {
                sqlConnection.Open();
                recordId = sqlConnection.Insert(parameter);
            }
            finally
            {
                sqlConnection.Close();
            }            
            return recordId;
            
        }

        public  bool Update<T>(T parameter, string connectionString) where T : class
        {
            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
                sqlConnection.Open();
                sqlConnection.Update(parameter);
                sqlConnection.Close();
                return true;
            //}
        }

        public  IList<T> GetAll<T>(string connectionString) where T : class
        {            
            sqlConnection.Open();
            var result = sqlConnection.GetList<T>();
            sqlConnection.Close();
            return result.ToList();            
        }

        public  T Find<T>(PredicateGroup predicate, string connectionString) where T : class
        {
            sqlConnection.Open();
            var result = sqlConnection.GetList<T>(predicate).FirstOrDefault();
            sqlConnection.Close();
            return result;           
        }

        public  bool Delete<T>(PredicateGroup predicate, string connectionString) where T : class
        {
            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
                sqlConnection.Open();
                sqlConnection.Delete<T>(predicate);
                sqlConnection.Close();
                return true;
            //}
        }

        public  string QuerySP<T>(string storedProcedure, dynamic param = null,
            dynamic outParam = null, SqlTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null, string connectionString = null) where T : class
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var output = connection.Query<dynamic>(storedProcedure, param: (object)param,
                transaction: transaction, buffered: buffered, commandTimeout: commandTimeout, commandType: CommandType.StoredProcedure);
            
            string json = JsonConvert.SerializeObject(
                  output.Select(x => x)
                  , formatting: Newtonsoft.Json.Formatting.Indented
                    , settings: new JsonSerializerSettings
                    {
                        DateParseHandling = DateParseHandling.None,
                        Converters = { new TextConverter<int>() ,
                                       new TextConverter<Boolean>()
                        }
                    }
                );
            return json;
        }

        private  void CombineParameters(ref dynamic param, dynamic outParam = null)
        {
            if (outParam != null)
            {
                if (param != null)
                {
                    param = new DynamicParameters(param);
                    ((DynamicParameters)param).AddDynamicParams(outParam);
                }
                else
                {
                    param = outParam;
                }
            }
        }

        private  int ConnectionTimeout { get; set; }

        private  int GetTimeout(int? commandTimeout = null)
        {
            if (commandTimeout.HasValue)
                return commandTimeout.Value;

            return ConnectionTimeout;
        }



    }
}

