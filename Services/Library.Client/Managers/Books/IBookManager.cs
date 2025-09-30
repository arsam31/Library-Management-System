using Library.Client.Models.Book;
using Library.Client.Models;

namespace Library.Client.Managers.Books
{
    public interface IBookManager
    {
        Task<ResponseResult<AddBookResponse>> AddBookAsync(AddBookRequest book);
        Task<ResponseResult<List<Book>>> GetBooksAsync(QueryParameters queryParameters);
        Task<ResponseResult<Book>> GetBookByIdAsync(int bookId);
        Task<ResponseResult<bool>> DeleteBookAsync(int bookId, int deletedByUserId);
    }
}
