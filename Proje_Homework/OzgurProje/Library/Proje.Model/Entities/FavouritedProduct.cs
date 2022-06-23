using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class FavouritedProduct : CoreEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public User CreatedUserFavouritedProduct { get; set; }
        public User ModifiedUserFavouritedProduct { get; set; }
    }
}
