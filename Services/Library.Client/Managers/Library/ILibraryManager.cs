using Library.Client.Models.Library;

namespace Library.Client.Managers.Library
{
    public interface ILibraryManager
    {
        Task<ResponseResult<BorrowBookResponse>> BorrowBookAsync(BorrowBookRequest request);
        Task<ResponseResult<bool>> ReturnBookAsync(int transactionId);
        Task<ResponseResult<List<LibraryTransaction>>> GetBorrowedBooksByMemberAsync(int memberId);
    }
}
