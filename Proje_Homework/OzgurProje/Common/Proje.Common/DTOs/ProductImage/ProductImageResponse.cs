using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.ProductImage
{
    public class ProductImageResponse : BaseDto
    {
        public string FileName { get; set; }
        public string Revision { get; set; }//aynı isimli resimlerin tekrar yüklenmesi durumu
        public int SortOrder { get; set; } // resmin ürün içerisindeki sıralaması
        public Guid ProductId { get; set; }
        public ProductResponse Product { get; set; }

        public Guid UserId { get; set; }
        public UserResponse User { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
