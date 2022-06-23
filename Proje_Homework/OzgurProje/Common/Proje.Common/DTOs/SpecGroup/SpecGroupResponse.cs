using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.SpecName;
using Proje.Common.DTOs.SpecToProduct;
using Proje.Common.DTOs.SpecValue;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.SpecGroup
{
    public class SpecGroupResponse : BaseDto
    {
        public SpecGroupResponse()
        {
            SpecNames = new HashSet<SpecNameResponse>();
            SpecValues = new HashSet<SpecValueResponse>();
            SpecToProducts = new HashSet<SpecToProductResponse>();

        }
        public string SpecGroupName { get; set; }
        public int ShortOrder { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<SpecNameResponse> SpecNames { get; set; }
        public ICollection<SpecValueResponse> SpecValues { get; set; }
        public ICollection<SpecToProductResponse> SpecToProducts { get; set; }


    }
}
