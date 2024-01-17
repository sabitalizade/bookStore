using AutoMapper;
using BooksApi.Models;
using BookStore.Dtos;

namespace BookStore.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookDto, Book>()
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ForMember(dest => dest.StoreBooks, opt => opt.Ignore());
            CreateMap<Book, BookDto>();
            // .ForMember(dest => dest.Author, opt => opt.Ignore());
            // .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author));
            CreateMap<Stores, StoreDto>();
            CreateMap<StoreDto, Stores>();
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

        }
    }
}