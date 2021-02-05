
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
        private string _masterDbconnectionString;
        private SqlConnection sqlConnection;
        private SqlConnection sqlMasterDbConnection;
        private SqlTransaction transaction;

        private static readonly DapperCrud instance = new DapperCrud();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static DapperCrud()
        {
        }

        private DapperCrud()
        {            
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            _masterDbconnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerMasterConnString"].ConnectionString;
            sqlConnection = new SqlConnection(_connectionString);
            sqlMasterDbConnection = new SqlConnection(_masterDbconnectionString);
        }

        internal int QueryScalarIntResult(string query)
        {
            object values = DapperRowToObject(query);
            return Convert.ToInt32(values);
        }

        private object DapperRowToObject(string query)
        {
            var firstRow = sqlConnection.Query(query, transaction: transaction).ToList().FirstOrDefault();
            var Heading = ((IDictionary<string, object>)firstRow).Keys.ToArray();
            var details = ((IDictionary<string, object>)firstRow);
            var values = details[Heading[0]];
            return values;
        }

        internal int QueryScalarResultCount(string query)
        {
            return sqlConnection.Query(query , transaction:transaction).ToList().Count;
        }

        internal string QueryScalarStringResult(string query)
        {
            object values = DapperRowToObject(query);
            return values.ToString();
        }

        internal IEnumerable<T> Query<T>(string query)
        {
            return sqlConnection.Query<T>(query, transaction: transaction).ToList();
        }

        internal string Query(string query)
        {
            var output = sqlConnection.Query(query, transaction: transaction);
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
        public static DapperCrud Instance
        {
            get
            {
                return instance;
            }
        }
        //public DapperCrud(string connectionstring)
        //{
        //    _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerMasterConnString"].ConnectionString; ;
        //    _masterDbconnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerMasterConnString"].ConnectionString; ;
        //    sqlConnection = new SqlConnection(connectionstring);
        //    sqlMasterDbConnection = new SqlConnection(_masterDbconnectionString);
        //}

        public void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }
        public bool Insert<T>(T parameter, string connectionString) where T : class
        {
            //sqlConnection.Open();
            sqlConnection.Insert(parameter);
            //sqlConnection.Close();
            return true;
        }

        internal void ExecuteStoredProcedure(string procedureName , string connectionString)
        {
            try
            {
                //sqlConnection.Open();
                var RS = sqlConnection.Execute(procedureName, null, null, null, commandType: CommandType.StoredProcedure);
            }
            finally
            {
                //sqlConnection.Close();
            }
                   
        }

        internal void ExecuteCommand(string command, string connectionString)
        {            
            try
            {
                //sqlConnection.Open();
                sqlConnection.Execute(command);
            }
            finally
            {
                //sqlConnection.Close();
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
                //sqlConnection.Open();
                sqlConnection.Execute(query, parameter, transaction:this.transaction);
            }
            finally
            {
                //sqlConnection.Close();
            }            
            return true;
            
        }

        public  int InsertWithReturnId<T>(T parameter, string connectionString) where T : class
        {
            int recordId;
            try
            {
                //sqlConnection.Open();
                recordId = sqlConnection.Insert(parameter, transaction: this.transaction);
            }
            finally
            {
                //sqlConnection.Close();
            }            
            return recordId;
            
        }

        public  bool Update<T>(T parameter, string connectionString) where T : class
        {
            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
                //sqlConnection.Open();
                sqlConnection.Update(parameter, transaction: this.transaction);
                //sqlConnection.Close();
                return true;
            //}
        }

        public  IList<T> GetAll<T>(string connectionString) where T : class
        {            
            //sqlConnection.Open();
            var result = sqlConnection.GetList<T>();
            //sqlConnection.Close();
            return result.ToList();            
        }

        public  T Find<T>(PredicateGroup predicate, string connectionString) where T : class
        {
            //sqlConnection.Open();
            var result = sqlConnection.GetList<T>(predicate).FirstOrDefault();           
            //sqlConnection.Close();
            return result;           
        }

        public  bool Delete<T>(PredicateGroup predicate, string connectionString) where T : class
        {
            //using (var sqlConnection = new SqlConnection(connectionString))
            //{
                //sqlConnection.Open();
                sqlConnection.Delete<T>(predicate, transaction: this.transaction);
                //sqlConnection.Close();
                return true;
            //}
        }

        public  string QuerySP<T>(string storedProcedure, dynamic param = null,
            dynamic outParam = null, SqlTransaction transaction = null,
            bool buffered = true, int? commandTimeout = null, string connectionString = null) where T : class
        {
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            var output = sqlConnection.Query<dynamic>(storedProcedure, param: (object)param,
                transaction: this.transaction, buffered: buffered, commandTimeout: commandTimeout, commandType: CommandType.StoredProcedure);
            
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

