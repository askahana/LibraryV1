using AutoMapper;
using Shared.Models;
using Shared.Models.Dtos;

namespace LibraryAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookUpdateDto>().ReverseMap();
        }
    }
}
