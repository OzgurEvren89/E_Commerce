using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.InstallmentRateViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.PaymentGatewayViewModels
{
    public class PaymentGatewayViewModel
    {
        public PaymentGatewayViewModel()
        {
            InstallmentRates = new HashSet<InstallmentRateViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<InstallmentRateViewModel> InstallmentRates { get; set; }
    }
}
