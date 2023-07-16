﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReportService.Core.Enum.Enums;

namespace ReportService.Entities.Dto.BookContact
{
    public class BookContactDto
    {
        public Guid UUID { get; set; }
        public ContactTypeEnum Type { get; set; }
        public string Information { get; set; }
        public Guid BookUUID { get; set; }
    }
}
