using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class FavouritedProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<FavouritedProduct>(entity =>
            {
                entity.ToTable("FavouritedProduct");

                entity.HasExtended();

                entity
                  .HasOne(c => c.Product)
                  .WithMany(u => u.FavouritedProducts)
                  .HasForeignKey(c => c.ProductId);

                entity
                    .HasOne(c => c.CreatedUserFavouritedProduct)
                    .WithMany(u => u.CreatedUserFavouritedProducts)
                    .HasForeignKey(c => c.CreatedUserId);

                entity
                   .HasOne(c => c.ModifiedUserFavouritedProduct)
                   .WithMany(u => u.ModifiedUserFavouritedProducts)
                   .HasForeignKey(c => c.ModifiedUserId);

               

            });
        }
    }
}
