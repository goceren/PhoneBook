using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneBook.Report.Core.Enum.Enums;

namespace PhoneBook.Report.Entities.Concrete
{
    public partial class Report
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatusEnum Status { get; set; }
    }
}
