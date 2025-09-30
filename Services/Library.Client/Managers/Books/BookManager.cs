using Library.Client.Constants;
using Library.Client.Models;
using Library.Client.Models.Book;
using Library.Client.Repositories.Book;
using Serilog;
using System.Net;

namespace Library.Client.Managers.Books
{
    public class BookManager: IBookManager
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResponseResult<AddBookResponse>> AddBookAsync(AddBookRequest book)
        {
            try
            {
                // validation for user
                bool isValid = await _bookRepository.CheckIfValidLibrarian(book.AddedByUserId);
                if (!isValid)
                {
                    return new ResponseResult<AddBookResponse>
                    {
                        success = false,
                        status_code = (int)HttpStatusCode.Forbidden,
                        message = StaticMessages.NotValidLibrarian
                    };
                }

                var result = await _bookRepository.CreateBookAsync(book);

                if (result.success)
                    return result;

                return new ResponseResult<AddBookResponse>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.InternalServerError,
                    message = StaticMessages.SomethingWentWrong
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(AddBookAsync), ex.Message);
                throw;
            }
        }

        public async Task<ResponseResult<List<Book>>> GetBooksAsync(QueryParameters queryParameters)
        {
            try
            {
                var books = await _bookRepository.GetAllBooksAsync(queryParameters);
                var bookList = books.ToList();

                if (bookList.Count > 0)
                {
                    return new ResponseResult<List<Book>>
                    {
                        success = true,
                        status_code = (int)HttpStatusCode.OK,
                        result = bookList,
                        message = StaticMessages.BooksFound
                    };
                }

                return new ResponseResult<List<Book>>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.NotFound,
                    result = new List<Book>(),
                    message = StaticMessages.NoBooksFound
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(GetBooksAsync), ex.Message);
                throw;
            }
        }

        public async Task<ResponseResult<Book>> GetBookByIdAsync(int bookId)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(bookId);
                if (book != null)
                {
                    return new ResponseResult<Book>
                    {
                        success = true,
                        status_code = (int)HttpStatusCode.OK,
                        result = book,
                        message = StaticMessages.BookFound
                    };
                }

                return new ResponseResult<Book>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.NotFound,
                    message = StaticMessages.BookNotFound
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(GetBookByIdAsync), ex.Message);
                throw;
            }
        }

        public async Task<ResponseResult<bool>> DeleteBookAsync(int bookId, int deletedByUserId)
        {
            try
            {
                bool isValid = await _bookRepository.CheckIfValidLibrarian(deletedByUserId);
                if (!isValid)
                {
                    return new ResponseResult<bool>
                    {
                        success = false,
                        status_code = (int)HttpStatusCode.Forbidden,
                        message = StaticMessages.NotValidLibrarian
                    };
                }

                var deleted = await _bookRepository.DeleteBookAsync(bookId);

                if (deleted)
                    return new ResponseResult<bool>
                    {
                        success = true,
                        status_code = (int)HttpStatusCode.OK,
                        result = true,
                        message = StaticMessages.BookDeleted
                    };

                return new ResponseResult<bool>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.NotFound,
                    message = StaticMessages.BookNotFound
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(DeleteBookAsync), ex.Message);
                throw;
            }
        }
    }
}
