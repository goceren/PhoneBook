using Microsoft.EntityFrameworkCore;
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
    public class ReportRepository : GenericRepository<Entities.Concrete.Report>, IReportRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Entities.Concrete.Report> _dbSet;

        public ReportRepository(ReportContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Entities.Concrete.Report>();
        }
    }
}
