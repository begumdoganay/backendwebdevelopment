using AutoMapper;
using BookStore_Web_Application.Core.Entities;
using BookStore_Web_Application.Core.Dtos;
using UpdateBookDto = BookStore_Web_Application.Core.Dtos.Books.UpdateBookDto;

namespace BookStore_Web_Application.Application.Common.Mappings
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

            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Author, AuthorDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.UserName,
                          opt => opt.MapFrom(src => src.User != null ? $"{src.User.FirstName} {src.User.LastName}" : string.Empty));
        }
    }

}