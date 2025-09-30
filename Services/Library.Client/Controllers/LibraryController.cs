using Library.Client.Managers.Library;
using Library.Client.Models.Library;
using Microsoft.AspNetCore.Mvc;

namespace Library.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryManager _libraryManager;

        public LibraryController(ILibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowBookRequest request)
        {
            var result = await _libraryManager.BorrowBookAsync(request);
            return StatusCode(result.status_code, result);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnBookRequest request)
        {
            var result = await _libraryManager.ReturnBookAsync(request.TransactionId);
            return StatusCode(result.status_code, result);
        }

        [HttpGet("member/{memberId}")]
        public async Task<IActionResult> GetBorrowedBooksByMember(int memberId)
        {
            var result = await _libraryManager.GetBorrowedBooksByMemberAsync(memberId);
            return StatusCode(result.status_code, result);
        }
    }
}
