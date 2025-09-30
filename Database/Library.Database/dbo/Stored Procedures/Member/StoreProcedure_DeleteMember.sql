CREATE PROCEDURE [dbo].[StoredProcedure_DeleteMember]
    @MemberId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[Members]
    WHERE MemberId = @MemberId;

    SELECT @@ROWCOUNT AS RowsAffected;
END
