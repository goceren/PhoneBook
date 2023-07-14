using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Entities.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.DataAccess.Context
{
    public partial class PhoneBookContext : DbContext
    {
        public DbSet<PhoneBook.Data.Entities.Concrete.Book> Books { get; set; }
        public DbSet<PhoneBook.Data.Entities.Concrete.BookContact> BookContacts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookContactConfiguration());
        }

    }
}
