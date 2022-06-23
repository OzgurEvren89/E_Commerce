using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class CartMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {

            builder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasExtended();              

                entity
                    .HasOne(c => c.CreatedUserCart)
                    .WithMany(u => u.CreatedUserCarts)
                    .HasForeignKey(c => c.CreatedUserId);

                entity
                   .HasOne(c => c.ModifiedUserCart)
                   .WithMany(u => u.ModifiedUserCarts)
                   .HasForeignKey(c => c.ModifiedUserId);
              
            });
        }
    }
}
