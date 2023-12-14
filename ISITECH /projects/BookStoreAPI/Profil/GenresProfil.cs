using AutoMapper;
using BookStoreAPI.Models;
using BookStoreAPI.Entities;

namespace BookStoreAPI
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}