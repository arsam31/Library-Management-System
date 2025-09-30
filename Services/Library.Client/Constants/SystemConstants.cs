namespace Library.Client.Constants
{
    public class SystemConstants
    {
        public const string JwtTokenPath = "AppSettings:Token";
        public const string DefaultConnection = "DefaultConnection";

        //Store Procedure constants for books
        public const string StoreProcedure_AddBook = "sp_storeProcedure_AddBook";
        public const string StoreProcedure_GetAllBooks = "sp_storeProcedure_GetAllBooks";
        public const string StoreProcedure_GetBookById = "sp_storeProcedure_GetBookById";
        public const string StoreProcedure_DeleteBook = "sp_storeProcedure_DeleteBook";
        public const string StoredProcedure_CheckIfValidLibrarian = "sp_storedProcedure_CheckIfValidLibrarian";
        public const string StoredProcedure_LogSearchFilters = "sp_storedProcedure_LogSearchFilters";
        public const string StoredProcedure_CheckIfValidAdmin = "sp_storedProcedure_CheckIfValidAdmin";
    }
}
