use testdb
go
CREATE TABLE Table_input (
    ID int NOT NULL,
    Name varchar(255) NOT NULL,
    Address varchar(255),
    isPermanentAddress bit,
	Date DateTime
    CONSTRAINT PK_Table_input PRIMARY KEY (ID)
);
