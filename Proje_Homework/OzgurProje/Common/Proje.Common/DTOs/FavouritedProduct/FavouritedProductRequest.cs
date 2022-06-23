using Proje.Common.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Common.DTOs.FavouritedProduct
{
    public class FavouritedProductRequest : BaseDto
    {
        public Guid ProductId { get; set; }

    }
}
