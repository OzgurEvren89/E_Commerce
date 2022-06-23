using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class Category : CoreEntity
    {
        public Category()
        {
            BrandToCategories = new HashSet<BrandToCategory>();
            Products = new HashSet<Product>();
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

     

        public ICollection<BrandToCategory> BrandToCategories { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
