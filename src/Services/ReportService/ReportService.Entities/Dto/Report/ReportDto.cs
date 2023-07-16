using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReportService.Core.Enum.Enums;

namespace ReportService.Entities.Dto.Report
{
    public class ReportDto
    {
        public Guid UUID { get; set; }
        public DateTime RequestDate { get; set; }
        public ReportStatusEnum Status { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PersonPhoneCount { get; set; }
    }
}
