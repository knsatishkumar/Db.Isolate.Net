using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Db.Isolate
{
    public interface ITableConvertor
    {
        string ConvertToJson(Table table);
        string GetInParamJson(string tableJson);
        string GetOutParamJson(string tableJson);
    }
}
