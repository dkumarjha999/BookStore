using AutoFixture;
using BookStore.API.Controllers;
using BookStore.Application.DTOs;
using BookStore.Application.Services.Books;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BookStore.UnitTests.API.Controllers
{
    public class BookControllerTests
    {
        private readonly Fixture _fixture;

        public BookControllerTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAllBooksAsync_ShouldReturnOkResultWithListOfBooks()
        {
            // Arrange
            var expectedBooks = _fixture.CreateMany<BookDto>(3);
            var bookServiceMock = new Mock<IBookService>();
            bookServiceMock.Setup(service => service.GetAllBooksAsync()).ReturnsAsync(expectedBooks);

            var controller = new BookController(bookServiceMock.Object);

            // Act
            var actionResult = await controller.GetAllBooksAsync();

            // Assert
            actionResult.Should().BeOfType<OkObjectResult>();
            var okResult = actionResult.As<OkObjectResult>();
            okResult.Value.Should().BeEquivalentTo(expectedBooks);
        }

        [Fact]
        public async Task GetAllBooksAsync_ShouldReturnInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            bookServiceMock.Setup(service => service.GetAllBooksAsync()).ThrowsAsync(new Exception());

            var controller = new BookController(bookServiceMock.Object);

            // Act
            var actionResult = await controller.GetAllBooksAsync();

            // Assert
            actionResult.Should().BeOfType<StatusCodeResult>()
                .Which.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }

}



