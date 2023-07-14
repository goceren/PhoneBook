using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Core.Enum
{
    public class Enums
    {
        public enum ReportStatusEnum
        {
            Processing = 0,
            Completed = 1
        }

        public enum ResponseStatusEnum
        {
            Error = 0,
            Success = 1,
            NoData = 2
        }
    }
}
