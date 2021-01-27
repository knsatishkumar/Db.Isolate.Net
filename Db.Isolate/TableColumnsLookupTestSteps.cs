using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FluentAssert;
using System.Globalization;

namespace Db.Isolate
{
    [Binding]
    public class TableColumnsLookupTestSteps
    {
        DapperCrud crudOperation = DapperCrud.Instance;


        private ScenarioContext scenarioContext;
        IDatabaseExecutor databaseExecutor = new DatabaseExecutor();
        ITableConvertor entityConvertor = new SpecflowTableConvertor();

        public TableColumnsLookupTestSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;

        }
        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" daterange between ""(.*)"" and ""(.*)""")]
        public void ThenTableContainsRecordsInTheFieldBetweenAnd(string tableName, string columnName, string date1, string date2)
        {
            DateTime FromDate = DateTime.ParseExact(date1, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime ToDate = DateTime.ParseExact(date2, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string query = String.Format("SELECT {1} FROM {0} WHERE {1}>='{2}' AND {1}<= '{3}' ", tableName , columnName , date1, date2  );
            int results = crudOperation.QueryScalar(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number equals ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberEquals(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}={2}", tableName, columnName, value);
            int results = crudOperation.QueryScalar(query);
            results.ShouldBeGreaterThan(0);
        }


        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" string equals ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldStringEquals(string tableName, string columnName, string value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}='{2}'", tableName, columnName, value);
            int results = crudOperation.QueryScalar(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number greater than ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberGreaterThan(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}>{2}", tableName, columnName, value);
            int results = crudOperation.QueryScalar(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number greater than or equal to ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberGreaterThanOrEqualTo(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}>={2}", tableName, columnName, value);
            int results = crudOperation.QueryScalar(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number lesser than ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberLesserThan(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}<{2}", tableName, columnName, value);
            int results = crudOperation.QueryScalar(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number lesser than or equal to ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberLesserThanOrEqualTo(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}<={2}", tableName, columnName, value);
            int results = crudOperation.QueryScalar(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" boolean equals ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldBooleanEquals(string tableName, string columnName, string value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}='{2}'", tableName, columnName, bool.Parse(value)?'1':'0');
            int results = crudOperation.QueryScalar(query);
            results.ShouldBeGreaterThan(0);
        }




    }
}
