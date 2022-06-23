using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class AddressTypeMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<AddressType>(entity =>
            {
                entity.ToTable("AddressType");

                entity.HasExtended();

                entity.Property(x => x.TypeName).IsRequired(true);
               

                entity

                    .HasOne(c => c.CreatedUserAddressType)
                    .WithMany(u => u.CreatedUserAddressTypes)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserAddressType)
                   .WithMany(u => u.ModifiedUserAddressTypes)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
