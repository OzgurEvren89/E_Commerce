using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.SpecToProduct
{
    public class SpecToProductRequest : BaseDto
    {
        public Guid ProductId { get; set; }
        public Guid SpecGroupId { get; set; }
        public Guid SpecNameId { get; set; }
        public Guid SpecValueId { get; set; }

    }
}
