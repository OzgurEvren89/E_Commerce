using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Options;
using Proje.Common.DTOs.OptionToProduct;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.OptionGroup
{
    public class OptionGroupResponse : BaseDto
    {
        public OptionGroupResponse()
        {
            Options = new HashSet<OptionsResponse>();
            OptionToProducts = new HashSet<OptionToProductResponse>();
        }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<OptionsResponse> Options { get; set; }
        public ICollection<OptionToProductResponse> OptionToProducts { get; set; }

    }
}

