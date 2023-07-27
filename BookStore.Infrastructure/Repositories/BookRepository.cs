using BookStore.Domain.Models;
using BookStore.Domain.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NotesApp.Infrastructure.MongoData;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;
        public BookRepository(IMongoDatabase mongoDatabase, IOptions<MongoDbSettings> mongoDbSettings)
        {
            _books = mongoDatabase.GetCollection<Book>(mongoDbSettings.Value.BooksCollectionName);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _books.Find(book => true).ToListAsync();
        }

    }
}
