using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Brand;
using Proje.Common.DTOs.CartItem;
using Proje.Common.DTOs.Category;
using Proje.Common.DTOs.DistributorToProduct;
using Proje.Common.DTOs.FavouritedProduct;
using Proje.Common.DTOs.OptionToProduct;
using Proje.Common.DTOs.OrderItem;
using Proje.Common.DTOs.ProductComment;
using Proje.Common.DTOs.ProductDetail;
using Proje.Common.DTOs.ProductImage;
using Proje.Common.DTOs.SpecToProduct;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Product
{
    public class ProductResponse : BaseDto
    {
        public ProductResponse()
        {
            ProductImages = new HashSet<ProductImageResponse>();
            SpecToProducts = new HashSet<SpecToProductResponse>();
            CartItems = new HashSet<CartItemResponse>();
            DistributorToProducts = new HashSet<DistributorToProductResponse>();
            FavouritedProducts = new HashSet<FavouritedProductResponse>();
            ProductDetails = new HashSet<ProductDetailResponse>();
            ProductComments = new HashSet<ProductCommentResponse>();
            OptionToProducts = new HashSet<OptionToProductResponse>();
            OrderItems = new HashSet<OrderItemResponse>();
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
        public BrandResponse Brand { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryResponse Category { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<ProductImageResponse> ProductImages { get; set; }
        public ICollection<SpecToProductResponse> SpecToProducts { get; set; }
        public ICollection<CartItemResponse> CartItems { get; set; }
        public ICollection<DistributorToProductResponse> DistributorToProducts { get; set; }
        public ICollection<FavouritedProductResponse> FavouritedProducts { get; set; }
        public ICollection<ProductDetailResponse> ProductDetails { get; set; }
        public ICollection<ProductCommentResponse> ProductComments { get; set; }
        public ICollection<OptionToProductResponse> OptionToProducts { get; set; }
        public ICollection<OrderItemResponse> OrderItems { get; set; }


    }
}
