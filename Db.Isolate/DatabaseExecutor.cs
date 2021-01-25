using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Db.Isolate
{
    public class DatabaseExecutor : IDatabaseExecutor
    {       
       
        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
        static DapperCrud crudOperation = new DapperCrud(connectionString);

        public void ExecuteCommand(string command)
        {
            crudOperation.ExecuteCommand(command, connectionString);
        }

        public string ExecuteStoredProcedure(string procedureName)
        {            
            return crudOperation.QuerySP<dynamic>(procedureName, null, null, null, false, null, connectionString: connectionString);
        }
        public string ExecuteStoredProcedure(string procedureName, string inParamJson)
        {
            DynamicParameters input = ConstructInParams(inParamJson);
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Query(procedureName, input, commandType: CommandType.StoredProcedure);

                var json = JObject.Parse(inParamJson);
                JObject resultJson = new JObject();
                foreach (var obj in json.Children<JToken>())
                {
                    var prop = ((Newtonsoft.Json.Linq.JProperty)obj);
                    if (prop.Name.Contains("(out)"))
                    {
                        var outparamName = "@" + prop.Name.Replace("(out)", "");
                        var value = input.Get<string>(outparamName);
                        var newProperty = new JProperty(prop.Name, value);
                        resultJson.Add(newProperty);
                    }
                }                
                return resultJson.ToString().Replace("\r\n", "")
                            .Replace("(out)", "");
            }

        }

        private DynamicParameters ConstructInParams(string inParamJson)
        {
            DynamicParameters parameters = new DynamicParameters();
            var json = JObject.Parse(inParamJson);
            JObject resultJson = new JObject();
            foreach (var obj in json.Children<JToken>())
            {
                var prop = ((Newtonsoft.Json.Linq.JProperty)obj);
                var paramName = "@" + prop.Name.Replace("(out)", "");
                if (prop.Name.Contains("(out)"))
                {                    
                    var value = String.Empty;
                    parameters.Add(paramName, value, DbType.String, ParameterDirection.Output);
                }
                else
                {
                    parameters.Add(paramName, ((Newtonsoft.Json.Linq.JValue)prop.Value).Value);
                }
            }
           
            return parameters;
        }

        
        public void SetTableData(string tableName, string tableJson)
        {
            JObject json = JObject.Parse(tableJson);            
            JArray columnHeaders = (JArray)json["Header"];
            List<string> columns = columnHeaders.Select(c => (string)c).ToList();

            InsertQuery command = new InsertQuery();
            var query = command.Generate(tableName, columns);

            AutoGenerateOrmClass ormClass = new AutoGenerateOrmClass();
            var type = ormClass.GenerateClass(tableName, columns);
            
            foreach (JObject obj in json["Rows"].Children<JObject>())
            {
                var myObject = JsonConvert.DeserializeObject(obj.ToString(), type);
                crudOperation.InsertQuery(myObject, query, connectionString);
            }

        }
    }
}
