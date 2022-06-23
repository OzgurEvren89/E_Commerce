using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class ProductImage : CoreEntity
    {
        public string FileName { get; set; }
        public string Revision { get; set; }//resmin özel adı 
        public int SortOrder { get; set; } // resmin ürün içerisindeki sıralaması
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public User CreatedUserProductImage { get; set; }
        public User ModifiedUserProductImage { get; set; }
    }
}
