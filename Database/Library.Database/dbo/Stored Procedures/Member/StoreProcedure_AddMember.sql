CREATE PROCEDURE [dbo].[StoredProcedure_AddMember]
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @IsLibrarian BIT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Members] (Name, Email, IsLibrarian)
    VALUES (@Name, @Email, @IsLibrarian);

    SELECT SCOPE_IDENTITY() AS NewMemberId;
END
