using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class Cart : CoreEntity
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();    
        }
        public User CreatedUserCart { get; set; }
        public User ModifiedUserCart { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
