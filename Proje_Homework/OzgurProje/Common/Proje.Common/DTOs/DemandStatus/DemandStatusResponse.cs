using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.DemandStatus
{
    public class DemandStatusResponse : BaseDto
    {
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
