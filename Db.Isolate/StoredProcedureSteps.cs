using Db.Isolate;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using FluentAssert;

namespace Db.Isolate
{
    [Binding]
    public class StoredProcedureSteps
    {
        private ScenarioContext scenarioContext; 
        IDatabaseExecutor databaseExecutor = new DatabaseExecutor();
        ITableConvertor entityConvertor = new SpecflowTableConvertor();

        public StoredProcedureSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;

        }
        [Given(@"table name ""(.*)"" with test data")]
        public void GivenTableNameWithData(string tableName, Table table)
        {
            string tableJson = ConvertToJson(table);
            databaseExecutor.SetTableData(tableName, tableJson);
        }

        private string ConvertToJson(Table table)
        {
            return entityConvertor.ConvertToJson(table);
        }

        [Given(@"Truncate table ""(.*)""")]
        public void GivenTruncateTable(string tableName)
        {
            databaseExecutor.ExecuteCommand(String.Format("TRUNCATE TABLE {0}" , tableName));
        }

        [When(@"I execute stored procedure ""(.*)""")]
        public void WhenIExecuteStoredProcedure(string procedureName)
        {
            var results = databaseExecutor.ExecuteStoredProcedure(procedureName);
            this.scenarioContext.Add("results" ,  results);
        }
        
        [Then(@"result is")]
        public void ThenResultIs(Table table)
        {
            var tableJson = JObject.Parse(JsonConvert.SerializeObject(table))["Rows"];
            var results = (string)this.scenarioContext["results"];
            var resultJson =  JToken.Parse(results);
            tableJson.ToString().ShouldBeEqualTo(resultJson.ToString());
        }
        
        [When(@"I execute stored procedure ""(.*)"" which returns output parameters")]
        public void WhenIExecuteStoredProcedureWhichReturnsOutputParameters(string procedureName)
        {
            string inParamJson = this.scenarioContext["inputParameters"].ToString();
            var results = databaseExecutor.ExecuteStoredProcedure(procedureName , inParamJson);
            this.scenarioContext.Add ("results" ,results);
        }

        [When(@"input parameters to stored procedure is")]
        public void WhenInputParameters(Table table)
        {
            string tableJson = ConvertToJson(table);            
            string inputJson = entityConvertor.GetInParamJson(tableJson);
            this.scenarioContext.Add("inputParameters" ,  inputJson);
        }

        //[When(@"output parameters")]
        //public void WhenOutputParameters(Table table)
        //{
            
        //}
        [Then(@"resulting output parameters is")]
        public void ThenResultingOutputParametersIs(Table table)
        {
            
        }

        [Then(@"output parameters is as expected")]
        public void ThenOutputParametersIsAsExpected()
        {
            string inputJson = this.scenarioContext["inputParameters"].ToString();
            string expectedJson = entityConvertor.GetOutParamJson(inputJson);
            string resultJson = this.scenarioContext["results"].ToString();
            resultJson.ShouldBeEqualTo(expectedJson);
        }
    }
}
