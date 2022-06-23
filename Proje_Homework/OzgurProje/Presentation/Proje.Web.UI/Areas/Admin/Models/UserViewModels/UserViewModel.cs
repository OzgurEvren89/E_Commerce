using Proje.Common.Enums;
using Proje.Web.UI.Areas.Admin.Models.AddressTypeViewModels;
using Proje.Web.UI.Areas.Admin.Models.BrandToCategoryViewModels;
using Proje.Web.UI.Areas.Admin.Models.CartItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.CartViewModels;
using Proje.Web.UI.Areas.Admin.Models.CurrencyValueViewModels;
using Proje.Web.UI.Areas.Admin.Models.FavouritedProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionsViewModels;
using Proje.Web.UI.Areas.Admin.Models.OptionToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderItemViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderRefundDemandViewModels;
using Proje.Web.UI.Areas.Admin.Models.OrderViewModels;
using Proje.Web.UI.Areas.Admin.Models.PaymentGatewayViewModels;
using Proje.Web.UI.Areas.Admin.Models.PaymentStatusViewModels;
using Proje.Web.UI.Areas.Admin.Models.PaymentTypeViewModels;
using Proje.Web.UI.Areas.Admin.Models.PaymentViewModels;
using Proje.Web.UI.Areas.Admin.Models.PhoneNumberViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductCommentViewModels;
using Proje.Web.UI.Areas.Admin.Models.ProductImageViewModels;
using Proje.Web.UI.Areas.Admin.Models.ShippingCompanyViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecGroupViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecNameViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecToProductViewModels;
using Proje.Web.UI.Areas.Admin.Models.SpecValueViewModels;
using System;
using System.Collections.Generic;

namespace Proje.Web.UI.Areas.Admin.Models.UserViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            BrandToCategories = new HashSet<BrandToCategoryViewModel>();
            ProductImageViewModels = new HashSet<ProductImageViewModel>();
            SpecNames = new HashSet<SpecNameViewModel>();
            SpecGroups = new HashSet<SpecGroupViewModel>();
            SpecValues = new HashSet<SpecValueViewModel>();
            SpecToProducts = new HashSet<SpecToProductViewModel>();
            PaymentGateways = new HashSet<PaymentGatewayViewModel>();
            CartItems = new HashSet<CartItemViewModel>();
            Carts = new HashSet<CartViewModel>();
            Payments = new HashSet<PaymentViewModel>();
            PaymentTypes = new HashSet<PaymentTypeViewModel>();
            CurrencyValues = new HashSet<CurrencyValueViewModel>();
            AddressTypes = new HashSet<AddressTypeViewModel>();
            PaymentStatuses = new HashSet<PaymentStatusViewModel>();
            Orders = new HashSet<OrderViewModel>();
            FavouritedProducts = new HashSet<FavouritedProductViewModel>();
            ProductComments = new HashSet<ProductCommentViewModel>();
            ShippingCompanies = new HashSet<ShippingCompanyViewModel>();
            OptionGroups = new HashSet<OptionGroupViewModel>();
            Options = new HashSet<OptionsViewModel>();
            OptionToProducts = new HashSet<OptionToProductViewModel>();
            OrderItems = new HashSet<OrderItemViewModel>();
            PhoneNumbers = new HashSet<PhoneNumberViewModel>();
            OrderRefundDemands = new HashSet<OrderRefundDemandViewModel>();
        }
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string LastIPAdress { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public ICollection<BrandToCategoryViewModel> BrandToCategories { get; set; }
        public ICollection<ProductImageViewModel> ProductImageViewModels { get; set; }
        public ICollection<SpecNameViewModel> SpecNames { get; set; }
        public ICollection<SpecGroupViewModel> SpecGroups { get; set; }
        public ICollection<SpecValueViewModel> SpecValues { get; set; }
        public ICollection<SpecToProductViewModel> SpecToProducts { get; set; }
        public ICollection<PaymentGatewayViewModel> PaymentGateways { get; set; }
        public ICollection<CartItemViewModel> CartItems { get; set; }
        public ICollection<CartViewModel> Carts { get; set; }
        public ICollection<PaymentViewModel> Payments { get; set; }
        public ICollection<PaymentTypeViewModel> PaymentTypes { get; set; }
        public ICollection<CurrencyValueViewModel> CurrencyValues { get; set; }
        public ICollection<AddressTypeViewModel> AddressTypes { get; set; }
        public ICollection<PaymentStatusViewModel> PaymentStatuses { get; set; }
        public ICollection<OrderViewModel> Orders { get; set; }
        public ICollection<FavouritedProductViewModel> FavouritedProducts { get; set; }
        public ICollection<ProductCommentViewModel> ProductComments { get; set; }
        public ICollection<ShippingCompanyViewModel> ShippingCompanies { get; set; }
        public ICollection<OptionGroupViewModel> OptionGroups { get; set; }
        public ICollection<OptionsViewModel> Options { get; set; }
        public ICollection<OptionToProductViewModel> OptionToProducts { get; set; }
        public ICollection<OrderItemViewModel> OrderItems { get; set; }
        public ICollection<PhoneNumberViewModel> PhoneNumbers { get; set; }
        public ICollection<OrderRefundDemandViewModel> OrderRefundDemands { get; set; }

    }
}
