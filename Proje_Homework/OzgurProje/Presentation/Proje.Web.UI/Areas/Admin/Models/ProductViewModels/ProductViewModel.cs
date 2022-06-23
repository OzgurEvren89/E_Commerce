using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.BrandViewModels;
using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.CategoryViewModels;
using Proje.Web.UI.Areas.Admin.Models.DistributorToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.FavouritedProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductCommentViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductDetailViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;

namespace Proje.Web.UI.Areas.Admin.Models.ProductViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductImages = new HashSet<ProductImageViewModel>();
            SpecToProducts = new HashSet<SpecToProductViewModel>();
            CartItems = new HashSet<CartItemViewModel>();
            DistributorToProducts = new HashSet<DistributorToProductViewModel>();
            FavouritedProducts = new HashSet<FavouritedProductViewModel>();
            ProductDetails = new HashSet<ProductDetailViewModel>();
            ProductComments = new HashSet<ProductCommentViewModel>();
            OptionToProducts = new HashSet<OptionToProductViewModel>();
            OrderItems = new HashSet<OrderItemViewModel>();

        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string ProductName { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Price1 { get; set; }
        public int Warranty { get; set; }//garanti süresi       
        public decimal StockAmount { get; set; }
        public string Distributor { get; set; }
        public string Gift { get; set; }
        public string ShortDetails { get; set; }
        public decimal VolumetricWeight { get; set; }

        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
        public Guid BrandId { get; set; }
        public BrandViewModel Brand { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<ProductImageViewModel> ProductImages { get; set; }
        public ICollection<SpecToProductViewModel> SpecToProducts { get; set; }
        public ICollection<CartItemViewModel> CartItems { get; set; }
        public ICollection<DistributorToProductViewModel> DistributorToProducts { get; set; }
        public ICollection<FavouritedProductViewModel> FavouritedProducts { get; set; }
        public ICollection<ProductDetailViewModel> ProductDetails { get; set; }
        public ICollection<ProductCommentViewModel> ProductComments { get; set; }
        public ICollection<OptionToProductViewModel> OptionToProducts { get; set; }
        public ICollection<OrderItemViewModel> OrderItems { get; set; }


    }
}
