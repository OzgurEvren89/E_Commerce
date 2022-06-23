using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.DistributorToProductViewModels
{
    public class UpdateDistributorToProductViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Ürün Id'si alanı zorunludur.")]
        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "Distributor Id'si alanı zorunludur.")]
        public Guid DistributorId { get; set; }
    }
}
