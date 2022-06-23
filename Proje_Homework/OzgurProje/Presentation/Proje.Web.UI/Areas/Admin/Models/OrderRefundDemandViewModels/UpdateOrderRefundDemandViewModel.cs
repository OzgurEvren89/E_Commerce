using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.OrderRefundDemandViewModels
{
    public class UpdateOrderRefundDemandViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "İptal talebi sebebi alanı zorunludur.")]
        public string Reason { get; set; }
        [Required(ErrorMessage = "İptal talebi detayı alanı zorunludur.")]
        public string Details { get; set; }
        [Required(ErrorMessage = "İptal Talebi Sonucu durumu alanı zorunludur.")]
        public string ResultStatus { get; set; }
        [Required(ErrorMessage = "İade miktarı alanı zorunludur.")]
        public decimal Fee { get; set; }
        public Guid OrderId { get; set; }      
        public Guid UserId { get; set; }
      
    }
}
