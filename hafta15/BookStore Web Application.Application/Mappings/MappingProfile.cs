using AutoMapper;
using BookStore_Web_Application.Core.Dtos;
using BookStore_Web_Application.Core.Entities;

namespace BookStore_Web_Application.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName,
                    opt => opt.MapFrom(src => src.Author != null ? src.Author.Name : string.Empty))
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));

            CreateMap<BookDto, Book>();
        }
    }
}