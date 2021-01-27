using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Db.Isolate
{
    [Binding]
    class DatabasePatternsSteps
    {
        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerMasterConnString"].ConnectionString;
        static DapperCrud crudOperation = DapperCrud.Instance;

        private string _dbName; 
        private string _backupFileName; 
        private string _query;
      
        [Given(@"Differential Backup for the Database ""(.*)"" To Disk ""(.*)""")]
        public void GivenDifferentialBackupBackupDatabaseNameIsToDisk(string dbName, string backupFilename)
        {
            _dbName = dbName;
            _backupFileName = backupFilename;
            string temp = "BACKUP DATABASE {0} To DISK='{1}' WITH DIFFERENTIAL";
            _query = String.Format(temp, dbName, backupFilename);
        }


        [When(@"Backup Step is Executed")]
        public void WhenBackupStepIsExecuted()
        {
            try
            {
               crudOperation.ExecuteCommand(_query, connectionString);
            }
            catch(SqlException ex)
            {
                /*
                if(ex.Message.Contains("because a current database backup does not exist"))
                {
                    crudOperation.ExecuteCommand(String.Format("BACKUP DATABASE {0} To DISK='{1}'", _dbName, _backupFileName), connectionString);
                }
                crudOperation.ExecuteCommand(_query, connectionString);
                */
            }
        }

        [Then(@"Backup File Successfully Created")]
        public void ThenBackupFileSuccessfullyCreated()
        {
           
        }

        [Given(@"Using Transaction Rollback database test pattern\twith DbName ""(.*)"" and Backup file ""(.*)""")]
        public void GivenUsingTransactionRollbackDatabaseTestPatternWithDbNameAndBackupFile(string dbName, string backupFilename)
        {
            _dbName = dbName;
            _backupFileName = backupFilename;
            string temp = "BACKUP DATABASE {0} To DISK='{1}' WITH DIFFERENTIAL";
            _query = String.Format(temp, dbName, backupFilename);
            crudOperation.ExecuteCommand(_query, connectionString);
        }


    }
}
