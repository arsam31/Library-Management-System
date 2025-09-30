using Library.Client.Models.Book;
using Library.Client.Models;

namespace Library.Client.Repositories.Book
{
    public interface IBookRepository
    {
        Task<ResponseResult<AddBookResponse>> CreateBookAsync(AddBookRequest book);
        Task<IEnumerable<Models.Book.Book>> GetAllBooksAsync(QueryParameters queryParameters);
        Task<Models.Book.Book?> GetBookByIdAsync(int bookId);
        Task<bool> DeleteBookAsync(int bookId);
        Task<bool> CheckIfValidLibrarian(int userId);
    }
}
