using PhoneBook.Report.Core.DataAccess;
using PhoneBook.Report.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.DataAccess.Abstract
{
    public interface IReportDal : IEntityRepository<Report.Entities.Concrete.Report>
    {
    }
}
