using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class UserMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasExtended();

                entity.Property(x => x.FirstName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.LastName).HasMaxLength(100).IsRequired(true);
                entity.Property(x => x.Title).HasMaxLength(100).IsRequired(false);
                entity.Property(x => x.ImageUrl).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Email).HasMaxLength(100).IsRequired(true);
                entity.Property(x => x.Password).HasMaxLength(12).IsRequired(true);
                entity.Property(x => x.LastLogin).IsRequired(false);
                entity.Property(x => x.LastIPAdress).HasMaxLength(15).IsRequired(false);

                entity
                   .HasOne(c => c.CreatedUser)
                   .WithMany(u => u.CreatedUsers)
                   .HasForeignKey(c => c.CreatedUserId);

                entity
                   .HasOne(c => c.ModifiedUser)
                   .WithMany(u => u.ModifiedUsers)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
