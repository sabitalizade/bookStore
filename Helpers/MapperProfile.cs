
using AutoMapper;
using BooksApi.Models;
using BookStore.Dtos;

namespace BookStore.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Stores, StoreDto>();
            CreateMap<Author, AuthorDto>();
        }
    }
}