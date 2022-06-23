using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class SpecGroupMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<SpecGroup>(entity =>
            {
                entity.ToTable("SpecGroup");

                entity.HasExtended();

                entity.Property(x => x.SpecGroupName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.ShortOrder).IsRequired(true);
               
                entity
                   .HasOne(c => c.CreatedUserSpecGroup)
                   .WithMany(u => u.CreatedUserSpecGroups)
                   .HasForeignKey(c => c.CreatedUserId);

                entity
                   .HasOne(c => c.ModifiedUserSpecGroup)
                   .WithMany(u => u.ModifiedUserSpecGroups)
                   .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
