Feature: ConfigurableTestsInSqlTable
	These tests are configured in a Table
	can be enabled and disabled using flag in the table
#
#  Simulating Transaction Rollback database test pattern
#

@mytag
Scenario: Execute tests from Table in Sequence
	Given Running using Transaction Rollback database test pattern
	And multiple tests are stored in sql table "ConfigTests"		
	When triggered in sequence order
	Then one row at a time in the sql table is executed sequentially
	And Call Rollback Database Step
	