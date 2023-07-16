using PhoneBook.Web.Entities.Dto.BookContact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Web.Entities.Dto.Book
{
    public class BookDto
    {
        public BookDto()
        {
            BookContacts = new List<BookContactDto>();
        }

        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public List<BookContactDto> BookContacts { get; set; }


    }
}
