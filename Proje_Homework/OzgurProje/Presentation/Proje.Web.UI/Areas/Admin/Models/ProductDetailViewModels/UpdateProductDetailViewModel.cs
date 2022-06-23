using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels
{
    public class UpdateProductDetailViewModel
    {

        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Detay alanı zorunludur.")]
        public string Details { get; set; }
        public Guid ProductId { get; set; }
    }
}
