using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Core.Enum
{
    public class Enums
    {
        public enum ContactTypeEnum
        {
            Phone = 0,
            Email= 1,
            Location= 2
        }

        public enum ResponseStatusEnum
        {
            Error = 0,
            Success = 1,
            NoData = 2
        }
    }
}
