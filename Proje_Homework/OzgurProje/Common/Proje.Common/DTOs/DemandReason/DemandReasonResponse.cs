using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.DemandReason
{
    public class DemandReasonResponse : BaseDto
    {
        public string Reason { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
