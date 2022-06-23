using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    class ProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                entity.HasExtended();
                
                entity.Property(x => x.ProductName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.BuyingPrice).IsRequired(true);
                entity.Property(x => x.Price1).IsRequired(true);
                entity.Property(x => x.Warranty).IsRequired(true);
                entity.Property(x => x.StockAmount).IsRequired(true);
                entity.Property(x => x.Distributor).HasMaxLength(100).IsRequired(false);
                entity.Property(x => x.Gift).HasMaxLength(100).IsRequired(false);
                entity.Property(x => x.ShortDetails).HasMaxLength(200).IsRequired(false);
                entity.Property(x => x.VolumetricWeight).IsRequired(true);
                                       
                entity
                  .HasOne(c => c.Brand)
                  .WithMany(u => u.Products)
                  .HasForeignKey(c => c.BrandId);

                entity
                  .HasOne(c => c.Category)
                  .WithMany(u => u.Products)
                  .HasForeignKey(c => c.CategoryId);


            });
        }
    }
}
