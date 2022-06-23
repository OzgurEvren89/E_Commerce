using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class SpecNameMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {

            builder.Entity<SpecName>(entity =>
            {
                entity.ToTable("SpecName");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Slug).HasMaxLength(255).IsRequired(false);

                entity
                  .HasOne(c => c.SpecGroup)
                  .WithMany(u => u.SpecNames)
                  .HasForeignKey(c => c.SpecGroupId);

                entity
                     .HasOne(c => c.CreatedUserSpecName)
                     .WithMany(u => u.CreatedUserSpecNames)
                     .HasForeignKey(c => c.CreatedUserId);

                entity
                   .HasOne(c => c.ModifiedUserSpecName)
                   .WithMany(u => u.ModifiedUserSpecNames)
                   .HasForeignKey(c => c.ModifiedUserId);

            });

        }
    }
}
