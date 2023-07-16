using ReportService.Core.ResponseTypes;
using ReportService.Entities.Dto.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Business.Abstract
{
    public interface IReportQueueService
    {
        Task<Response<IEnumerable<ReportDto>>> GetList();

        Task<Response<ReportRequestDto>> CreateReportRequest(ReportRequestDto model);

    }
}
