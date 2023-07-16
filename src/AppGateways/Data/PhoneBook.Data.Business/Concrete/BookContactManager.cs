using AutoMapper;
using PhoneBook.Data.Business.Abstract;
using PhoneBook.Data.Core.Enum;
using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.DataAccess.Abstract;
using PhoneBook.Data.Entities.Concrete;
using PhoneBook.Data.Entities.Dto.BookContact;
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
        private readonly IUnitOfWorkPhoneBook _uow;
        private readonly IMapper _mapper;

        public BookContactManager(IMapper mapper, IUnitOfWorkPhoneBook uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<BookContactDto>>> GetList(Expression<Func<BookContact, bool>> filter = null)
        {
            try
            {
                var dataList = await _uow.BookContactRepository.GetList(filter);

                if (dataList != null)
                {
                    var response = _mapper.Map<List<BookContactDto>>(dataList);
                    return Response<IEnumerable<BookContactDto>>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<IEnumerable<BookContactDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<IEnumerable<BookContactDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookContactDto>> GetBookContactById(Guid uuid)
        {
            try
            {
                var dataControl = await _uow.BookContactRepository.Get(i => i.UUID == uuid);

                if (dataControl != null)
                {
                    var response = _mapper.Map<BookContactDto>(dataControl);
                    return Response<BookContactDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookContactDto>> Insert(InsertBookContactDto entity)
        {
            try
            {
                var requestModel = _mapper.Map<BookContact>(entity);

                var addedData = await _uow.BookContactRepository.Insert(requestModel);
                await _uow.CommitAsync();
                if (addedData != null)
                {
                    var response = _mapper.Map<BookContactDto>(addedData);
                    return Response<BookContactDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookContactDto>> Update(UpdateBookContactDto entity)
        {
            try
            {
                var requestModel = _mapper.Map<BookContact>(entity);

                var updatedData = await _uow.BookContactRepository.Update(requestModel);
                await _uow.CommitAsync();

                if (updatedData != null)
                {
                    var response = _mapper.Map<BookContactDto>(updatedData);
                    return Response<BookContactDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookContactDto>> Delete(Guid uuid)
        {
            try
            {
                var controlData = await _uow.BookContactRepository.Get(i => i.UUID == uuid);
                if (controlData != null)
                {
                    controlData.Deleted = true;
                    var deletedData = await _uow.BookContactRepository.Update(controlData);
                    await _uow.CommitAsync();

                    var response = _mapper.Map<BookContactDto>(deletedData);

                    return Response<BookContactDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }
            }
            catch (Exception ex)
            {
                return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }
    }
}
