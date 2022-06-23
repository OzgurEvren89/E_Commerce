using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.BrandToCategory
{
    public class BrandToCategoryRequest : BaseDto
    {
        
        public Guid CategoryId { get; set; }
       
        public Guid BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }
}
