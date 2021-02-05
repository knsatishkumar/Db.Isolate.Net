Feature: Execute SQL Queries 
	Simple Query to check odd or even

@working
Scenario: Sql Query for Odd day or Even Day
	When query "SELECT CASE WHEN datepart(day, GETDATE()) % 2 = 1 THEN 'ODD'  WHEN datepart(day, GETDATE()) % 2 = 0 THEN 'EVEN' END as oddoreven" returns multiple records
	Then result is
	| oddoreven |
	|   ODD     |
	#Then result consists of  	
	#| Field | Condition			 | Value      |
	#| oddoreven  | string equals | ODD        |	

@mytag
Scenario: Select 1 sql query
	Given sql single query "SELECT 1"	
	When query is executed for scalar int result
	Then query result is "1"

@mytag
Scenario: Select 0 sql query
	Given sql single query "SELECT 0"	
	When query is executed for scalar int result 
	Then query result is "0"

@mytag
Scenario: Select Text sql query
	Given sql single query "SELECT 'Hello'"	
	When query is executed for scalar string result 
	Then query result is "Hello"


@notimplemented
Scenario: Sql Query for Odd day or Even Day result with filter
	When query "SELECT CASE WHEN datepart(day, GETDATE()) % 2 = 1 THEN 'ODD'  WHEN datepart(day, GETDATE()) % 2 = 0 THEN 'EVEN' END as oddoreven" returns multiple records
	Then result consists of  	
	| Field | Condition			 | Value      |
	| oddoreven  | string equals | ODD        |