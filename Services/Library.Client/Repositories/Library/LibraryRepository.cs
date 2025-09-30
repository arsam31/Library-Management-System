using Library.Client.Constants;
using Library.Client.Models.Library;
using System.Data;
using System.Data.SqlClient;

namespace Library.Client.Repositories.Library
{
    public class LibraryRepository: ILibraryRepository
    {
        private readonly string _connectionString;

        public LibraryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ResponseResult<BorrowBookResponse>> BorrowBookAsync(BorrowBookRequest request)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("StoredProcedure_BorrowBook", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@BookId", request.BookId);
            command.Parameters.AddWithValue("@MemberId", request.MemberId);

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();

            if (Convert.ToInt32(result) == -1)
            {
                return new ResponseResult<BorrowBookResponse>
                {
                    success = false,
                    status_code = 400,
                    message = StaticMessages.BookAlreadyBorrowed
                };
            }

            return new ResponseResult<BorrowBookResponse>
            {
                success = true,
                status_code = 200,
                result = new BorrowBookResponse { TransactionId = Convert.ToInt32(result) },
                message = StaticMessages.BookBorrowed
            };
        }

        public async Task<ResponseResult<bool>> ReturnBookAsync(int transactionId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("StoredProcedure_ReturnBook", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TransactionId", transactionId);

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();

            return new ResponseResult<bool>
            {
                success = Convert.ToInt32(result) > 0,
                status_code = Convert.ToInt32(result) > 0 ? 200 : 404,
                result = Convert.ToInt32(result) > 0,
                message = Convert.ToInt32(result) > 0 ? StaticMessages.BookReturned : StaticMessages.TransactionNotFound
            };
        }

        public async Task<IEnumerable<LibraryTransaction>> GetBorrowedBooksByMemberAsync(int memberId)
        {
            var transactions = new List<LibraryTransaction>();
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("StoredProcedure_GetBorrowedBooksByMember", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@MemberId", memberId);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                transactions.Add(new LibraryTransaction
                {
                    TransactionId = reader.GetInt32(0),
                    BookId = reader.GetInt32(1),
                    BorrowDate = reader.GetDateTime(4),
                    ReturnDate = reader.IsDBNull(5) ? null : reader.GetDateTime(5),
                    IsReturned = reader.GetBoolean(6)
                });
            }
            return transactions;
        }
    }
}
