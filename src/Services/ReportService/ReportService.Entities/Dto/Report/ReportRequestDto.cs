using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReportService.Core.Enum.Enums;

namespace ReportService.Entities.Dto.Report
{
    public class ReportRequestDto
    {
        public string Location { get; set; }

        public Guid RequestUUID { get; set; }
    }
}
