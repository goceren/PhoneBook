﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventBus.Core.Enum.Enums;

namespace EventBus.Core.Models
{
    public class CreateReportModel
    {
        public string Location { get; set; }

        public Guid RequestUUID { get; set; }
    }
}
