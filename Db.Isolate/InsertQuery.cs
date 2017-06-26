using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Isolate
{
    public class InsertQuery
    {
        public string Generate(string TableName , List<string> ColumnNames)
        {
            string Result = "INSERT INTO {0} ({1}) VALUES ({2})";
            string names = string.Empty;
            string values= string.Empty ;
            foreach (var item in ColumnNames)
            {
                if(String.IsNullOrEmpty( names))
                    names = String.Concat(item);
                else
                    names = String.Concat(names, "," + item);
                if (String.IsNullOrEmpty(values))
                    values = String.Concat("@" + item);
                else
                    values = String.Concat(values, ",@" + item);
            }
            return String.Format(Result , TableName , names , values);
        }
    }
}
