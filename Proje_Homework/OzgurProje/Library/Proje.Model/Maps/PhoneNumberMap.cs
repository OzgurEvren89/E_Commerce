using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class PhoneNumberMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<PhoneNumber>(entity =>
            {
                entity.ToTable("PhoneNumbers");

                entity.HasExtended();

                entity.Property(x => x.Number).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.PhoneNumberType).HasMaxLength(50).IsRequired(true);

                entity
                    .HasOne(c => c.User)
                    .WithMany(u => u.PhoneNumbers)
                    .HasForeignKey(c => c.UserId);
                entity
                    .HasOne(c => c.CreatedUserPhoneNumber)
                    .WithMany(u => u.CreatedUserPhoneNumbers)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserPhoneNumber)
                   .WithMany(u => u.ModifiedUserPhoneNumbers)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
