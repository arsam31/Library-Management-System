using Library.Client.Models.Library;

namespace Library.Client.Repositories.Library
{
    public interface ILibraryRepository
    {
        Task<ResponseResult<BorrowBookResponse>> BorrowBookAsync(BorrowBookRequest request);
        Task<ResponseResult<bool>> ReturnBookAsync(int transactionId);
        Task<IEnumerable<LibraryTransaction>> GetBorrowedBooksByMemberAsync(int memberId);
    }
}
