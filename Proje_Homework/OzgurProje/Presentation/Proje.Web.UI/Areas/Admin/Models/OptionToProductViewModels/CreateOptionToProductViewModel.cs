using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.OptionToProductViewModels
{
    public class CreateOptionToProductViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "Ana Ürün Id'sini girmeniz zorunludur.")]
        public Guid ParentProductId { get; set; }
        [Required(ErrorMessage = "Varyant Grubu Id'sini girmeniz zorunludur.")]
        public Guid OptionGroupId { get; set; }
        [Required(ErrorMessage = "Varyant Id'sini girmeniz zorunludur.")]
        public Guid OptionId { get; set; }
        [Required(ErrorMessage = "Ürün Id'sini girmeniz zorunludur.")]
        public Guid ProductId { get; set; }
    }
}
