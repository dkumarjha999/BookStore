using AutoFixture;
using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Services.Books;
using BookStore.Domain.Models;
using BookStore.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace BookStore.UnitTests.Application.Services
{
    public class BookServiceTests
    {
        private readonly Fixture _fixture;

        public BookServiceTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAllBooksAsync_ShouldReturnListOfBooks()
        {
            // Arrange
            var expectedBooks = _fixture.CreateMany<Book>(2);
            var bookRepositoryMock = new Mock<IBookRepository>();
            bookRepositoryMock.Setup(repo => repo.GetAllBooksAsync()).ReturnsAsync(expectedBooks);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<IEnumerable<BookDto>>(It.IsAny<IEnumerable<Book>>()))
                      .Returns(_fixture.CreateMany<BookDto>(2));

            var bookService = new BookService(bookRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await bookService.GetAllBooksAsync();

            // Assert
            result.Should().NotBeNull().And.BeAssignableTo<IEnumerable<BookDto>>();
            result.Should().HaveCount(2);
        }
    }

}
