using Proje.Core.Entity;
using System;
using System.Collections.Generic;

namespace Proje.Model.Entities
{
    public class User : CoreEntity
    {
        public User()
        {
            CreatedUsers = new HashSet<User>();
            ModifiedUsers = new HashSet<User>();           

            CreatedBrandToCategories = new HashSet<BrandToCategory>();
            ModifiedBrandToCategories = new HashSet<BrandToCategory>();           

            CreatedUserProductImages = new HashSet<ProductImage>();
            ModifiedUserProductImages = new HashSet<ProductImage>();

            CreatedUserSpecNames = new HashSet<SpecName>();
            ModifiedUserSpecNames = new HashSet<SpecName>();

            CreatedUserSpecGroups = new HashSet<SpecGroup>();
            ModifiedUserSpecGroups = new HashSet<SpecGroup>();

            CreatedUserSpecValues = new HashSet<SpecValue>();
            ModifiedUserSpecValues = new HashSet<SpecValue>();

            CreatedUserSpecToProducts = new HashSet<SpecToProduct>();
            ModifiedUserSpecToProducts = new HashSet<SpecToProduct>();

            CreatedUserPaymentGateways = new HashSet<PaymentGateway>();
            ModifiedUserPaymentGateways = new HashSet<PaymentGateway>();   

            CreatedUserCartItems = new HashSet<CartItem>();
            ModifiedUserCartItems = new HashSet<CartItem>();

            CreatedUserCarts = new HashSet<Cart>();
            ModifiedUserCarts = new HashSet<Cart>();

            CreatedUserPayments = new HashSet<Payment>();
            ModifiedUserPayments = new HashSet<Payment>();


            CreatedUserPaymentTypes = new HashSet<PaymentType>();
            ModifiedUserPaymentTypes = new HashSet<PaymentType>();


            CreatedUserCurrencyValues = new HashSet<CurrencyValue>();
            ModifiedUserCurrencyValues = new HashSet<CurrencyValue>();      

            CreatedUserAddressTypes = new HashSet<AddressType>();
            ModifiedUserAddressTypes = new HashSet<AddressType>();

            CreatedUserMemberAddresses = new HashSet<MemberAddress>();
            ModifiedUserMemberAddresses = new HashSet<MemberAddress>();

            CreatedUserOrders = new HashSet<Order>();
            ModifiedUserOrders = new HashSet<Order>();

           
            CreatedUserFavouritedProducts = new HashSet<FavouritedProduct>();
            CreatedUserFavouritedProducts = new HashSet<FavouritedProduct>();         

            ProductComments = new HashSet<ProductComment>();
            CreatedUserProductComments = new HashSet<ProductComment>();
            ModifiedUserProductComments = new HashSet<ProductComment>();

            CreatedUserShippingCompanys = new HashSet<ShippingCompany>();
            ModifiedUserShippingCompanys = new HashSet<ShippingCompany>();

            CreatedUserOptions = new HashSet<Options>();
            ModifiedUserOptions = new HashSet<Options>();

            CreatedUserOptionGroups = new HashSet<OptionGroup>();
            ModifiedUserOptionGroups = new HashSet<OptionGroup>();

            CreatedUserOptionToProducts = new HashSet<OptionToProduct>();
            ModifiedUserOptionToProducts = new HashSet<OptionToProduct>();

            OrderItems = new HashSet<OrderItem>();
            CreatedUserOrderItems = new HashSet<OrderItem>();
            ModifiedUserOrderItems = new HashSet<OrderItem>();

            PhoneNumbers = new HashSet<PhoneNumber>();
            CreatedUserPhoneNumbers = new HashSet<PhoneNumber>();
            ModifiedUserPhoneNumbers = new HashSet<PhoneNumber>();

            OrderRefundDemands = new HashSet<OrderRefundDemand>();
            CreatedUserOrderRefundDemands = new HashSet<OrderRefundDemand>();
            ModifiedUserOrderRefundDemands = new HashSet<OrderRefundDemand>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastIPAdress { get; set; }
        public DateTime? LastLogin { get; set; }
        public User CreatedUser { get; set; }
        public User ModifiedUser { get; set; }


        public ICollection<User> CreatedUsers { get; set; }
        public ICollection<User> ModifiedUsers { get; set; }         

        public ICollection<BrandToCategory> CreatedBrandToCategories { get; set; }
        public ICollection<BrandToCategory> ModifiedBrandToCategories { get; set; }
    
        public ICollection<ProductImage> CreatedUserProductImages { get; set; }
        public ICollection<ProductImage> ModifiedUserProductImages { get; set; }     

        public ICollection<SpecName> CreatedUserSpecNames { get; set; }
        public ICollection<SpecName> ModifiedUserSpecNames { get; set; }

        public ICollection<SpecGroup> CreatedUserSpecGroups { get; set; }
        public ICollection<SpecGroup> ModifiedUserSpecGroups { get; set; }

        public ICollection<SpecValue> CreatedUserSpecValues { get; set; }
        public ICollection<SpecValue> ModifiedUserSpecValues { get; set; }

        public ICollection<SpecToProduct> CreatedUserSpecToProducts { get; set; }
        public ICollection<SpecToProduct> ModifiedUserSpecToProducts { get; set; }

        public ICollection<PaymentGateway> CreatedUserPaymentGateways { get; set; }
        public ICollection<PaymentGateway> ModifiedUserPaymentGateways { get; set; }   

        public ICollection<CartItem> CreatedUserCartItems { get; set; }
        public ICollection<CartItem> ModifiedUserCartItems { get; set; }

        public ICollection<Cart> CreatedUserCarts { get; set; }
        public ICollection<Cart> ModifiedUserCarts { get; set; }

        public ICollection<Payment> CreatedUserPayments { get; set; }
        public ICollection<Payment> ModifiedUserPayments { get; set; }

        public ICollection<PaymentType> CreatedUserPaymentTypes { get; set; }
        public ICollection<PaymentType> ModifiedUserPaymentTypes { get; set; }

        public ICollection<CurrencyValue> CreatedUserCurrencyValues { get; set; }
        public ICollection<CurrencyValue> ModifiedUserCurrencyValues { get; set; }      

        public ICollection<AddressType> CreatedUserAddressTypes { get; set; }
        public ICollection<AddressType> ModifiedUserAddressTypes { get; set; }

        public ICollection<MemberAddress> CreatedUserMemberAddresses { get; set; }
        public ICollection<MemberAddress> ModifiedUserMemberAddresses { get; set; }

        public ICollection<PaymentStatus> CreatedUserPaymentStatuses { get; set; }
        public ICollection<PaymentStatus> ModifiedUserPaymentStatuses { get; set; }

        public ICollection<Order> CreatedUserOrders { get; set; }
        public ICollection<Order> ModifiedUserOrders { get; set; }
     
        public ICollection<FavouritedProduct> CreatedUserFavouritedProducts { get; set; }
        public ICollection<FavouritedProduct> ModifiedUserFavouritedProducts { get; set; }     

        public ICollection<ProductComment> ProductComments { get; set; }
        public ICollection<ProductComment> CreatedUserProductComments { get; set; }
        public ICollection<ProductComment> ModifiedUserProductComments { get; set; }

        public ICollection<ShippingCompany> CreatedUserShippingCompanys { get; set; }
        public ICollection<ShippingCompany> ModifiedUserShippingCompanys { get; set; }

        public ICollection<Options> CreatedUserOptions { get; set; }
        public ICollection<Options> ModifiedUserOptions { get; set; }

        public ICollection<OptionGroup> CreatedUserOptionGroups { get; set; }
        public ICollection<OptionGroup> ModifiedUserOptionGroups { get; set; }

        public ICollection<OptionToProduct> CreatedUserOptionToProducts { get; set; }
        public ICollection<OptionToProduct> ModifiedUserOptionToProducts { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<OrderItem> CreatedUserOrderItems { get; set; }
        public ICollection<OrderItem> ModifiedUserOrderItems { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public ICollection<PhoneNumber> CreatedUserPhoneNumbers { get; set; }
        public ICollection<PhoneNumber> ModifiedUserPhoneNumbers { get; set; }

        public ICollection<OrderRefundDemand> OrderRefundDemands { get; set; }
        public ICollection<OrderRefundDemand> CreatedUserOrderRefundDemands { get; set; }
        public ICollection<OrderRefundDemand> ModifiedUserOrderRefundDemands { get; set; }

    }
}
