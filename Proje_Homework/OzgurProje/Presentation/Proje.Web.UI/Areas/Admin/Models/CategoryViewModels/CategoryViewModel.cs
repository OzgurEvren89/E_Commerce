using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.BrandToCategoryViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proje.Web.UI.Areas.Admin.Models.CategoryViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            BrandToCategories = new HashSet<BrandToCategoryViewModel>();
            Products = new HashSet<ProductViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        //[Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }       
        public DateTime? CreatedDate { get; set; }

        public ICollection<BrandToCategoryViewModel> BrandToCategories { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }

    }
}
