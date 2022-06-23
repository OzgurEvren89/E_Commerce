using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class PaymentTypeMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(250).IsRequired(true);


                entity
                    .HasOne(c => c.CreatedUserPaymentType)
                    .WithMany(u => u.CreatedUserPaymentTypes)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserPaymentType)
                   .WithMany(u => u.ModifiedUserPaymentTypes)
                   .HasForeignKey(c => c.ModifiedUserId);

            });
        }
    }
}
