using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Domain.Models;

namespace BookStore.Application.Mappings
{
    public class BookAutoMapper : Profile
    {
        public BookAutoMapper()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
