using PhoneBook.Data.Business.Abstract;
using PhoneBook.Data.Core.Enum;
using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.DataAccess.Abstract;
using PhoneBook.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public async Task<Response<List<Book>>> GetList(Expression<Func<Book, bool>> filter = null)
        {
            try
            {
                var response = await _bookDal.GetList(filter);

                if (response != null)
                {
                    return Response<List<Book>>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<List<Book>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<List<Book>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<Book>> GetBookById(Guid uuid)
        {
            try
            {
                var response = await _bookDal.Get(i => i.UUID == uuid);

                if (response != null)
                {
                    return Response<Book>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<Book>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<Book>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<Book>> Insert(Book entity)
        {
            try
            {
                var response = await _bookDal.Insert(entity);

                if (response != null)
                {
                    return Response<Book>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<Book>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<Book>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<Book>> Update(Book entity)
        {
            try
            {
                var response = await _bookDal.Update(entity);

                if (response != null)
                {
                    return Response<Book>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<Book>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<Book>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<Book>> Delete(Guid uuid)
        {
            try
            {
                var response = await _bookDal.Delete(i => i.UUID == uuid);

                if (response != null)
                {
                    return Response<Book>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<Book>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<Book>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }
    }
}
