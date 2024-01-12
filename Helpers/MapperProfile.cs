
using AutoMapper;
using BooksApi.Models;
using BookStore.Dtos;
using BookStore.Interfaces;

namespace BookStore.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookCreation, Book>();
            CreateMap<Stores, StoreDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

        }
    }
}