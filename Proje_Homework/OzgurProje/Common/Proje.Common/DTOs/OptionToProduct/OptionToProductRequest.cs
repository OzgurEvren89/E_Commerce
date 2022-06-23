using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.OptionToProduct
{
    public class OptionToProductRequest : BaseDto
    {
        public Guid ParentProductId { get; set; }
        public Guid OptionGroupId { get; set; }
        public Guid OptionId { get; set; }
        public Guid ProductId { get; set; }
    }
}
