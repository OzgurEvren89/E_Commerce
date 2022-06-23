using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proje.Common.DTOs.Product
{
    public class ProductRequest : BaseDto
    {

        public string ProductName { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Price1 { get; set; }
        public int Warranty { get; set; }//garanti süresi       
        public decimal StockAmount { get; set; }
        public string Distributor { get; set; }
        public string Gift { get; set; }
        public string ShortDetails { get; set; }
        public decimal VolumetricWeight { get; set; }

        [Required]
        public Guid BrandId { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}
