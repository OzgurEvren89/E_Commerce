using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.ProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels
{
    public class ProductImageViewModel
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string FileName { get; set; }
        public string Revision { get; set; }//aynı isimli resimlerin tekrar yüklenmesi durumu
        public int SortOrder { get; set; } // resmin ürün içerisindeki sıralaması
        public Guid ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
