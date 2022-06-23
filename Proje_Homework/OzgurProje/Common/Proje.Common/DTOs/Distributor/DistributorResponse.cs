using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.DistributorToProduct;
using Proje.Common.DTOs.User;
using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Distributor
{
    public class DistributorResponse : BaseDto
    {
        public DistributorResponse()
        {
            DistributorToProducts = new HashSet<DistributorToProductResponse>();

        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }      
        public DateTime? CreatedDate { get; set; }

        public ICollection<DistributorToProductResponse> DistributorToProducts { get; set; }

    }
}
