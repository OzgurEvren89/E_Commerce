using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class ShippingCompanyMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<ShippingCompany>(entity =>
            {
                entity.ToTable("ShippingCompanys");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.ExtraPrice).IsRequired(true);
                entity.Property(x => x.ExtraVolumetricWeightPrice).IsRequired(true);
                entity.Property(x => x.FreeShipmentOrderPrice).IsRequired(true);
                entity.Property(x => x.FreeShipmentOrderPrice).IsRequired(true);

                entity
                    .HasOne(c => c.CreatedUserShippingCompany)
                    .WithMany(u => u.CreatedUserShippingCompanys)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserShippingCompany)
                   .WithMany(u => u.ModifiedUserShippingCompanys)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
