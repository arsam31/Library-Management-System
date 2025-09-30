CREATE PROCEDURE [dbo].[StoredProcedure_ReturnBook]
    @TransactionId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[LibraryTransactions]
    SET IsReturned = 1,
        ReturnDate = GETDATE()
    WHERE TransactionId = @TransactionId AND IsReturned = 0;

    SELECT @@ROWCOUNT AS RowsAffected;
END
