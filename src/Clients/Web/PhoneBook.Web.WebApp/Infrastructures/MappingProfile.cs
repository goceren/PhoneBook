using AutoMapper;
using PhoneBook.Web.Entities.Dto.Book;
using PhoneBook.Web.Entities.Dto.BookContact;

namespace PhoneBook.Web.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDto, InsertBookDto>().ReverseMap();
            CreateMap<BookDto, UpdateBookDto>().ReverseMap();

            CreateMap<BookContactDto, InsertBookContactDto>().ReverseMap();
            CreateMap<BookContactDto, UpdateBookContactDto>().ReverseMap();

            //CreateMap<InsertBookDto, BookDto>().ReverseMap();
            //CreateMap<UpdateBookDto, BookDto>().ReverseMap();

        }
    }
}
