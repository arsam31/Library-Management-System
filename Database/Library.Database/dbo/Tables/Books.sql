CREATE TABLE [dbo].[Books] (
    [BookId] INT IDENTITY(1,1) PRIMARY KEY,
    [Title] NVARCHAR(200) NOT NULL,
    [Author] NVARCHAR(100) NOT NULL,
    [ISBN] NVARCHAR(20) UNIQUE NOT NULL,
    [PublishedDate] DATE NULL,
    [AddedByUserId] INT NOT NULL,
    [CreatedDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    CONSTRAINT FK_Books_Members FOREIGN KEY (AddedByUserId) REFERENCES [dbo].[Members](MemberId)
);