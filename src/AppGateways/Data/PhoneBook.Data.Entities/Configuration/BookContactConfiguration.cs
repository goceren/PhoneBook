using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Entities.Configuration
{
    public partial class BookContactConfiguration : IEntityTypeConfiguration<BookContact>
    {
        public void Configure(EntityTypeBuilder<BookContact> builder)
        {
            builder.HasKey(x => x.UUID);
            builder.Property(x => x.UUID).ValueGeneratedOnAdd();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Information).IsRequired();
        }
    }
}