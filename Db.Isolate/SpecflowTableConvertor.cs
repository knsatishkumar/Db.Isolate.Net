using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Db.Isolate
{
    public class SpecflowTableConvertor : ITableConvertor
    {
        public string ConvertToJson(Table table)
        {
            string result = "";
            result = Newtonsoft.Json.JsonConvert.SerializeObject(table);
            return result;
        }

        public object ConvertToObject(string tableName , string jsonTable)
        {   
            var type = Type.GetType(tableName);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(jsonTable, type);            
        }

        public string GetInParamJson(string tableJson)
        {
            return JObject.Parse(tableJson)["Rows"].ToList().FirstOrDefault().ToString();
            
        }

        public string GetOutParamJson(string tableJson)
        {
            var json = JObject.Parse(tableJson);
            JObject result = new JObject();
            foreach (var obj in json.Children<JToken>())
            {
                if (((Newtonsoft.Json.Linq.JProperty)obj).Name.Contains("(out)"))
                    result.Add(obj);
            }
            return result.ToString().Replace("\r\n", "")
                        .Replace("(out)", "");
        }
    }
}
