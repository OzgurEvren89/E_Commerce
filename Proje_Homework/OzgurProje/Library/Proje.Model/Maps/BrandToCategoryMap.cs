using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class BrandToCategoryMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<BrandToCategory>(entity =>
            {
                entity.ToTable("BrandToCategories");

                entity.HasExtended();

                entity.Property(x => x.BrandName).HasMaxLength(100).IsRequired(true);
                entity.Property(x => x.CategoryName).HasMaxLength(100).IsRequired(false);


                entity
                     .HasOne(c => c.CreatedUserBrandToCategory)
                     .WithMany(u => u.CreatedBrandToCategories)
                     .HasForeignKey(c => c.CreatedUserId);//foreignKey propertymi tanımladım  
                entity
                    .HasOne(c => c.ModifiedUserBrandToCategory)
                    .WithMany(u => u.ModifiedBrandToCategories)
                    .HasForeignKey(c => c.ModifiedUserId);

                entity
                    .HasOne(c => c.Category)
                    .WithMany(u => u.BrandToCategories)
                    .HasForeignKey(c => c.CategoryId);
                entity
                    .HasOne(c => c.Brand)
                    .WithMany(u => u.BrandToCategories)
                    .HasForeignKey(c => c.BrandId);

            });
        }
    }
}
