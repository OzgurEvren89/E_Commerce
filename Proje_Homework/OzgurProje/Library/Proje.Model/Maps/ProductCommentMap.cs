using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    class ProductCommentMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ProductComment>(entity =>
            {
                entity.ToTable("ProductComment");

                entity.HasExtended();

                entity.Property(x => x.Content).HasMaxLength(65535).IsRequired(true);

                entity
                    .HasOne(c => c.Product)
                    .WithMany(u => u.ProductComments)
                    .HasForeignKey(c => c.ProductId);
                entity
                  .HasOne(c => c.User)
                  .WithMany(u => u.ProductComments)
                  .HasForeignKey(c => c.UserId);

                entity
                    .HasOne(c => c.CreatedUserProductComment)
                    .WithMany(u => u.CreatedUserProductComments)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserProductComment)
                   .WithMany(u => u.ModifiedUserProductComments)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
