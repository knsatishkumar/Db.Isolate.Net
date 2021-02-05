using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FluentAssert;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace Db.Isolate
{
    [Binding]
    public class SqlQuerySteps
    {
        DapperCrud crudOperation = DapperCrud.Instance;

        private ScenarioContext scenarioContext;
        IDatabaseExecutor databaseExecutor = new DatabaseExecutor();
        ITableConvertor entityConvertor = new SpecflowTableConvertor();

        List<string> _givenQueries = new List<string>();

        public SqlQuerySteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"sql single query ""(.*)""")]
        public void GivenSqlQuery(string sqlQuery)
        {
            if (_givenQueries.Count == 0)
            {
                _givenQueries.Add(sqlQuery);
            }
            var result = _givenQueries.Count();
            result.ShouldBeEqualTo(1, "Cannot Execute Multiple queries");
        }

        [When(@"query is executed for scalar int result")]
        public void WhenQueryIsExecutedScalarIntResult()
        {
            var singleIntQueryResults = crudOperation.QueryScalarIntResult(_givenQueries.FirstOrDefault());
            if (this.scenarioContext.ContainsKey("singleQueryResults"))
            {
                this.scenarioContext["singleIntQueryResults"] = singleIntQueryResults;
            }
            else
            {
                this.scenarioContext.Add("singleIntQueryResults", singleIntQueryResults);
            }
            _givenQueries.Clear();
        }

        [When(@"query is executed for scalar string result")]
        public void WhenQueryIsExecutedScalarStringResult()
        {
            var singleStringQueryResults = crudOperation.QueryScalarStringResult(_givenQueries.FirstOrDefault());
            if (this.scenarioContext.ContainsKey("singleStringQueryResults"))
            {
                this.scenarioContext["singleStringQueryResults"] = singleStringQueryResults;
            }
            else
            {
                this.scenarioContext.Add("singleStringQueryResults", singleStringQueryResults);
            }
            _givenQueries.Clear();
        }

      
        [When(@"query ""(.*)"" returns multiple records")]
        public void WhenQueryReturnsMultipleRecords(string query)
        {
            var results = crudOperation.Query(query);
            if (this.scenarioContext.ContainsKey("results"))
            {
                this.scenarioContext["results"] = results;
            }
            else
            {
                this.scenarioContext.Add("results", results);
            }
        }


        [Then(@"query result is ""(.*)""")]
        public void ThenQueryResultIs(string result)
        {
            if (this.scenarioContext.ContainsKey("singleQueryResults"))
            {
                var actual = this.scenarioContext["singleQueryResults"].ToString();                
                result.ToString().ShouldBeEqualTo(actual);
            }
        }

    }
}
