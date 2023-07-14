using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Core.Enum;
using PhoneBook.Report.Core.ResponseTypes;
using PhoneBook.Report.DataAccess.Abstract;
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
        private readonly IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public async Task<Response<List<Report.Entities.Concrete.Report>>> GetList(Expression<Func<Report.Entities.Concrete.Report, bool>> filter = null)
        {
            try
            {
                var response = await _reportDal.GetList(filter);

                if (response != null)
                {
                    return Response<List<Report.Entities.Concrete.Report>>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<List<Report.Entities.Concrete.Report>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<List<Report.Entities.Concrete.Report>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<Report.Entities.Concrete.Report>> GetReportById(Guid uuid)
        {
            try
            {
                var response = await _reportDal.Get(i => i.UUID == uuid);

                if (response != null)
                {
                    return Response<Report.Entities.Concrete.Report>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<Report.Entities.Concrete.Report>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "Veri Bulunamadı" });
                }

            }
            catch (Exception ex)
            {
                return Response<Report.Entities.Concrete.Report>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<Report.Entities.Concrete.Report>> Insert(Report.Entities.Concrete.Report entity)
        {
            try
            {
                var response = await _reportDal.Insert(entity);

                if (response != null)
                {
                    return Response<Report.Entities.Concrete.Report>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<Report.Entities.Concrete.Report>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<Report.Entities.Concrete.Report>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<Report.Entities.Concrete.Report>> Update(Report.Entities.Concrete.Report entity)
        {
            try
            {
                var response = await _reportDal.Update(entity);

                if (response != null)
                {
                    return Response<Report.Entities.Concrete.Report>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<Report.Entities.Concrete.Report>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<Report.Entities.Concrete.Report>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public async Task<Response<Report.Entities.Concrete.Report>> Delete(Guid uuid)
        {
            try
            {
                var response = await _reportDal.Delete(i => i.UUID == uuid);

                if (response != null)
                {
                    return Response<Report.Entities.Concrete.Report>.Success(response, Enums.ResponseStatusEnum.Success.GetEnumInteger());
                }
                else
                {
                    return Response<Report.Entities.Concrete.Report>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { "İşlem Başarısız" });
                }

            }
            catch (Exception ex)
            {
                return Response<Report.Entities.Concrete.Report>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }
    }
}
