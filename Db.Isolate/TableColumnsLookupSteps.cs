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
    public class TableColumnsLookupSteps
    {
        DapperCrud crudOperation = DapperCrud.Instance;


        private ScenarioContext scenarioContext;
        IDatabaseExecutor databaseExecutor = new DatabaseExecutor();
        ITableConvertor entityConvertor = new SpecflowTableConvertor();

        List<string> _givenQueries = new List<string>();

        public TableColumnsLookupSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;

        }
        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" daterange between ""(.*)"" and ""(.*)""")]
        public void ThenTableContainsRecordsInTheFieldBetweenAnd(string tableName, string columnName, string date1, string date2)
        {
            DateTime FromDate = DateTime.ParseExact(date1, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime ToDate = DateTime.ParseExact(date2, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string query = String.Format("SELECT {1} FROM {0} WHERE {1}>='{2}' AND {1}<= '{3}' ", tableName , columnName , date1, date2  );
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" date equals ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldDateEquals(string tableName, string columnName, string value)
        {
            DateTime FromDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);           

            string query = String.Format("SELECT {1} FROM {0} WHERE {1}='{2}' ", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" date greater than ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldDateGreaterThan(string tableName, string columnName, string value)
        {
            DateTime FromDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string query = String.Format("SELECT {1} FROM {0} WHERE {1}>'{2}' ", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" date greater than or equal to""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldDateGreaterThanOrEqualTo(string tableName, string columnName, string value)
        {
            DateTime FromDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string query = String.Format("SELECT {1} FROM {0} WHERE {1}>='{2}' ", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" date lesser than or equal to""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldLesserThanOrEqualTo(string tableName, string columnName, string value)
        {
            DateTime FromDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string query = String.Format("SELECT {1} FROM {0} WHERE {1}<='{2}' ", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" date lesser than ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldDateLesserThan(string tableName, string columnName, string value)
        {
            DateTime FromDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string query = String.Format("SELECT {1} FROM {0} WHERE {1}<'{2}' ", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number equals ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberEquals(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}={2}", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }


        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" string equals ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldStringEquals(string tableName, string columnName, string value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}='{2}'", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number greater than ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberGreaterThan(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}>{2}", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number greater than or equal to ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberGreaterThanOrEqualTo(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}>={2}", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number lesser than ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberLesserThan(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}<{2}", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" number lesser than or equal to ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldNumberLesserThanOrEqualTo(string tableName, string columnName, int value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}<={2}", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" boolean equals ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldBooleanEquals(string tableName, string columnName, string value)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}='{2}'", tableName, columnName, bool.Parse(value)?'1':'0');
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" is not null")]
        public void ThenTableContainsRecordsWithTheFieldIsNotNull(string tableName, string columnName)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1} IS NOT NULL", tableName, columnName);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" is null")]
        public void ThenTableContainsRecordsWithTheFieldIsNull(string tableName, string columnName)
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1} IS NULL", tableName, columnName);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }


        [Given(@"Table ""(.*)"" contains records with the field ""(.*)"" string equals ""(.*)""")]
        public void GivenTableContainsRecordsWithTheFieldStringEquals(string tableName, string columnName, string value)        
        {
            string query = String.Format("SELECT {1} FROM {0} WHERE {1}='{2}'", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" length is ""(.*)""")]
        public void ThenTableContainsRecordsWithTheFieldLengthIs(string tableName, string columnName, int length)
        {
            string query = String.Format("SELECT LEN({1}) FROM {0}", tableName, columnName, length);
            string givenQueryFilter = "";
            if (_givenQueries.Count > 0 )
            {                
                for (int i = 0; i < _givenQueries.Count; i++)
                {
                    if(i==0)
                    {
                        givenQueryFilter = " WHERE " + _givenQueries[i];
                    }
                    else
                    {
                        givenQueryFilter = " AND " + _givenQueries[i];
                    }
                }
            }
            query = query + givenQueryFilter;
            var results = crudOperation.Query<int>(query);
            int negativeResult = results.Where(x => x != length).Count();
            string errorMessage = String.Format(" Expected length for the field '{0}' was '{1}', but contains '{2}' no. of records where length is NOT '{1}'", columnName, length, negativeResult, length);
            negativeResult.ShouldBeEqualTo(0 , errorMessage);
            _givenQueries.Clear();
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" contains all the values")]
        public void ThenTableContainsRecordsWithTheFieldContainsAllTheValues(string tableName, string columnName, Table table)
        {
            //table.Header.Count().ShouldBeEqualTo(1 , "This step expects only one column but the input contains " + table.Header.Count() + " columns ");
            //var List = table.CreateSet<string>;
            List<string> allValues = new List<string>();
            foreach (var item in table.Rows)
            {
                allValues.Add(item.Values.ToList().FirstOrDefault());
            }
            int length = 0;
            string query = String.Format("SELECT {1} FROM {0}", tableName, columnName, length);
            string givenQueryFilter = "";
            if (_givenQueries.Count > 0)
            {
                for (int i = 0; i < _givenQueries.Count; i++)
                {
                    if (i == 0)
                    {
                        givenQueryFilter = " WHERE " + _givenQueries[i];
                    }
                    else
                    {
                        givenQueryFilter = " AND " + _givenQueries[i];
                    }
                }
            }
            query = query + givenQueryFilter;
            var results = crudOperation.Query<string>(query);
            bool containsAll = allValues.All(x => results.Contains(x));
            containsAll.ShouldBeTrue();
            //int negativeResult = results.Where(x => x != length).Count();
            //string errorMessage = String.Format(" Expected length for the field '{0}' was '{1}', but contains '{2}' no. of records where length is NOT '{1}'", columnName, length, negativeResult, length);
            //negativeResult.ShouldBeEqualTo(0, errorMessage);
            _givenQueries.Clear();
        }

        [Then(@"result consists of")]
        public void ThenTableContainsRecordsWith(Table table)
        {
            if (this.scenarioContext.ContainsKey("results"))
            {
                var results = this.scenarioContext["results"];
                JArray jsonObject = JArray.Parse(results.ToString());                
                foreach (var item in table.Rows)
                {
                  
                }
            }
        }


        [Given(@"Table ""(.*)"" contains records with the field ""(.*)"" date equals ""(.*)""")]
        public void GivenTableContainsRecordsWithTheFieldDateEquals(string tableName, string columnName, string value)
        {
            DateTime FromDate = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string query = String.Format("SELECT {1} FROM {0} WHERE {1}='{2}' ", tableName, columnName, value);
            int results = crudOperation.QueryScalarResultCount(query);
            results.ShouldBeGreaterThan(0);
            _givenQueries.Add(String.Format(" {0}='{1}' ", columnName, value));
            if (this.scenarioContext.ContainsKey("_givenQueries"))
            {
                this.scenarioContext["_givenQueries"] = _givenQueries;
            }
            else
            {
                this.scenarioContext.Add("_givenQueries", _givenQueries);
            }
        }

        [Then(@"Result contains record count greater than ""(.*)""")]
        public void ThenResultContainsRecordCountGreaterThan(int rowCount)
        {     
            
            string resultJson = this.scenarioContext["results"].ToString();

            dynamic stuff = JArray.Parse(resultJson);
            int count = stuff.Count;
            count.ShouldBeGreaterThan(rowCount);
            
        }

        [Then(@"Table ""(.*)"" contains records with the field ""(.*)"" among the list of values")]
        public void ThenTableContainsRecordsWithTheFieldAmongTheListOfValues(string tableName, string columnName, Table table)
        {
            List<string> allValues = new List<string>();
            foreach (var item in table.Rows)
            {
                allValues.Add(item.Values.ToList().FirstOrDefault());
            }
            int length = 0;
            string query = String.Format("SELECT {1} FROM {0}", tableName, columnName, length);
            string givenQueryFilter = "";
            if (_givenQueries.Count > 0)
            {
                for (int i = 0; i < _givenQueries.Count; i++)
                {
                    if (i == 0)
                    {
                        givenQueryFilter = " WHERE " + _givenQueries[i];
                    }
                    else
                    {
                        givenQueryFilter = " AND " + _givenQueries[i];
                    }
                }
            }
            query = query + givenQueryFilter;
            var results = crudOperation.Query<string>(query);
            bool containsAll = allValues.Any(x => results.Contains(x));
            containsAll.ShouldBeTrue();        
            _givenQueries.Clear();
        }



    }
}
