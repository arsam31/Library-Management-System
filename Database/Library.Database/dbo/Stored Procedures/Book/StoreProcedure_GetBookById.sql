CREATE PROCEDURE [dbo].[StoreProcedure_GetBookById]
    @BookId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT B.BookId,
           B.Title,
           B.Author,
           B.ISBN,
           B.PublishedDate,
           B.AddedByUserId,
           M.Name AS AddedByName,
           B.CreatedDate
    FROM [dbo].[Books] B
    INNER JOIN [dbo].[Members] M ON B.AddedByUserId = M.MemberId
    WHERE B.BookId = @BookId;
END