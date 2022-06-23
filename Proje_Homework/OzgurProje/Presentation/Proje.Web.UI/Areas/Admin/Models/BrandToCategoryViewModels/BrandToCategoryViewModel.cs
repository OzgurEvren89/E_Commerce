using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.BrandViewModels;
using Proje.Web.UI.Areas.Admin.Models.CategoryViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.BrandToCategoryViewModels
{
    public class BrandToCategoryViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public Guid BrandId { get; set; }
        public BrandViewModel Brand { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
