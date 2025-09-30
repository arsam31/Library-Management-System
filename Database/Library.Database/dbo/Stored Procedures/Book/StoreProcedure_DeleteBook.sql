CREATE PROCEDURE [dbo].[StoreProcedure_DeleteBook]
    @BookId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[Books]
    WHERE BookId = @BookId;

    SELECT @@ROWCOUNT AS RowsAffected;
END