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
        Task<Response<Entities.Concrete.Report>> GetReportById(Guid uuid);
        Task<Response<Entities.Concrete.Report>> Insert(Entities.Concrete.Report entity);
        Task<Response<Report.Entities.Concrete.Report>> Update(Report.Entities.Concrete.Report entity);
        Task<Response<Report.Entities.Concrete.Report>> Delete(Guid uuid);
        Task<Response<List<Report.Entities.Concrete.Report>>> GetList(Expression<Func<Report.Entities.Concrete.Report, bool>> filter = null);
    }
}
