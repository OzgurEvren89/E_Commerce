using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels
{
    public class CreateProductImageViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        //[Required(ErrorMessage = "Dosya Adı alanı zorunludur.")]
        public string FileName { get; set; }
        [Required(ErrorMessage = "Revision alanı zorunludur.")]
        public string Revision { get; set; }//aynı isimli resimlerin tekrar yüklenmesi durumu
        public int SortOrder { get; set; } // resmin ürün içerisindeki sıralaması
        [Required(ErrorMessage = "ProductId alanı zorunludur.")]
        public Guid ProductId { get; set; }
    }
}
