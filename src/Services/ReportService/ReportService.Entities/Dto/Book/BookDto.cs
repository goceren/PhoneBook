using ReportService.Entities.Dto.BookContact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Entities.Dto.Book
{
    public class BookDto
    {
        public BookDto()
        {
            BookContacts = new HashSet<BookContactDto>();
        }
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }


        public virtual IEnumerable<BookContactDto> BookContacts { get; set; }
    }
}
