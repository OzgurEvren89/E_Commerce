using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.DistributorToProduct
{
    public class DistributorToProductRequest : BaseDto
    {
        public Guid ProductId { get; set; }
        public Guid DistributorId { get; set; }
    }
}
