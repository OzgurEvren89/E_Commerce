using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.SpecGroup;
using Proje.Common.DTOs.SpecName;
using Proje.Common.DTOs.SpecToProduct;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.SpecValue
{
    public class SpecValueResponse : BaseDto
    {
        public SpecValueResponse()
        {
            SpecToProducts = new HashSet<SpecToProductResponse>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public Guid SpecNameId { get; set; }
        public SpecNameResponse SpecName { get; set; }
        public Guid SpecGroupId { get; set; }
        public SpecGroupResponse SpecGroup { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<SpecToProductResponse> SpecToProducts { get; set; }


    }
}
