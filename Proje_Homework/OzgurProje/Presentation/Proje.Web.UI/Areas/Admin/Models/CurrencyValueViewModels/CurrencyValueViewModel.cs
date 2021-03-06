using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.CurrencyValueViewModels
{
    public class CurrencyValueViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public Guid CurrencyId { get; set; }
        public string ShortName { get; set; }
        public DateTime Date { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SalePrice { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
