using AutoMapper;
using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Core.Enum;
using PhoneBook.Report.Core.ResponseTypes;
using PhoneBook.Report.DataAccess.Abstract;
using PhoneBook.Report.Entities.Dto.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IUnitOfWorkReport _uow;
        private readonly IMapper _mapper;
        public ReportManager(IMapper mapper, IUnitOfWorkReport uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response<IEnumerable<ReportDto>>> GetList(Expression<Func<Report.Entities.Concrete.Report, bool>> filter = null)
        {
            try
            {
                var dataList = await _uow.ReportRepository.GetList(filter);

                if (dataList != null)
                {
                    var response = _mapper.Map<List<ReportDto>>(dataList);
                    return Response<IEnumerable<ReportDto>>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<IEnumerable<ReportDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<IEnumerable<ReportDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<ReportDto>> GetReportById(Guid uuid)
        {
            try
            {
                var dataControl = await _uow.ReportRepository.Get(i => i.UUID == uuid);

                if (dataControl != null)
                {
                    var response = _mapper.Map<ReportDto>(dataControl);
                    return Response<ReportDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<ReportDto>> Get(Expression<Func<Report.Entities.Concrete.Report, bool>> filter = null)
        {
            try
            {
                var dataControl = await _uow.ReportRepository.Get(filter);

                if (dataControl != null)
                {
                    var response = _mapper.Map<ReportDto>(dataControl);
                    return Response<ReportDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }


        public async Task<Response<ReportDto>> Insert(InsertReportDto entity)
        {
            try
            {
                var requestModel = _mapper.Map<Report.Entities.Concrete.Report>(entity);
                var addedData = await _uow.ReportRepository.Insert(requestModel);
                await _uow.CommitAsync();
                if (addedData != null)
                {
                    var response = _mapper.Map<ReportDto>(addedData);
                    return Response<ReportDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<ReportDto>> Update(UpdateReportDto entity)
        {
            try
            {
                var requestModel = _mapper.Map<Report.Entities.Concrete.Report>(entity);
                var updatedData = await _uow.ReportRepository.Update(requestModel);
                await _uow.CommitAsync();
                if (updatedData != null)
                {
                    var response = _mapper.Map<ReportDto>(updatedData);
                    return Response<ReportDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<ReportDto>> Delete(Guid uuid)
        {
            try
            {
                var deletedData = await _uow.ReportRepository.Delete(i => i.UUID == uuid);
                await _uow.CommitAsync();
                if (deletedData != null)
                {
                    var response = _mapper.Map<ReportDto>(deletedData);
                    return Response<ReportDto>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }
    }
}
