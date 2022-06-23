using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Cart;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using System;

namespace Proje.Common.DTOs.CartItem
{
    public class CartItemResponse : BaseDto
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public ProductResponse Product { get; set; }
        public Guid CartId { get; set; }
        public CartResponse Cart { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
