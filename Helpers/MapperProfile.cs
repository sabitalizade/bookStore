using AutoMapper;
using BookStore.Models;
using BookStore.Dto;

namespace BookStore.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BookDto, Book>()
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ForMember(dest => dest.StoreBooks, opt => opt.Ignore()).ReverseMap();
            // .ForMember(dest => dest.Author, opt => opt.Ignore());
            // .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author));
            CreateMap<Stores, StoreDto>();
            CreateMap<StoreDto, Stores>();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorDetailsDto>().ReverseMap();
            CreateMap<Users, UserDto>().ReverseMap();

        }
    }
}