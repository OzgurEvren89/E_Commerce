using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.CartViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;

namespace Proje.Web.UI.Areas.Admin.Models.CartItemViewModels
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public int Quantity { get; set; }
        public Guid CartId { get; set; }
        public CartViewModel Cart { get; set; }
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
