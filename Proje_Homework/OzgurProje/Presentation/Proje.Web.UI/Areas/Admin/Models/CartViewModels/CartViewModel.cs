using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.CartViewModels
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems = new HashSet<CartItemViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<CartItemViewModel> CartItems { get; set; }
    }
}
