using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.ProductDetail
{
    public class ProductDetailResponse : BaseDto
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public Guid ProductId { get; set; }
        public ProductResponse Product { get; set; }      
        public DateTime? CreatedDate { get; set; }
    }
}
