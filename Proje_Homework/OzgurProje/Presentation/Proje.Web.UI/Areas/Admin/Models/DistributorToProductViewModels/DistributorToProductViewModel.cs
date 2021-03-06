using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.DistributorViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.DistributorToProductViewModels
{
    public class DistributorToProductViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public Guid DistributorId { get; set; }
        public DistributorViewModel Distributor { get; set; }       
        public DateTime? CreatedDate { get; set; }
    }
}
