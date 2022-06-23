using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class InstallmentRateMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<InstallmentRate>(entity =>
            {
                entity.ToTable("InstallmentRate");

                entity.HasExtended();

                entity.Property(x => x.Installment).IsRequired(true);
                entity.Property(x => x.Rate).IsRequired(true);

                entity
                   .HasOne(c => c.PaymentGateway)
                   .WithMany(u => u.InstallmentRates)
                   .HasForeignKey(c => c.PaymentGatewayId);

             
            });
        }
    }
}
