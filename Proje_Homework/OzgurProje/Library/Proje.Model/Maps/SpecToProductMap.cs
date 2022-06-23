using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class SpecToProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<SpecToProduct>(entity =>
            {
                entity.ToTable("SpecToProduct");

                entity.HasExtended();
               
                entity
                      .HasOne(c => c.Product)
                      .WithMany(u => u.SpecToProducts)
                      .HasForeignKey(c => c.ProductId);
                entity
                      .HasOne(c => c.SpecGroup)
                      .WithMany(u => u.SpecToProducts)
                      .HasForeignKey(c => c.SpecGroupId);
                entity
                      .HasOne(c => c.SpecName)
                      .WithMany(u => u.SpecToProducts)
                      .HasForeignKey(c => c.SpecNameId);
                entity
                     .HasOne(c => c.SpecValue)
                     .WithMany(u => u.SpecToProducts)
                     .HasForeignKey(c => c.SpecValueId);
                entity
                     .HasOne(c => c.CreatedUserSpecToProduct)
                     .WithMany(u => u.CreatedUserSpecToProducts)
                     .HasForeignKey(c => c.CreatedUserId);
                entity
                    .HasOne(c => c.ModifiedUserSpecToProduct)
                    .WithMany(u => u.ModifiedUserSpecToProducts)
                    .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
