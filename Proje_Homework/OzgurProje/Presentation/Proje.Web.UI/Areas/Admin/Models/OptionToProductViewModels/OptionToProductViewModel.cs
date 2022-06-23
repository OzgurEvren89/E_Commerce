using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.OptionGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionsViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;

namespace Proje.Web.UI.Areas.Admin.Models.OptionToProductViewModels
{
    public class OptionToProductViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Guid ParentProductId { get; set; }
        public Guid OptionGroupId { get; set; }
        public OptionGroupViewModel OptionGroup { get; set; }
        public Guid OptionId { get; set; }
        public OptionsViewModel Option { get; set; }
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }      
        public DateTime? CreatedDate { get; set; }
    }
}
