using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("User ID=postgres;Password=vygoceren;Server=localhost;Port=5432;Database=Test;Integrated Security=true;Pooling=true;");
        //}

        public DbSet<PhoneBook.Data.Entities.Concrete.Book> Books { get; set; }
        public DbSet<PhoneBook.Data.Entities.Concrete.BookContact> BookContacts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookContactConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
