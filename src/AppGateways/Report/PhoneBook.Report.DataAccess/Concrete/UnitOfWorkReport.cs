using PhoneBook.Report.Core.DataAccess.EntityFramework;
using PhoneBook.Report.DataAccess.Abstract;
using PhoneBook.Report.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.DataAccess.Concrete
{

    public class UnitOfWorkReport : UnitOfWork<ReportContext>, IUnitOfWorkReport
    {
        private readonly ReportContext _context;

        public UnitOfWorkReport(ReportContext context) : base(context)
        {
            _context = context;
        }


        private IReportRepository _reportRepository;

        public IReportRepository ReportRepository => _reportRepository ??= new ReportRepository(_context);

    }
}
