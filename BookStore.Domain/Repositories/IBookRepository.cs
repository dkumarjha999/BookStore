using BookStore.Domain.Models;

namespace BookStore.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
