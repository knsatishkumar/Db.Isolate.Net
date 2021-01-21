using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Db.Isolate
{
    [Binding]
    public class ConfigurableTableSteps
    {
        static DapperCrud crudOperation = new DapperCrud();
        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;

        private ScenarioContext scenarioContext;
        IDatabaseExecutor databaseExecutor = new DatabaseExecutor();
        ITableConvertor entityConvertor = new SpecflowTableConvertor();

        [Given(@"multiple tests are stored in sql table ""(.*)""")]
        public void GivenMultipleTestsAreStoredInSqlTable(string p0)
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"triggered in sequence order")]
        public void WhenTriggeredInSequenceOrder()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"one row at a time in the sql table is executed sequentially")]
        public void ThenOneRowAtATimeInTheSqlTableIsExecutedSequentially()
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"Running using Transaction Rollback database test pattern")]
        public void GivenRunningUsingTransactionRollbackDatabaseTestPattern()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Call Rollback Database Step")]
        public void ThenCallRollbackDatabaseStep()
        {
            //ScenarioContext.Current.Pending();
        }


    }
}
