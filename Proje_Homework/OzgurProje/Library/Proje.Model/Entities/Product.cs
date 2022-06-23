using Proje.Core.Entity;
using System;
using System.Collections.Generic;

namespace Proje.Model.Entities
{
    public class Product : CoreEntity
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
            SpecToProducts = new HashSet<SpecToProduct>();
            CartItems = new HashSet<CartItem>();
            DistributorToProducts = new HashSet<DistributorToProduct>();
            FavouritedProducts = new HashSet<FavouritedProduct>();
            ProductDetails = new HashSet<ProductDetail>();
            ProductComments = new HashSet<ProductComment>();
            OptionToProducts = new HashSet<OptionToProduct>();
            OrderItems = new HashSet<OrderItem>();
        }
        public string ProductName { get; set; }        
        public decimal BuyingPrice { get; set; }
        public decimal Price1 { get; set; }
        public int Warranty { get; set; }//garanti süresi
        public decimal StockAmount { get; set; }
        public string Distributor { get; set; }
        public string Gift { get; set; }
        public string ShortDetails { get; set; }
        public decimal VolumetricWeight { get; set; }


        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }      

        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<SpecToProduct> SpecToProducts { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<DistributorToProduct> DistributorToProducts { get; set; }
        public ICollection<FavouritedProduct> FavouritedProducts { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        public ICollection<OptionToProduct> OptionToProducts { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
