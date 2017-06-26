using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Isolate
{
    public interface IDatabaseExecutor
    {
        void SetTableData(string tableName, string tableJson);
        string ExecuteStoredProcedure(string procedureName);
        string ExecuteStoredProcedure(string procedureName, string inParamJson);
        void ExecuteCommand(string query);
    }
}
