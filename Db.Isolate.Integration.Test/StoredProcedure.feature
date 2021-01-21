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
	
