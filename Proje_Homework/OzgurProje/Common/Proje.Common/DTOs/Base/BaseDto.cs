using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Base
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

    }
}
