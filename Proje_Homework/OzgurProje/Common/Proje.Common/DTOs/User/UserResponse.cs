using Proje.Common.DTOs.AddressType;
using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.BrandToCategory;
using Proje.Common.DTOs.Cart;
using Proje.Common.DTOs.CartItem;
using Proje.Common.DTOs.CurrencyValue;
using Proje.Common.DTOs.DemandReason;
using Proje.Common.DTOs.DemandStatus;
using Proje.Common.DTOs.FavouritedProduct;
using Proje.Common.DTOs.MemberAddress;
using Proje.Common.DTOs.OptionGroup;
using Proje.Common.DTOs.Options;
using Proje.Common.DTOs.OptionToProduct;
using Proje.Common.DTOs.Order;
using Proje.Common.DTOs.OrderItem;
using Proje.Common.DTOs.OrderRefundDemand;
using Proje.Common.DTOs.Payment;
using Proje.Common.DTOs.PaymentGateway;
using Proje.Common.DTOs.PaymentStatus;
using Proje.Common.DTOs.PaymentType;
using Proje.Common.DTOs.PhoneNumber;
using Proje.Common.DTOs.ProductComment;
using Proje.Common.DTOs.ProductImage;
using Proje.Common.DTOs.ShippingCompany;
using Proje.Common.DTOs.SpecGroup;
using Proje.Common.DTOs.SpecName;
using Proje.Common.DTOs.SpecToProduct;
using Proje.Common.DTOs.SpecValue;
using Proje.Common.Models;
using System;
using System.Collections.Generic;

namespace Proje.Common.DTOs.User
{
    public class UserResponse : BaseDto
    {
        public UserResponse()
        {
            BrandToCategories = new HashSet<BrandToCategoryResponse>();
            ProductImages = new HashSet<ProductImageResponse>();
            SpecNames = new HashSet<SpecNameResponse>();
            SpecGroups = new HashSet<SpecGroupResponse>();
            SpecValues = new HashSet<SpecValueResponse>();
            SpecToProducts = new HashSet<SpecToProductResponse>();
            PaymentGateways = new HashSet<PaymentGatewayResponse>();
            CartItems = new HashSet<CartItemResponse>();
            Carts = new HashSet<CartResponse>();
            Payments = new HashSet<PaymentResponse>();
            PaymentTypes = new HashSet<PaymentTypeResponse>();
            CurrencyValues = new HashSet<CurrencyValueResponse>();
            AddressTypes = new HashSet<AddressTypeResponse>();
            MemberAddresses = new HashSet<MemberAddressResponse>();
            PaymentStatuses = new HashSet<PaymentStatusResponse>();
            Orders = new HashSet<OrderResponse>();
            FavouritedProducts = new HashSet<FavouritedProductResponse>();
            ProductComments = new HashSet<ProductCommentResponse>();
            ShippingCompanies = new HashSet<ShippingCompanyResponse>();
            OptionGroups = new HashSet<OptionGroupResponse>();
            Options = new HashSet<OptionsResponse>();
            OptionToProducts = new HashSet<OptionToProductResponse>();
            OrderItems = new HashSet<OrderItemResponse>();
            PhoneNumbers = new HashSet<PhoneNumberResponse>();
            OrderRefundDemands = new HashSet<OrderRefundDemandResponse>();
            DemandReasons = new HashSet<DemandReasonResponse>();
            DemandStatuses = new HashSet<DemandStatusResponse>();

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string LastIPAdress { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public GetAccessToken AccessToken { get; set; }

       
        public ICollection<BrandToCategoryResponse> BrandToCategories { get; set; }
        public ICollection<ProductImageResponse> ProductImages { get; set; }
        public ICollection<SpecNameResponse> SpecNames { get; set; }
        public ICollection<SpecGroupResponse> SpecGroups { get; set; }
        public ICollection<SpecValueResponse> SpecValues { get; set; }
        public ICollection<SpecToProductResponse> SpecToProducts { get; set; }
        public ICollection<PaymentGatewayResponse> PaymentGateways { get; set; }
        public ICollection<CartItemResponse> CartItems { get; set; }
        public ICollection<CartResponse> Carts{ get; set; }
        public ICollection<PaymentResponse> Payments{ get; set; }
        public ICollection<PaymentTypeResponse> PaymentTypes{ get; set; }
        public ICollection<CurrencyValueResponse> CurrencyValues { get; set; }
        public ICollection<AddressTypeResponse> AddressTypes { get; set; }
        public ICollection<MemberAddressResponse> MemberAddresses { get; set; }
        public ICollection<PaymentStatusResponse> PaymentStatuses { get; set; }
        public ICollection<OrderResponse> Orders { get; set; }
        public ICollection<FavouritedProductResponse> FavouritedProducts { get; set; }
        public ICollection<ProductCommentResponse> ProductComments { get; set; }
        public ICollection<ShippingCompanyResponse> ShippingCompanies { get; set; }
        public ICollection<OptionGroupResponse> OptionGroups { get; set; }
        public ICollection<OptionsResponse> Options { get; set; }
        public ICollection<OptionToProductResponse> OptionToProducts { get; set; }
        public ICollection<OrderItemResponse> OrderItems { get; set; }
        public ICollection<PhoneNumberResponse> PhoneNumbers { get; set; }
        public ICollection<OrderRefundDemandResponse> OrderRefundDemands { get; set; }
        public ICollection<DemandReasonResponse> DemandReasons { get; set; }
        public ICollection<DemandStatusResponse> DemandStatuses { get; set; }
       


    }
}
