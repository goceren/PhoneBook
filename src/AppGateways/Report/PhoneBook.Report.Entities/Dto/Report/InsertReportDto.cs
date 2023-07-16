using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Entities.Dto.Report
{
    public class InsertReportDto
    {
        public Guid RequestUUID { get; set; }
        public DateTime RequestDate { get; set; }
        public Core.Enum.Enums.ReportStatusEnum Status { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PersonPhoneCount { get; set; }
    }
}
