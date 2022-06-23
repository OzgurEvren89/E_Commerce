using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class OptionGroupMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OptionGroup>(entity =>
            {
                entity.ToTable("OptionGroup");

                entity.HasExtended();

                entity.Property(x => x.Title).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Slug).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.SortOrder).IsRequired(true);
                entity
                    .HasOne(c => c.CreatedUserOptionGroup)
                    .WithMany(u => u.CreatedUserOptionGroups)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserOptionGroup)
                   .WithMany(u => u.ModifiedUserOptionGroups)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
