using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Domain.Models;
using BookStore.Domain.Repositories;

namespace BookStore.Application.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            IEnumerable<Book> books = await _bookRepository.GetAllBooksAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
