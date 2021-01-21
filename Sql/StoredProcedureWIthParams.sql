CREATE PROC sp_test_with_params
  @input1 VARCHAR(255),
  @input2 INT,
  @output1 VARCHAR(255) OUT,
  @output2 INT OUT
AS
SET @output1 = 'val1'
SET @output2 = 1
