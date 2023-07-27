using BookStore.Application.DTOs;

namespace BookStore.Application.Services.Books
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
    }
}
