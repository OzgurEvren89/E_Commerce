using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.BrandToCategory;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Category
{
    public class CategoryResponse : BaseDto
    {
        public CategoryResponse()
        {
            BrandToCategories = new HashSet<BrandToCategoryResponse>();
            Products = new HashSet<ProductResponse>();

        }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }    
        public DateTime? CreatedDate { get; set; }
        public ICollection<BrandToCategoryResponse> BrandToCategories { get; set; }
        public ICollection<ProductResponse> Products { get; set; }



    }
}
