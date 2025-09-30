CREATE PROCEDURE [dbo].[StoreProcedure_AddBook]
    @Title NVARCHAR(200),
    @Author NVARCHAR(100),
    @ISBN NVARCHAR(20),
    @PublishedDate DATE,
    @AddedByUserId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Books] (Title, Author, ISBN, PublishedDate, AddedByUserId)
    VALUES (@Title, @Author, @ISBN, @PublishedDate, @AddedByUserId);

    SELECT SCOPE_IDENTITY() AS NewBookId;
END