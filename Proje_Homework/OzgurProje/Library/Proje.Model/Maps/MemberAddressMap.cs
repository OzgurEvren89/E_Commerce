using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class MemberAddressMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<MemberAddress>(entity =>
            {
                entity.ToTable("MemberAddress");

                entity.HasExtended();

                entity.Property(x => x.UserName).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.UserSurName).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.UserPhoneNumber).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.TCLD).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.TCLD).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.TaxNumber).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.TaxOffice).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.AddressName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.AddressTypeId).IsRequired(true);
                entity.Property(x => x.CityCode).IsRequired(true);
                entity.Property(x => x.CountyCode).IsRequired(true);
                entity.Property(x => x.Address).HasMaxLength(255).IsRequired(true);

                entity
                    .HasOne(c => c.CreatedUserMemberAddress)
                    .WithMany(u => u.CreatedUserMemberAddresses)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserMemberAddress)
                   .WithMany(u => u.ModifiedUserMemberAddresses)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
