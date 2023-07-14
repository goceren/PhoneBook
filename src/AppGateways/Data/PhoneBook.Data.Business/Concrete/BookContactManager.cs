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
    public class BookContactManager : IBookContactService
    {
        private readonly IBookContactDal _bookContactDal;

        public BookContactManager(IBookContactDal bookContactDal)
        {
            _bookContactDal = bookContactDal;
        }

        public async Task<Response<List<BookContact>>> GetList(Expression<Func<BookContact, bool>> filter = null)
        {
            try
            {
                var response = await _bookContactDal.GetList(filter);

                if (response != null)
                {
                    return Response<List<BookContact>>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<List<BookContact>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<List<BookContact>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookContact>> GetBookContactById(Guid uuid)
        {
            try
            {
                var response = await _bookContactDal.Get(i => i.UUID == uuid);

                if (response != null)
                {
                    return Response<BookContact>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookContact>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookContact>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookContact>> Insert(BookContact entity)
        {
            try
            {
                var response = await _bookContactDal.Insert(entity);

                if (response != null)
                {
                    return Response<BookContact>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookContact>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookContact>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookContact>> Update(BookContact entity)
        {
            try
            {
                var response = await _bookContactDal.Update(entity);

                if (response != null)
                {
                    return Response<BookContact>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookContact>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookContact>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookContact>> Delete(Guid uuid)
        {
            try
            {
                var response = await _bookContactDal.Delete(i => i.UUID == uuid);

                if (response != null)
                {
                    return Response<BookContact>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookContact>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookContact>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }
    }
}
