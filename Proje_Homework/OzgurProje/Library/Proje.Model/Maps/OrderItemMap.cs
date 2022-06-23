using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class OrderItemMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.HasExtended();

                entity.Property(x => x.ProductName).HasMaxLength(255).IsRequired(true);
                entity.Property(x => x.ProductWeight).IsRequired(true);
                entity
                   .HasOne(c => c.Order)
                   .WithMany(u => u.OrderItems)
                   .HasForeignKey(c => c.OrderId);
                entity
                   .HasOne(c => c.Product)
                   .WithMany(u => u.OrderItems)
                   .HasForeignKey(c => c.ProductId);
                entity
                  .HasOne(c => c.User)
                  .WithMany(u => u.OrderItems)
                  .HasForeignKey(c => c.UserId);
                entity
                    .HasOne(c => c.CreatedUserOrderItem)
                    .WithMany(u => u.CreatedUserOrderItems)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserOrderItem)
                   .WithMany(u => u.ModifiedUserOrderItems)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
