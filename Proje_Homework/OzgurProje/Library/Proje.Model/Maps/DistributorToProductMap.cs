using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class DistributorToProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<DistributorToProduct>(entity =>
            {
                entity.ToTable("DistributorToProduct");

                entity.HasExtended();

            

                entity
                  .HasOne(c => c.Product)
                  .WithMany(u => u.DistributorToProducts)
                  .HasForeignKey(c => c.ProductId);

                entity
                  .HasOne(c => c.Distributor)
                  .WithMany(u => u.DistributorToProducts)
                  .HasForeignKey(c => c.DistributorId);


            });
        }
    }
}
