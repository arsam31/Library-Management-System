CREATE PROCEDURE [dbo].[StoredProcedure_BorrowBook]
    @BookId INT,
    @MemberId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if already borrowed and not returned
    IF EXISTS (
        SELECT 1 FROM [dbo].[LibraryTransactions]
        WHERE BookId = @BookId AND IsReturned = 0
    )
    BEGIN
        SELECT -1 AS ErrorCode; -- Book already borrowed
        RETURN;
    END

    INSERT INTO [dbo].[LibraryTransactions] (BookId, MemberId)
    VALUES (@BookId, @MemberId);

    SELECT SCOPE_IDENTITY() AS TransactionId;
END
