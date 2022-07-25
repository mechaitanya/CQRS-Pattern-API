USE [CQRSDB]
GO

/****** Object:  StoredProcedure [dbo].[GetEmployeeData]    Script Date: 26-07-2022 00:33:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Chaitanya>
-- Create date: <25-07-2022>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GetEmployeeData] 
	-- Add the parameters for the stored procedure here
	@EmpID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT ( SELECT E.Id, e.EmpID, E.FirstName, E.LastName, ED.EmpAge, ED.Gender, ED.DOB 
		FROM Employee E 
		INNER JOIN EmployeeDetails ED
		ON e.EmpID = ED.EmpID 
		WHERE e.EmpID = @EmpID  or IsNull(@EmpID, 0) = 0 FOR JSON PATH ) as JsonResult

END
GO


