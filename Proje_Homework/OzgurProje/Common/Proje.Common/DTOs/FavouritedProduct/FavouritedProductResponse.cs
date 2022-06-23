using Proje.Common.DTOs.Base;
using Proje.Common.DTOs.Product;
using Proje.Common.DTOs.User;
using System;

namespace Proje.Common.DTOs.FavouritedProduct
{
    public class FavouritedProductResponse : BaseDto
    {
        public Guid ProductId { get; set; }
        public ProductResponse Product { get; set; }
        public Guid UserId { get; set; }
        public UserResponse User { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
