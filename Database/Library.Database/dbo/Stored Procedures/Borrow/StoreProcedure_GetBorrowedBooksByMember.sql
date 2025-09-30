CREATE PROCEDURE [dbo].[StoredProcedure_GetBorrowedBooksByMember]
    @MemberId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT T.TransactionId,
           B.BookId,
           B.Title,
           B.Author,
           T.BorrowDate,
           T.ReturnDate,
           T.IsReturned
    FROM [dbo].[LibraryTransactions] T
    INNER JOIN [dbo].[Books] B ON T.BookId = B.BookId
    WHERE T.MemberId = @MemberId;
END
