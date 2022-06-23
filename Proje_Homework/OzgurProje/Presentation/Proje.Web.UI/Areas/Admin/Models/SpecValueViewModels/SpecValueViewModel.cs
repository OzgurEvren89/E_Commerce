using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;

namespace Proje.Web.UI.Areas.Admin.Models.SpecValueViewModels
{
    public class SpecValueViewModel
    {
        public SpecValueViewModel()
        {
            SpecToProducts = new HashSet<SpecToProductViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public Guid SpecNameId { get; set; }
        public SpecNameViewModel SpecName { get; set; }
        public Guid SpecGroupId { get; set; }
        public SpecGroupViewModel SpecGroup { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<SpecToProductViewModel> SpecToProducts { get; set; }

    }
}
