USE [testdb]
GO
/****** Object:  StoredProcedure [dbo].[sp_test_with_transaction]    Script Date: 1/27/2021 5:15:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_test_with_transaction]
AS
BEGIN
	BEGIN TRAN
		INSERT INTO Table_Input
		SELECT 7,'xyz','R.M Nagar','1','2017-06-25'

	COMMIT 
END
