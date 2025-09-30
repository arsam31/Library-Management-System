CREATE PROCEDURE [dbo].[StoredProcedure_CheckIfValidLibrarian]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT CASE WHEN EXISTS (
        SELECT 1 FROM [dbo].[Members] WHERE MemberId = @UserId AND IsLibrarian = 1
    ) THEN 1 ELSE 0 END AS IsValidLibrarian;
END