using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class OptionsMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Options>(entity =>
            {
                entity.ToTable("Options");

                entity.HasExtended();

                entity.Property(x => x.Title).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.Slug).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.SortOrder).IsRequired(true);

                entity
                    .HasOne(c => c.OptionGroup)
                    .WithMany(u => u.Options)
                    .HasForeignKey(c => c.OptionGroupId);
                entity
                    .HasOne(c => c.CreatedUserOptions)
                    .WithMany(u => u.CreatedUserOptions)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserOptions)
                   .WithMany(u => u.ModifiedUserOptions)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
