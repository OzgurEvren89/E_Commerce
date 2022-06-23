using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.BrandToCategoryViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.BrandViewModels
{
    public class BrandViewModel
    {
        public BrandViewModel()
        {
            BrandToCategories = new HashSet<BrandToCategoryViewModel>();
            Products = new HashSet<ProductViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }     
        public string BrandName { get; set; }
        public string Description { get; set; }       
        public DateTime? CreatedDate { get; set; }

        public ICollection<BrandToCategoryViewModel> BrandToCategories { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }

    }
}
