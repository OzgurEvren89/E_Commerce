using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Distributor;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.DistributorToProduct
{
    public class DistributorToProductResponse : BaseDto
    {
        public Guid ProductId { get; set; }
        public ProductResponse Product { get; set; }   
        public Guid DistributorId { get; set; }
        public DistributorResponse Distributor { get; set; }     
        public DateTime? CreatedDate { get; set; }
    }
}
