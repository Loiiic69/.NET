using AutoMapper;
using BookStoreAPI.Models;
using BookStoreAPI.Entities;

namespace BookStoreAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
        }
    }
}