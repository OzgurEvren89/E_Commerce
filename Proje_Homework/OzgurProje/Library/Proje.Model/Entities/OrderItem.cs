using Proje.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Entities
{
    public class OrderItem : CoreEntity
    {
        public string ProductName { get; set; }
        public decimal ProductWeight { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public User CreatedUserOrderItem { get; set; }
        public User ModifiedUserOrderItem { get; set; }
    }
}
