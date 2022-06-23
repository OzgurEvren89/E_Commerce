using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.PaymentViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.PaymentStatusViewModels
{
    public class PaymentStatusViewModel
    {
        public PaymentStatusViewModel()
        {
            Payments = new HashSet<PaymentViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<PaymentViewModel> Payments { get; set; }
    }
}
