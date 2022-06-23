using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class OrderRefundDemandMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderRefundDemand>(entity =>
            {
                entity.ToTable("OrderRefundDemand");

                entity.HasExtended();

                entity.Property(x => x.Reason).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Details).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.ResultStatus).HasMaxLength(50).IsRequired(true);//ilk otomatik ata
                entity.Property(x => x.Fee).IsRequired(true);

                entity
                    .HasOne(c => c.User)
                    .WithMany(u => u.OrderRefundDemands)
                    .HasForeignKey(c => c.UserId);
                entity
                   .HasOne(c => c.Order)
                   .WithMany(u => u.OrderRefundDemands)
                   .HasForeignKey(c => c.OrderId);
                entity
                    .HasOne(c => c.CreatedUserOrderRefundDemand)
                    .WithMany(u => u.CreatedUserOrderRefundDemands)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserOrderRefundDemand)
                   .WithMany(u => u.ModifiedUserOrderRefundDemands)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
