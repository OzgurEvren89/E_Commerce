using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class PaymentGatewayMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<PaymentGateway>(entity =>
            {
                entity.ToTable("PaymentGateway");

                entity.HasExtended();

                entity.Property(x => x.Code).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Name).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.SortOrder).IsRequired(true);

                entity
                    .HasOne(c => c.CreatedUserPaymentGateway)
                    .WithMany(u => u.CreatedUserPaymentGateways)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserPaymentGateway)
                   .WithMany(u => u.ModifiedUserPaymentGateways)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
