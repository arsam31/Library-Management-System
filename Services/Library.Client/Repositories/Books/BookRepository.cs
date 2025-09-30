using Dapper;
using Library.Client.Models.Book;
using Library.Client.Models;
using Serilog;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using Library.Client.Constants;
using Library.Client.Repositories.Book;

namespace Library.Client.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _configuration;

        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString(SystemConstants.DefaultConnection);
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException(StaticMessages.DatabaseNotConfigured);

            return new SqlConnection(connectionString);
        }

        public async Task<ResponseResult<AddBookResponse>> CreateBookAsync(AddBookRequest book)
        {
            try
            {
                using var connection = CreateConnection();
                await connection.OpenAsync();

                var parameters = new DynamicParameters();
                parameters.Add("@ISBN", book.ISBN);
                parameters.Add("@Title", book.Title);
                parameters.Add("@Author", book.Author);
                parameters.Add("@AddedBy", book.AddedByUserId);
                parameters.Add("@BookId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync(SystemConstants.StoreProcedure_AddBook, parameters, commandType: CommandType.StoredProcedure);

                int? newId = parameters.Get<int?>("@BookId");

                if (newId.HasValue)
                {
                    return new ResponseResult<AddBookResponse>
                    {
                        success = true,
                        status_code = (int)HttpStatusCode.OK,
                        result = new AddBookResponse { BookId = newId.Value, Title = book.Title },
                        message = StaticMessages.BookAdded
                    };
                }

                return new ResponseResult<AddBookResponse>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.InternalServerError,
                    message = StaticMessages.BookInsertionFailed
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(CreateBookAsync), ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Models.Book.Book>> GetAllBooksAsync(QueryParameters queryParameters)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();

            var parameters = new
            {
                Filter = queryParameters.filter,
                SortBy = queryParameters.sortBy,
                SortDescending = queryParameters.sortDescending,
                PageNumber = queryParameters.pageNumber,
                PageSize = queryParameters.pageSize
            };

            var books = await connection.QueryAsync<Models.Book.Book>(SystemConstants.StoreProcedure_GetAllBooks, parameters, commandType: CommandType.StoredProcedure);
            return books;
        }

        public async Task<Models.Book.Book?> GetBookByIdAsync(int bookId)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();

            var parameters = new { BookId = bookId };
            return await connection.QueryFirstOrDefaultAsync<Models.Book.Book>(SystemConstants.StoreProcedure_GetBookById, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();

            var parameters = new { BookId = bookId };
            var rows = await connection.ExecuteAsync(SystemConstants.StoreProcedure_DeleteBook, parameters, commandType: CommandType.StoredProcedure);
            return rows > 0;
        }

        public async Task<bool> CheckIfValidLibrarian(int userId)
        {
            using var connection = CreateConnection();
            await connection.OpenAsync();

            var parameters = new { userId };
            var result = await connection.QueryFirstOrDefaultAsync<int>(SystemConstants.StoredProcedure_CheckIfValidLibrarian, parameters, commandType: CommandType.StoredProcedure);
            return result == 1;
        }
    }
}
