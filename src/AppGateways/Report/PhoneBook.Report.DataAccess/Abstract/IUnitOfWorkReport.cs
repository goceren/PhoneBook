using PhoneBook.Report.Core.DataAccess;
using PhoneBook.Report.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.DataAccess.Abstract
{
    public interface IUnitOfWorkReport : IUnitOfWork<ReportContext>
    {
        IReportRepository ReportRepository { get; }
    }
}
