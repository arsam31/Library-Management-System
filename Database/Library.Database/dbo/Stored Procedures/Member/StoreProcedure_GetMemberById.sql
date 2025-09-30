CREATE PROCEDURE [dbo].[StoredProcedure_GetMemberById]
    @MemberId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MemberId, Name, Email, IsLibrarian, CreatedDate
    FROM [dbo].[Members]
    WHERE MemberId = @MemberId;
END
