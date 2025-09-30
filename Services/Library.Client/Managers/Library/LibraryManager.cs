using Library.Client.Constants;
using Library.Client.Models.Library;
using Library.Client.Repositories.Library;
using Serilog;
using System.Net;

namespace Library.Client.Managers.Library
{
    public class LibraryManager: ILibraryManager
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryManager(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<ResponseResult<BorrowBookResponse>> BorrowBookAsync(BorrowBookRequest request)
        {
            try
            {
                return await _libraryRepository.BorrowBookAsync(request);
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(BorrowBookAsync), ex.Message);
                throw;
            }
        }

        public async Task<ResponseResult<bool>> ReturnBookAsync(int transactionId)
        {
            try
            {
                return await _libraryRepository.ReturnBookAsync(transactionId);
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(ReturnBookAsync), ex.Message);
                throw;
            }
        }

        public async Task<ResponseResult<List<LibraryTransaction>>> GetBorrowedBooksByMemberAsync(int memberId)
        {
            try
            {
                var transactions = await _libraryRepository.GetBorrowedBooksByMemberAsync(memberId);
                var transactionList = transactions.ToList();

                if (transactionList.Count > 0)
                {
                    return new ResponseResult<List<LibraryTransaction>>
                    {
                        success = true,
                        status_code = (int)HttpStatusCode.OK,
                        result = transactionList,
                        message = StaticMessages.BorrowedBooksFound
                    };
                }

                return new ResponseResult<List<LibraryTransaction>>
                {
                    success = false,
                    status_code = (int)HttpStatusCode.NotFound,
                    result = new List<LibraryTransaction>(),
                    message = StaticMessages.NoBorrowedBooksFound
                };
            }
            catch (Exception ex)
            {
                Log.Error(StaticMessages.ExceptionOccured, nameof(GetBorrowedBooksByMemberAsync), ex.Message);
                throw;
            }
        }
    }
}
