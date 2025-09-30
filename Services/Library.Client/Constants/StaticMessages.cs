namespace Library.Client.Constants
{
    public class StaticMessages
    {
        // General messages
        public const string NotFound = "The requested resource was not found.";
        public const string BadRequest = "Bad Request.";
        public const string NotImplemented = "Not Implemented.";

        // User messages
        public const string UserCreated = "User has been created successfully.";
        public const string TokenCreated = "Token has been generated successfully.";
        public const string InValidUserId = "User ID cannot be zero.";

        public const string NotValidLibrarian = "The user is not a valid librarian.";
        public const string SomethingWentWrong = "Something went wrong while processing your request.";
        public const string ExceptionOccured = "An exception occurred in method {0}: {1}";

        // Books related messages
        public const string BooksFound = "Books retrieved successfully.";
        public const string NoBooksFound = "No books were found.";
        public const string BookFound = "Book retrieved successfully.";
        public const string BookNotFound = "Book not found.";
        public const string BookDeleted = "Book deleted successfully.";

        // Book specific
        public const string BookAdded = "Book has been successfully added.";
        public const string BookInsertionFailed = "Book insertion failed.";
        public const string SuggestionsFound = "Suggestions retrieved successfully.";
        public const string NoSuggestionsFound = "No suggestions found.";
        public const string DatabaseNotConfigured = "Database connection string is not configured.";

        // Library-related messages
        public const string BookBorrowed = "Book borrowed successfully.";
        public const string BookAlreadyBorrowed = "Book is already borrowed by another member.";
        public const string BookReturned = "Book returned successfully.";
        public const string TransactionNotFound = "Transaction not found.";
        public const string BorrowedBooksFound = "Borrowed books retrieved successfully.";
        public const string NoBorrowedBooksFound = "No borrowed books were found.";

        // Members related messages
        public const string MemberAdded = "Member added successfully.";
        public const string MembersFound = "Members retrieved successfully.";
        public const string NoMembersFound = "No members were found.";
        public const string MemberFound = "Member retrieved successfully.";
        public const string MemberNotFound = "Member not found.";
        public const string MemberDeleted = "Member deleted successfully.";

        // Search suggesstion messages
        public const string SuggesstionsFound = "Search suggesstions found.";
        public const string NoSuggesstionsFound = "No Search suggesstions Found.";

        // Error messages
        public const string InvalidInput = "The input provided is invalid.";
        public const string UnauthorizedAccess = "You do not have permission to access this resource.";
        public const string ServerTimeOut = "Server timeout occurs due to a slow client request.";
        public const string UnexpectedError = "An unexpected error occurred. Please contact support.";
        public const string InternalServerError = "Internal Server Error.";
        public const string IncorrectPassword = "The entered password is incorrect.";
        public const string UserNotExist = "User with this email does not exist.";
        public const string UserAlreadyExist = "User with this email already exist.";
        public const string ClientInsertionFailed = "Failed to add new client. Please try again.";

        // Validation messages
        public const string EmailRequired = "Email address is required.";
        public const string PasswordRequired = "Password is required.";
        public const string InvalidEmailFormat = "The email address format is invalid.";

        // Exception message
        public const string GlobalExceptionOccured = "Hello! An Unhandled exception occurred: {title}, statuscode: {statuscode}, type: {type}, detail: {detail}, instance: {instance}";

        // Database Error
        public const string DatabaseErrorOccured = "A database error occurred. Please try again later.";
    }

}
