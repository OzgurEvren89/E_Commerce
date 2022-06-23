using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class ProductImageMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImages");

                entity.HasExtended();
                entity.Property(x => x.FileName).HasMaxLength(250).IsRequired(false);
                entity.Property(x => x.Revision).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.SortOrder).IsRequired(true);

                entity
                   .HasOne(c => c.CreatedUserProductImage)
                   .WithMany(u => u.CreatedUserProductImages)
                   .HasForeignKey(c => c.CreatedUserId);

                entity
                   .HasOne(c => c.ModifiedUserProductImage)
                   .WithMany(u => u.ModifiedUserProductImages)
                   .HasForeignKey(c => c.ModifiedUserId);
                entity
                  .HasOne(c => c.Product)
                  .WithMany(u => u.ProductImages)
                  .HasForeignKey(c => c.ProductId);

            });
        }
    }
}
