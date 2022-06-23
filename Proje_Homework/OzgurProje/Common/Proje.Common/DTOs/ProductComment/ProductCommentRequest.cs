using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.ProductComment
{
    public class ProductCommentRequest : BaseDto
    {
        public string Content { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

    }
}
