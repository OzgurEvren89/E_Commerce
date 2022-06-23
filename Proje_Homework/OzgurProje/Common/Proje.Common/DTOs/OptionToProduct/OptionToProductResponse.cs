using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.OptionGroup;
using Proje.Common.DTOs.Options;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.OptionToProduct
{
    public class OptionToProductResponse : BaseDto
    {
        public Guid ParentProductId { get; set; }
        public Guid OptionGroupId { get; set; }
        public OptionGroupResponse OptionGroup { get; set; }
        public Guid OptionId { get; set; }
        public OptionsResponse Option { get; set; }
        public Guid ProductId { get; set; }
        public ProductResponse Product { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
