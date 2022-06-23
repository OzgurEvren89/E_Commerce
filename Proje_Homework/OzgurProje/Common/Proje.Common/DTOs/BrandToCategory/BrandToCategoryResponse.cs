using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Brand;
using Proje.Common.DTOs.Category;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.BrandToCategory
{
    public class BrandToCategoryResponse : BaseDto
    {
        public Guid CategoryId { get; set; }
        public CategoryResponse Category { get; set; }

        public Guid BrandId { get; set; }
        public BrandResponse Brand { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
