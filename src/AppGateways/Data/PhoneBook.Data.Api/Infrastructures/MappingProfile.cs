using AutoMapper;
using PhoneBook.Data.Entities.Concrete;
using PhoneBook.Data.Entities.Dto.Book;
using PhoneBook.Data.Entities.Dto.BookContact;

namespace PhoneBook.Data.Api.Infrastructures
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, InsertBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();

            CreateMap<BookContact, BookContactDto>().ReverseMap();
            CreateMap<BookContact, InsertBookContactDto>().ReverseMap();
            CreateMap<BookContact, UpdateBookContactDto>().ReverseMap();
        }
    }
}
