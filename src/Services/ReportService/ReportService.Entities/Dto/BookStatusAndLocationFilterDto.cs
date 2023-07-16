using ReportService.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Entities.Dto
{
    public class BookStatusAndLocationFilterDto
    {
        public string Location { get; set; }
        public Enums.ContactTypeEnum Type { get; set; }
    }
}
