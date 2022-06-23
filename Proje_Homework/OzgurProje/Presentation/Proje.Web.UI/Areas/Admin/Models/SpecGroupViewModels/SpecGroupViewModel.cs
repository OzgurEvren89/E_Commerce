using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecValueViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels
{
    public class SpecGroupViewModel
    {
        public SpecGroupViewModel()
        {
            SpecNames = new HashSet<SpecNameViewModel>();
            SpecValues = new HashSet<SpecValueViewModel>();
            SpecToProducts = new HashSet<SpecToProductViewModel>();

        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string SpecGroupName { get; set; }
        public int ShortOrder { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<SpecNameViewModel> SpecNames { get; set; }
        public ICollection<SpecValueViewModel> SpecValues { get; set; }
        public ICollection<SpecToProductViewModel> SpecToProducts { get; set; }

    }
}
