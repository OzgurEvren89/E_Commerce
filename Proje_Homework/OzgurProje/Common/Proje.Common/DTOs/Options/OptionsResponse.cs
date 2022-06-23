using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.OptionGroup;
using Proje.Common.DTOs.OptionToProduct;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Options
{
    public class OptionsResponse : BaseDto
    {
        public OptionsResponse()
        {
            OptionToProducts = new HashSet<OptionToProductResponse>();
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public Guid OptionGroupId { get; set; }
        public OptionGroupResponse OptionGroup { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<OptionToProductResponse> OptionToProducts { get; set; }

    }
}
