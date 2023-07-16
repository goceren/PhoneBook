using PhoneBook.Report.Core.ResponseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Business.Abstract
{
    public interface IReportService
    {
        Task<Response<Entities.Dto.Report.ReportDto>> GetReportById(Guid uuid);

        Task<Response<Entities.Dto.Report.ReportDto>> Get(Expression<Func<Report.Entities.Concrete.Report, bool>> filter = null);
        Task<Response<Entities.Dto.Report.ReportDto>> Insert(Entities.Dto.Report.InsertReportDto entity);
        Task<Response<Report.Entities.Dto.Report.ReportDto>> Update(Report.Entities.Dto.Report.UpdateReportDto entity);
        Task<Response<Report.Entities.Dto.Report.ReportDto>> Delete(Guid uuid);
        Task<Response<IEnumerable<Report.Entities.Dto.Report.ReportDto>>> GetList(Expression<Func<Report.Entities.Concrete.Report, bool>> filter = null);
    }
}
