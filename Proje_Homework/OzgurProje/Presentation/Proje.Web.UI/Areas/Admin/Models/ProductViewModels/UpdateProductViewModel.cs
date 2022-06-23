using Proje.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.ProductViewModels
{
    public class UpdateProductViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        [Required(ErrorMessage = "Ürün Adı alanı zorunludur.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Ürün Alış Fiyatı alanı zorunludur.")]
        public decimal BuyingPrice { get; set; }
        [Required(ErrorMessage = "Ürün ilk Satış Fiyatı alanı zorunludur.")]
        public decimal Price1 { get; set; }
        [Required(ErrorMessage = "Ürün Garanti Süresi alanı zorunludur.")]
        public int Warranty { get; set; }//garanti süresi        
        [Required(ErrorMessage = "Ürün Stok Miktarı alanı zorunludur.")]
        public decimal StockAmount { get; set; }       
        public string Distributor { get; set; }
        public string Gift { get; set; }
        public string MetaKeyWords { get; set; }
        public string ShortDetails { get; set; }       
        public decimal VolumetricWeight { get; set; }

        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }

    }
}
