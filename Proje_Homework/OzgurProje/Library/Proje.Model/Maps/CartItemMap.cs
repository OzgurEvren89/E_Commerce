using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class CartItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItem");

                entity.HasExtended();

                entity.Property(x => x.Quantity).IsRequired(true);

                entity
                    .HasOne(c => c.CreatedUserCartItem)
                    .WithMany(u => u.CreatedUserCartItems)
                    .HasForeignKey(c => c.CreatedUserId);

                entity
                   .HasOne(c => c.ModifiedUserCartItem)
                   .WithMany(u => u.ModifiedUserCartItems)
                   .HasForeignKey(c => c.ModifiedUserId);

                entity
                   .HasOne(c => c.Product)
                   .WithMany(u => u.CartItems)
                   .HasForeignKey(c => c.ProductId);

                entity
                  .HasOne(c => c.Cart)
                  .WithMany(u => u.CartItems)
                  .HasForeignKey(c => c.CartId);
            });
        }
    }
}
