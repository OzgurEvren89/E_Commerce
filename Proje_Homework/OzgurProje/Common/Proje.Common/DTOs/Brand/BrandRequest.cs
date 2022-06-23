using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Brand
{
    public class BrandRequest : BaseDto
    {
        public string BrandName { get; set; }
        public string Description { get; set; }
    }
}
