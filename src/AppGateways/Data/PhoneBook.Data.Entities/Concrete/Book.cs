using PhoneBook.Data.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Entities.Concrete
{
    public partial class Book : BaseEntity
    {
        public Book()
        {
            BookContacts = new HashSet<BookContact>();
        }

        public Guid UUID{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company{ get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<BookContact> BookContacts { get; set; }
    }
}
