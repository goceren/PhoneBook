using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Entities.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.DataAccess.Context
{
    public partial class ReportContext : DbContext
    {

        public ReportContext(DbContextOptions<ReportContext> options) : base(options)
        {
        }

        public DbSet<PhoneBook.Report.Entities.Concrete.Report> Reports { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
        }

    }
}
