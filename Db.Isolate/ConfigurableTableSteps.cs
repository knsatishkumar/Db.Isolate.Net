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
        
        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
        static DapperCrud crudOperation = new DapperCrud(connectionString);

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

      


        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            //ScenarioContext.Current.Pending();
        }



    }
}
