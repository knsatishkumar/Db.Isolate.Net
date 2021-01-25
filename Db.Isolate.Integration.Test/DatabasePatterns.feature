Feature: DatabasePatterns
	Implementation of Database patterns

@mytag
Scenario: Database backup restore pattern 
	Given Differential Backup for the Database "testdb" To Disk "D:\Temp\DbBackup\testdb.bak" 
	When Backup Step is Executed
	Then Backup File Successfully Created 
	