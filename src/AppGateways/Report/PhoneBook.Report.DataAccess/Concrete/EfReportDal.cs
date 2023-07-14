using PhoneBook.Report.Core.DataAccess.EntityFramework;
using PhoneBook.Report.DataAccess.Abstract;
using PhoneBook.Report.DataAccess.Context;
using PhoneBook.Report.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.DataAccess.Concrete
{
    public class EfReportDal : GenericRepository<Entities.Concrete.Report, ReportContext>, IReportDal
    {
    }
}
