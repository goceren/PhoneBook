using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.Entities.Concrete;
using PhoneBook.Data.Entities.Dto;
using PhoneBook.Data.Entities.Dto.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Business.Abstract
{
    public interface IBookService
    {
        Task<Response<BookDto>> GetBookById(Guid uuid);
        Task<Response<BookDto>> Insert(InsertBookDto entity);
        Task<Response<BookDto>> Update(UpdateBookDto entity);
        Task<Response<BookDto>> Delete(Guid uuid);
        Task<Response<IEnumerable<BookDto>>> GetList(Expression<Func<Book, bool>> filter = null);
        Task<Response<BookReportContentDto>> GetByLocationIncludeContact(BookStatusAndLocationFilterDto model);

        Task<Response<BookDto>> GetBookIncludeContact(Guid uuid);
    }
}
