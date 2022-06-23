using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.OrderItemViewModels
{
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string ProductName { get; set; }
        public decimal ProductWeight { get; set; }
        public Guid OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
