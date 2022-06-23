using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class PaymentStatusMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("PaymentStatus");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);

                entity
                    .HasOne(c => c.CreatedUserPaymentStatus)
                    .WithMany(u => u.CreatedUserPaymentStatuses)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserPaymentStatus)
                   .WithMany(u => u.ModifiedUserPaymentStatuses)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
