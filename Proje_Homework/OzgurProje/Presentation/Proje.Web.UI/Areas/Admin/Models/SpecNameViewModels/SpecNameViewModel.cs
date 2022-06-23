using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecValueViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;

namespace Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels
{
    public class SpecNameViewModel
    {
        public SpecNameViewModel()
        {
            SpecValues = new HashSet<SpecValueViewModel>();
            SpecToProducts = new HashSet<SpecToProductViewModel>();

        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int ShortOrder { get; set; }
        public Guid SpecGroupId { get; set; }
        public SpecGroupViewModel SpecGroup { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<SpecValueViewModel> SpecValues { get; set; }
        public ICollection<SpecToProductViewModel> SpecToProducts { get; set; }

    }
}
