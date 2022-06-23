using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.SpecGroup;
using Proje.Common.DTOs.SpecName;
using Proje.Common.DTOs.SpecValue;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.SpecToProduct
{
    public class SpecToProductResponse : BaseDto
    {
        public Guid ProductId { get; set; }
        public ProductResponse Product { get; set; }
        public Guid SpecGroupId { get; set; }
        public SpecGroupResponse SpecGroup { get; set; }
        public Guid SpecNameId { get; set; }
        public SpecNameResponse SpecName { get; set; }
        public Guid SpecValueId { get; set; }
        public SpecValueResponse SpecValue { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
