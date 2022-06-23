using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class ProductDetailMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("ProductDetail");

                entity.HasExtended();

                entity.Property(x => x.Title).HasMaxLength(250).IsRequired(true);
                entity.Property(x => x.Details).HasMaxLength(65535).IsRequired(true);

                entity
                    .HasOne(c => c.Product)
                    .WithMany(u => u.ProductDetails)
                    .HasForeignKey(c => c.ProductId);
            
            });
        }
    }
}
