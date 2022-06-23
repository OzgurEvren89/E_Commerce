using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.FavouritedProductViewModels
{
    public class CreateFavouritedProductViewModel
    {
        
        public Status Status { get; set; }
        [Required(ErrorMessage = "Ürün Adı alanı zorunludur.")]
        public Guid ProductId { get; set; }
       
    }
}
