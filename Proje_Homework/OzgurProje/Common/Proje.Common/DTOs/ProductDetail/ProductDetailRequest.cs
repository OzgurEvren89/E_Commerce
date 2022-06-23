using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.ProductDetail
{
    public class ProductDetailRequest : BaseDto
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public Guid ProductId { get; set; }
    }
}
