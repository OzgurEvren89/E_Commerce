using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.OrderItemViewModels
{
    public class UpdateOrderItemViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Ürün Adı alanı zorunludur.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Ürünün Ağırlığı alanı zorunludur.")]
        public decimal ProductWeight { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }


    }
}
