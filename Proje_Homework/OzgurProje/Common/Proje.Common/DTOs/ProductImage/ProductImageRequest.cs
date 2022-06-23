using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.ProductImage
{
    public class ProductImageRequest : BaseDto
    {
        public string FileName { get; set; }
        public string Revision { get; set; }
        [Required]
        public int SortOrder { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }
}
