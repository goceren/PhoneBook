using PhoneBook.Web.Core;
using PhoneBook.Web.Entities.Dto.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Web.Business.Abstract
{
    public interface IReportService
    {
        Response<ReportDto> GetById(Guid uuid);

        Response<List<ReportDto>> GetReports();
        Response<ReportRequestDto> CreateReportRequest(ReportRequestDto model);
    }
}
