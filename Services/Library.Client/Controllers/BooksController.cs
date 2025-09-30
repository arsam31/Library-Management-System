using Library.Client.Managers.Books;
using Library.Client.Models.Book;
using Library.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Client.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] AddBookRequest request)
        {
            var result = await _bookManager.AddBookAsync(request);
            return StatusCode(result.status_code, result);
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks([FromQuery] QueryParameters queryParameters)
        {
            var result = await _bookManager.GetBooksAsync(queryParameters);
            return StatusCode(result.status_code, result);
        }

        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var result = await _bookManager.GetBookByIdAsync(id);
            return StatusCode(result.status_code, result);
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id, int deletedByUserId)
        {
            var result = await _bookManager.DeleteBookAsync(id, deletedByUserId);
            return StatusCode(result.status_code, result);
        }
    }
}
