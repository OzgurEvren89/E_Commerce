using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels
{
    public class ProductDetailViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
