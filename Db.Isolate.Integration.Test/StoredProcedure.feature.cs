﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Db.Isolate.Integration.Test
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class StoredProcedureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "StoredProcedure.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StoredProcedure", "\tFor testing stored procedure in a \r\n\tisolated way", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "StoredProcedure")))
            {
                global::Db.Isolate.Integration.Test.StoredProcedureFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute stored procedure without parameters and returns table output")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public virtual void ExecuteStoredProcedureWithoutParametersAndReturnsTableOutput()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute stored procedure without parameters and returns table output", new string[] {
                        "mytag"});
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("Truncate table \"Table_input\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table3.AddRow(new string[] {
                        "1",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25T00:00:00"});
            table3.AddRow(new string[] {
                        "2",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-25T00:00:00"});
#line 12
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table3, "And ");
#line 16
 testRunner.When("I execute stored procedure \"sp_test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "id",
                        "name",
                        "address",
                        "isPermanentAddress",
                        "date"});
            table4.AddRow(new string[] {
                        "1",
                        "xyz",
                        "R.M Nagar",
                        "True",
                        "2017-06-25T00:00:00"});
            table4.AddRow(new string[] {
                        "2",
                        "abc",
                        "Electronic city",
                        "True",
                        "2017-06-25T00:00:00"});
#line 17
 testRunner.Then("result is", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute stored procedure with input and output parameters")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public virtual void ExecuteStoredProcedureWithInputAndOutputParameters()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute stored procedure with input and output parameters", new string[] {
                        "mytag"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("Truncate table \"Table_input\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And("Truncate table \"Table_input1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table5.AddRow(new string[] {
                        "1",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25"});
            table5.AddRow(new string[] {
                        "2",
                        "abc",
                        "R.M Nagar",
                        "true",
                        "2017-06-25"});
#line 27
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table6.AddRow(new string[] {
                        "1",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25"});
            table6.AddRow(new string[] {
                        "2",
                        "abc",
                        "R.M Nagar",
                        "true",
                        "06-25-2017"});
#line 31
 testRunner.And("table name \"Table_input1\" with test data", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "input1",
                        "input2",
                        "output1(out)",
                        "output2(out)"});
            table7.AddRow(new string[] {
                        "val1",
                        "1",
                        "val1",
                        "1"});
#line 35
 testRunner.When("input parameters to stored procedure is", ((string)(null)), table7, "When ");
#line 38
 testRunner.And("I execute stored procedure \"sp_test_with_params\" which returns output parameters", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.Then("output parameters is as expected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TransactionRollbackPattern Execute stored procedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TransactionRollbackPattern")]
        public virtual void TransactionRollbackPatternExecuteStoredProcedure()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TransactionRollbackPattern Execute stored procedure", new string[] {
                        "TransactionRollbackPattern"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 45
 testRunner.Given("Using transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table8.AddRow(new string[] {
                        "3",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25T00:00:00"});
            table8.AddRow(new string[] {
                        "4",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-26T00:00:00"});
#line 46
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table8, "And ");
#line 50
 testRunner.When("I execute stored procedure \"sp_test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.Then("Table \"Table_input\" contains records with the field \"Date\" daterange between \"201" +
                    "7-06-25\" and \"2017-06-26\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.Then("Table \"Table_input\" contains records with the field \"Date\" date equals \"2017-06-2" +
                    "5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
 testRunner.And("Table \"Table_input\" contains records with the field \"Id\" number equals \"3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("Table \"Table_input\" contains records with the field \"Name\" string equals \"xyz\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("Table \"Table_input\" contains records with the field \"Id\" number greater than \"3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("Table \"Table_input\" contains records with the field \"Id\" number greater than \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("Table \"Table_input\" contains records with the field \"Id\" number lesser than \"5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("Table \"Table_input\" contains records with the field \"Id\" number lesser than or eq" +
                    "ual to \"5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("Table \"Table_input\" contains records with the field \"isPermanentAddress\" boolean " +
                    "equals \"True\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("Table \"Table_input\" contains records with the field \"Name\" is not null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("Table \"Table_input\" contains records with the field \"Name\" length is \"3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("End transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TransactionRollbackPattern With some prequiste data in the table")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TransactionRollbackPattern")]
        public virtual void TransactionRollbackPatternWithSomePrequisteDataInTheTable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TransactionRollbackPattern With some prequiste data in the table", new string[] {
                        "TransactionRollbackPattern"});
#line 66
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given("Using transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
 testRunner.And("Table \"Table_input\" contains records with the field \"Name\" string equals \"xyz\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.When("I execute stored procedure \"sp_test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.Then("Table \"Table_input\" contains records with the field \"Date\" date equals \"2017-06-2" +
                    "5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
 testRunner.And("Table \"Table_input\" contains records with the field \"Name\" is not null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And("End transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TransactionRollbackPattern With strored procedure having transactions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TransactionRollbackPattern")]
        public virtual void TransactionRollbackPatternWithStroredProcedureHavingTransactions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TransactionRollbackPattern With strored procedure having transactions", new string[] {
                        "TransactionRollbackPattern"});
#line 78
this.ScenarioSetup(scenarioInfo);
#line 80
 testRunner.Given("Using transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table9.AddRow(new string[] {
                        "3",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25T00:00:00"});
            table9.AddRow(new string[] {
                        "4",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-26T00:00:00"});
#line 81
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table9, "And ");
#line 85
 testRunner.When("I execute stored procedure \"sp_test_with_transaction\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
 testRunner.Then("End transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TransactionRollbackPattern Execute stored procedure for Length of Field")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TransactionRollbackPattern")]
        public virtual void TransactionRollbackPatternExecuteStoredProcedureForLengthOfField()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TransactionRollbackPattern Execute stored procedure for Length of Field", new string[] {
                        "TransactionRollbackPattern"});
#line 92
this.ScenarioSetup(scenarioInfo);
#line 94
 testRunner.Given("Using transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table10.AddRow(new string[] {
                        "3",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25T00:00:00"});
            table10.AddRow(new string[] {
                        "4",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-26T00:00:00"});
#line 95
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table10, "And ");
#line 100
 testRunner.And("Table \"Table_input\" contains records with the field \"Date\" date equals \"2017-06-2" +
                    "5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.When("I execute stored procedure \"sp_test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
 testRunner.Then("Table \"Table_input\" contains records with the field \"Name\" length is \"3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
 testRunner.And("End transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TransactionRollbackPattern Execute stored procedure for results containing all fi" +
            "elds")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TransactionRollbackPattern")]
        public virtual void TransactionRollbackPatternExecuteStoredProcedureForResultsContainingAllFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TransactionRollbackPattern Execute stored procedure for results containing all fi" +
                    "elds", new string[] {
                        "TransactionRollbackPattern"});
#line 107
this.ScenarioSetup(scenarioInfo);
#line 109
 testRunner.Given("Using transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table11.AddRow(new string[] {
                        "3",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25T00:00:00"});
            table11.AddRow(new string[] {
                        "4",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-25T00:00:00"});
            table11.AddRow(new string[] {
                        "5",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-26T00:00:00"});
#line 110
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table11, "And ");
#line 115
 testRunner.And("Table \"Table_input\" contains records with the field \"Date\" date equals \"2017-06-2" +
                    "5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.When("I execute stored procedure \"sp_test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Value"});
            table12.AddRow(new string[] {
                        "xyz"});
            table12.AddRow(new string[] {
                        "abc"});
#line 118
 testRunner.Then("Table \"Table_input\" contains records with the field \"Name\" contains all the value" +
                    "s", ((string)(null)), table12, "Then ");
#line 122
 testRunner.And("End transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TransactionRollbackPattern Execute stored procedure for results with columns valu" +
            "e is not null")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TransactionRollbackPattern")]
        public virtual void TransactionRollbackPatternExecuteStoredProcedureForResultsWithColumnsValueIsNotNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TransactionRollbackPattern Execute stored procedure for results with columns valu" +
                    "e is not null", new string[] {
                        "TransactionRollbackPattern"});
#line 129
this.ScenarioSetup(scenarioInfo);
#line 131
 testRunner.Given("Using transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table13.AddRow(new string[] {
                        "3",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25T00:00:00"});
            table13.AddRow(new string[] {
                        "4",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-25T00:00:00"});
            table13.AddRow(new string[] {
                        "5",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-26T00:00:00"});
#line 132
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table13, "And ");
#line 137
 testRunner.And("Table \"Table_input\" contains records with the field \"Date\" date equals \"2017-06-2" +
                    "5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
 testRunner.When("I execute stored procedure \"sp_test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 140
 testRunner.Then("Table \"Table_input\" contains records with the field \"Name\" is not null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
 testRunner.And("End transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TransactionRollbackPattern Execute stored procedure for results with minimum numb" +
            "er of rows")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TransactionRollbackPattern")]
        public virtual void TransactionRollbackPatternExecuteStoredProcedureForResultsWithMinimumNumberOfRows()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TransactionRollbackPattern Execute stored procedure for results with minimum numb" +
                    "er of rows", new string[] {
                        "TransactionRollbackPattern"});
#line 145
this.ScenarioSetup(scenarioInfo);
#line 147
 testRunner.Given("Using transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table14.AddRow(new string[] {
                        "3",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25T00:00:00"});
            table14.AddRow(new string[] {
                        "4",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-25T00:00:00"});
            table14.AddRow(new string[] {
                        "5",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-26T00:00:00"});
#line 148
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table14, "And ");
#line 153
 testRunner.And("Table \"Table_input\" contains records with the field \"Date\" date equals \"2017-06-2" +
                    "5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
 testRunner.When("I execute stored procedure \"sp_test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
 testRunner.Then("Result contains record count greater than \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
 testRunner.And("End transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("TransactionRollbackPattern Execute stored procedure for multi condition query")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TransactionRollbackPattern")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("NotImplemented")]
        public virtual void TransactionRollbackPatternExecuteStoredProcedureForMultiConditionQuery()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TransactionRollbackPattern Execute stored procedure for multi condition query", new string[] {
                        "TransactionRollbackPattern",
                        "NotImplemented"});
#line 162
this.ScenarioSetup(scenarioInfo);
#line 164
 testRunner.Given("Using transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table15.AddRow(new string[] {
                        "3",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25T00:00:00"});
            table15.AddRow(new string[] {
                        "4",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-26T00:00:00"});
#line 165
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table15, "And ");
#line 169
 testRunner.When("I execute stored procedure \"sp_test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Field",
                        "Condition",
                        "Value"});
            table16.AddRow(new string[] {
                        "Name",
                        "string equals",
                        "abc"});
            table16.AddRow(new string[] {
                        "Date",
                        "date equals",
                        "2017-06-25"});
            table16.AddRow(new string[] {
                        "Name",
                        "length equals",
                        "3"});
#line 170
 testRunner.Then("result consists of", ((string)(null)), table16, "Then ");
#line 175
 testRunner.And("End transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("contains few results among the list of values")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StoredProcedure")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("TransactionRollbackPattern")]
        public virtual void ContainsFewResultsAmongTheListOfValues()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("contains few results among the list of values", new string[] {
                        "TransactionRollbackPattern"});
#line 179
this.ScenarioSetup(scenarioInfo);
#line 181
 testRunner.Given("Using transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Address",
                        "isPermanentAddress",
                        "Date"});
            table17.AddRow(new string[] {
                        "3",
                        "xyz",
                        "R.M Nagar",
                        "true",
                        "2017-06-25T00:00:00"});
            table17.AddRow(new string[] {
                        "4",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-25T00:00:00"});
            table17.AddRow(new string[] {
                        "5",
                        "abc",
                        "Electronic city",
                        "true",
                        "2017-06-26T00:00:00"});
#line 182
 testRunner.And("table name \"Table_input\" with test data", ((string)(null)), table17, "And ");
#line 187
 testRunner.And("Table \"Table_input\" contains records with the field \"Date\" date equals \"2017-06-2" +
                    "5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 188
 testRunner.When("I execute stored procedure \"sp_test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Value"});
            table18.AddRow(new string[] {
                        "xyz"});
            table18.AddRow(new string[] {
                        "abc"});
#line 190
 testRunner.Then("Table \"Table_input\" contains records with the field \"Name\" among the list of valu" +
                    "es", ((string)(null)), table18, "Then ");
#line 194
 testRunner.And("End transaction rollback pattern", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
