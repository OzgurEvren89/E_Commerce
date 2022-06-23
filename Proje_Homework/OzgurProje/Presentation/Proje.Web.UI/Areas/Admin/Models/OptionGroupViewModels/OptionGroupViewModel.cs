using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.OptionsViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;

namespace Proje.Web.UI.Areas.Admin.Models.OptionGroupViewModels
{
    public class OptionGroupViewModel
    {
        public OptionGroupViewModel()
        {
            OptionToProducts = new HashSet<OptionToProductViewModel>();
            Options = new HashSet<OptionsViewModel>();

        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public int SortOrder { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; } 
        public DateTime? CreatedDate { get; set; }
        public ICollection<OptionToProductViewModel> OptionToProducts { get; set; }
        public ICollection<OptionsViewModel> Options { get; set; }

    }
}
