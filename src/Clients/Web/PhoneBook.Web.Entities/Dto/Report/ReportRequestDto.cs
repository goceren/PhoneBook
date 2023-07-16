using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Web.Entities.Dto.Report
{
    public class ReportRequestDto
    {
        [Required]
        public string Location { get; set; }

        public Guid RequestUUID { get; set; }
    }
}
