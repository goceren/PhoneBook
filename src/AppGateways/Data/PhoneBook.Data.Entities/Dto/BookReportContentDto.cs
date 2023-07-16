﻿using PhoneBook.Data.Entities.Dto.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Entities.Dto
{
    public class BookReportContentDto
    {
        public BookReportContentDto()
        {
            Books = new HashSet<BookDto>();
        }


        public string Location { get; set; }

        public virtual IEnumerable<BookDto> Books { get; set; }
    }
}
