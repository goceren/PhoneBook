using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Entities.Configuration
{
    public partial class ReportConfiguration : IEntityTypeConfiguration<Concrete.Report>
    {
        public void Configure(EntityTypeBuilder<Concrete.Report> builder)
        {
            builder.HasKey(x => x.UUID);
            builder.Property(x => x.UUID).ValueGeneratedOnAdd();
            builder.Property(x => x.RequestUUID);
            builder.Property(x => x.RequestDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
