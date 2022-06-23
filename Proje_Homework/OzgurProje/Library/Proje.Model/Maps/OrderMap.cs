using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class OrderMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasExtended();

                entity.Property(x => x.CustomerFirstname).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.CustomerSurname).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.CustomerEmail).HasMaxLength(250).IsRequired(false);
                entity.Property(x => x.CustomerPhone).HasMaxLength(32).IsRequired(false);
                entity.Property(x => x.PaymentTypeName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.PaymentGatewayName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.PaymentGatewayCode).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Amount).IsRequired(true);
                entity.Property(x => x.OrderStatus).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.ErrorMessage).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.GiftNote).HasMaxLength(250).IsRequired(false);
                entity.Property(x => x.ShippingCompanyName).HasMaxLength(250).IsRequired(false);
                entity.Property(x => x.ShippingTrackingCode).HasMaxLength(250).IsRequired(false);

                entity
                   .HasOne(c => c.ShippingAddress)
                   .WithMany(u => u.ShippingAddresses)
                   .HasForeignKey(c => c.ShippingAddressId);

                entity
                   .HasOne(c => c.BillingAddress)
                   .WithMany(u => u.BillingAddresses)
                   .HasForeignKey(c => c.BillingAddressId);

                entity
                    .HasOne(c => c.CreatedUserOrder)
                    .WithMany(u => u.CreatedUserOrders)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserOrder)
                   .WithMany(u => u.ModifiedUserOrders)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
