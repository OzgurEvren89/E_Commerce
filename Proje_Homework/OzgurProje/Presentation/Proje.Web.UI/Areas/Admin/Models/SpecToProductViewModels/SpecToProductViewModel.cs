using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecValueViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;

namespace Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels
{
    public class SpecToProductViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public Guid SpecGroupId { get; set; }
        public SpecGroupViewModel SpecGroup { get; set; }
        public Guid SpecNameId { get; set; }
        public SpecNameViewModel SpecName { get; set; }
        public Guid SpecValueId { get; set; }
        public SpecValueViewModel SpecValue { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
