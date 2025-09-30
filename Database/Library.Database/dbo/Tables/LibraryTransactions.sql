CREATE TABLE [dbo].[LibraryTransactions] (
    [TransactionId] INT IDENTITY(1,1) PRIMARY KEY,
    [BookId] INT NOT NULL,
    [MemberId] INT NOT NULL,
    [BorrowDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [ReturnDate] DATETIME NULL,
    [IsReturned] BIT NOT NULL DEFAULT(0),
    CONSTRAINT FK_LibraryTransactions_Books FOREIGN KEY (BookId) REFERENCES [dbo].[Books](BookId),
    CONSTRAINT FK_LibraryTransactions_Members FOREIGN KEY (MemberId) REFERENCES [dbo].[Members](MemberId)
);
