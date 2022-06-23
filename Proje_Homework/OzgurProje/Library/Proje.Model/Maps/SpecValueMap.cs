using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    class SpecValueMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<SpecValue>(entity =>
            {
                entity.ToTable("SpecValue");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Slug).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.SortOrder).IsRequired(true);

                entity
                  .HasOne(c => c.SpecName)
                  .WithMany(u => u.SpecValues)
                  .HasForeignKey(c => c.SpecNameId);

                entity
                     .HasOne(c => c.CreatedUserSpecValue)
                     .WithMany(u => u.CreatedUserSpecValues)
                     .HasForeignKey(c => c.CreatedUserId);

                entity
                   .HasOne(c => c.ModifiedUserSpecValue)
                   .WithMany(u => u.ModifiedUserSpecValues)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
