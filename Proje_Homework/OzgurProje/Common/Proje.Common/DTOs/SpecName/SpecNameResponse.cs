using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.SpecGroup;
using Proje.Common.DTOs.SpecToProduct;
using Proje.Common.DTOs.SpecValue;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.SpecName
{
    public class SpecNameResponse : BaseDto
    {
        public SpecNameResponse()
        {
            SpecValues = new HashSet<SpecValueResponse>();
            SpecToProducts = new HashSet<SpecToProductResponse>();

        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int ShortOrder { get; set; }
        public Guid SpecGroupId { get; set; }
        public SpecGroupResponse SpecGroup { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<SpecValueResponse> SpecValues { get; set; }
        public ICollection<SpecToProductResponse> SpecToProducts { get; set; }


    }
}
