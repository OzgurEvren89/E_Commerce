using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.DistributorToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.DistributorViewModels
{
    public class DistributorViewModel
    {
        public DistributorViewModel()
        {
            DistributorToProducts = new HashSet<DistributorToProductViewModel>();

        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }      
        public DateTime? CreatedDate { get; set; }

        public ICollection<DistributorToProductViewModel> DistributorToProducts { get; set; }

    }
}
