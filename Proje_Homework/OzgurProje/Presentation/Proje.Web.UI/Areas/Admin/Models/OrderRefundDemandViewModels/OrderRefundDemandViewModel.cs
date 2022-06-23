using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.OrderRefundDemandViewModels
{
    public class OrderRefundDemandViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Reason { get; set; }
        public string Details { get; set; }
        public string ResultStatus { get; set; }
        public decimal Fee { get; set; }
        public Guid OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
