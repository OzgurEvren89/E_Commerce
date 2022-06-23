using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.CartItem;
using Proje.Common.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.Cart
{
    public class CartResponse : BaseDto
    {
        public CartResponse()
        {
            CartItems = new HashSet<CartItemResponse>();
        }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }

        public ICollection<CartItemResponse> CartItems { get; set; }
    }
}
