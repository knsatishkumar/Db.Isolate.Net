Feature: StoredProcedure
	For testing stored procedure in a 
	isolated way
#
# Background: Simulating table truncation database test pattern
#	
#	

@mytag
Scenario: Execute stored procedure without parameters and returns table output
	Given Truncate table "Table_input"
	And table name "Table_input" with test data	
	| Id | Name   | Address   | isPermanentAddress  | Date       |
	| 1  | xyz | R.M Nagar | true | 2017-06-25T00:00:00 |
	| 2  | abc  | Electronic city | true | 2017-06-25T00:00:00|	
	When I execute stored procedure "sp_test"
	Then result is
	| id | name   | address   | isPermanentAddress  | date				   |
	| 1  | xyz | R.M Nagar | True | 2017-06-25T00:00:00 |
	| 2  | abc  | Electronic city | True | 2017-06-25T00:00:00 |
		

@mytag
Scenario: Execute stored procedure with input and output parameters
	Given Truncate table "Table_input"
	And Truncate table "Table_input1"
	And table name "Table_input" with test data	
	| Id | Name   | Address   | isPermanentAddress  | Date       |
	| 1  | xyz | R.M Nagar | true | 2017-06-25 |
	| 2  | abc  | R.M Nagar | true | 2017-06-25 |
	And table name "Table_input1" with test data	
	| Id | Name   | Address   | isPermanentAddress  | Date       |
	| 1  | xyz | R.M Nagar | true | 2017-06-25 |
	| 2  | abc  | R.M Nagar | true | 06-25-2017 |	
	When input parameters to stored procedure is
	| input1 | input2 | output1(out) | output2(out) |
	| val1   | 1      | val1         | 1            |
	And I execute stored procedure "sp_test_with_params" which returns output parameters	
	Then output parameters is as expected


@TransactionRollbackPattern 
Scenario: TransactionRollbackPattern Execute stored procedure
	#Given  Using Transaction Rollback database test pattern	with DbName "testdb" and Backup file "D:\Temp\DbBackup\testdb.bak"
	Given  Using Transaction Rollback database
	And table name "Table_input" with test data	
	| Id | Name   | Address   | isPermanentAddress  | Date       |
	| 3  | xyz | R.M Nagar | true | 2017-06-25T00:00:00 |
	| 4 | abc  | Electronic city | true | 2017-06-26T00:00:00|	
	When I execute stored procedure "sp_test"
	Then Table "Table_input" contains records with the field "Date" daterange between "2017-06-25" and "2017-06-26"
	Then Table "Table_input" contains records with the field "Id" number equals "3"
	Then Table "Table_input" contains records with the field "Name" string equals "xyz"
	Then Table "Table_input" contains records with the field "Id" number greater than "3"
	Then Table "Table_input" contains records with the field "Id" number greater than "1"
	Then Table "Table_input" contains records with the field "Id" number lesser than "5"
	Then Table "Table_input" contains records with the field "Id" number lesser than or equal to "5"
	Then Table "Table_input" contains records with the field "isPermanentAddress" boolean equals "true"
	Then Call Rollback Database Step
	
