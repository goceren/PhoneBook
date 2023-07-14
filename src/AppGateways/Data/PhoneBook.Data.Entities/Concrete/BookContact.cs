using PhoneBook.Data.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneBook.Data.Core.Enum.Enums;

namespace PhoneBook.Data.Entities.Concrete
{
    public partial class BookContact : BaseEntity
    {

        public Guid UUID { get; set; }
        public ContactTypeEnum Type { get; set; }
        public string Information { get; set; }


        public virtual Book Book { get; set; }
    }
}
