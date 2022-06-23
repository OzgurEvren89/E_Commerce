using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class OptionToProductMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OptionToProduct>(entity =>
            {
                entity.ToTable("OptionToProduct");

                entity.HasExtended();

                entity.Property(x => x.ParentProductId).IsRequired(true);

                entity
                    .HasOne(c => c.Product)
                    .WithMany(u => u.OptionToProducts)
                    .HasForeignKey(c => c.ProductId);
                entity
                    .HasOne(c => c.OptionGroup)
                    .WithMany(u => u.OptionToProducts)
                    .HasForeignKey(c => c.OptionGroupId);
                entity
                    .HasOne(c => c.Option)
                    .WithMany(u => u.OptionToProducts)
                    .HasForeignKey(c => c.OptionId);
                entity
                    .HasOne(c => c.CreatedUserOptionToProduct)
                    .WithMany(u => u.CreatedUserOptionToProducts)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserOptionToProduct)
                   .WithMany(u => u.ModifiedUserOptionToProducts)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
