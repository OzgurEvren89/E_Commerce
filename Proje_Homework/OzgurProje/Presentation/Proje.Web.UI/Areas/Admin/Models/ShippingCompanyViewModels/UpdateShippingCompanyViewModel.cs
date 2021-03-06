using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.ShippingCompanyViewModels
{
    public class UpdateShippingCompanyViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Kargo Firması Adı alanı zorunludur.")]
        public string Name { get; set; }
        public decimal ExtraPrice { get; set; }
        public decimal ExtraVolumetricWeightPrice { get; set; }
        public decimal FreeShipmentOrderPrice { get; set; }
    }
}
