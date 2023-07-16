using EventBus.Core.Dto;
using EventBus.Core.Models;
using EventBus.Core.ResponseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Business.Abstract
{
    public interface IReportQService
    {
        Task<Response<ReportDto>> CreateReport(CreateReportModel model);

        Task<Response<ReportDto>> CompleteReport(CreateReportModel model);
    }
}
