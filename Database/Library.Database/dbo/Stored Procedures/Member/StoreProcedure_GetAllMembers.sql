CREATE PROCEDURE [dbo].[StoredProcedure_GetAllMembers]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MemberId, Name, Email, IsLibrarian, CreatedDate
    FROM [dbo].[Members];
END
