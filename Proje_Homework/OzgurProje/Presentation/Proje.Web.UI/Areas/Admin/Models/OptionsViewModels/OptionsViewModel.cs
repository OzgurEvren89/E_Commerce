using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.OptionGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.OptionsViewModels
{
    public class OptionsViewModel
    {
        public OptionsViewModel()
        {
            OptionToProducts = new HashSet<OptionToProductViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public Guid OptionGroupId { get; set; }
        public OptionGroupViewModel OptionGroup { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<OptionToProductViewModel> OptionToProducts { get; set; }

    }
}
