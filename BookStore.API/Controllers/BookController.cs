
using BookStore.Application.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
