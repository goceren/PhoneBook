using AutoMapper;
using PhoneBook.Data.Business.Abstract;
using PhoneBook.Data.Core.Enum;
using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.DataAccess.Abstract;
using PhoneBook.Data.Entities.Concrete;
using PhoneBook.Data.Entities.Dto;
using PhoneBook.Data.Entities.Dto.Book;
using PhoneBook.Data.Entities.Dto.BookContact;
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

        private readonly IUnitOfWorkPhoneBook _uow;
        private readonly IMapper _mapper;
        public BookManager(IUnitOfWorkPhoneBook uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<BookDto>>> GetList(Expression<Func<Book, bool>> filter = null)
        {
            try
            {

                var dataList = await _uow.BookRepository.GetList(filter);
                if (dataList != null && dataList.Count() > 0)
                {
                    var response = _mapper.Map<List<BookDto>>(dataList);

                    return Response<IEnumerable<BookDto>>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<IEnumerable<BookDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<IEnumerable<BookDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookDto>> GetBookById(Guid uuid)
        {
            try
            {
                var dataControl = await _uow.BookRepository.Get(i => i.UUID == uuid && !i.Deleted);

                if (dataControl != null)
                {
                    var response = _mapper.Map<BookDto>(dataControl);

                    return Response<BookDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookDto>> Insert(InsertBookDto entity)
        {
            try
            {
                var requestModel = _mapper.Map<Book>(entity);

                var addedData = await _uow.BookRepository.Insert(requestModel);
                await _uow.CommitAsync();
                if (addedData != null)
                {
                    var response = _mapper.Map<BookDto>(addedData);

                    return Response<BookDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookDto>> Update(UpdateBookDto entity)
        {
            try
            {
                var requestModel = _mapper.Map<Book>(entity);

                var updatedData = await _uow.BookRepository.Update(requestModel);
                await _uow.CommitAsync();
                if (updatedData != null)
                {
                    var response = _mapper.Map<BookDto>(updatedData);

                    return Response<BookDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookDto>> Delete(Guid uuid)
        {
            try
            {
                var controlData = await _uow.BookRepository.Get(i => i.UUID == uuid);
                if (controlData != null)
                {
                    controlData.Deleted = true;
                    var deletedData = await _uow.BookRepository.Update(controlData);
                    await _uow.CommitAsync();

                    var response = _mapper.Map<BookDto>(deletedData);

                    return Response<BookDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }


            }
            catch (Exception ex)
            {
                return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<BookReportContentDto>> GetByLocationIncludeContact(BookStatusAndLocationFilterDto model)
        {
            try
            {
                var controlData = await _uow.BookRepository.GetIncludeContact(i => !i.Deleted && i.BookContacts.Any(i => i.Type == Enums.ContactTypeEnum.Location && i.Information.Equals(model.Location)));
                if (controlData != null && controlData.Count() > 0)
                {

                    var response = _mapper.Map<IEnumerable<BookDto>>(controlData);
                    var returnModel = new BookReportContentDto()
                    {
                        Location = model.Location,
                        Books = response
                    };
                    return Response<BookReportContentDto>.Success(returnModel, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<BookReportContentDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }


            }
            catch (Exception ex)
            {
                return Response<BookReportContentDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }
    }
}
