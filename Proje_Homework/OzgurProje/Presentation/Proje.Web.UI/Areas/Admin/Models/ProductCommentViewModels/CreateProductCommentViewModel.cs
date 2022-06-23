using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.ProductCommentViewModels
{
    public class CreateProductCommentViewModel
    {
        public Status Status { get; set; }
        [Required(ErrorMessage = "Yorum alanı zorunludur.")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Ürün alanı zorunludur.")]
        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "Kullanıcı alanı zorunludur.")]
        public Guid UserId { get; set; }
    }
}
