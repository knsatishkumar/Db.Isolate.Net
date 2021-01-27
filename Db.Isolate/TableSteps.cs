using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Db.Isolate
{
    [Binding]
    public class TableSteps
    {
        DapperCrud crudOperation = DapperCrud.Instance;

        private ScenarioContext scenarioContext;
        IDatabaseExecutor databaseExecutor = new DatabaseExecutor();
        ITableConvertor entityConvertor = new SpecflowTableConvertor();

        public TableSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }       

    }
}
