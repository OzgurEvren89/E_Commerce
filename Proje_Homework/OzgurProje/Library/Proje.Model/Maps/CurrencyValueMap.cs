using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class CurrencyValueMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<CurrencyValue>(entity =>
            {
                entity.ToTable("CurrencyValue");

                entity.HasExtended();

                entity.Property(x => x.CurrencyId).IsRequired(true);
                entity.Property(x => x.ShortName).HasMaxLength(10).IsRequired(true);
                entity.Property(x => x.Date).IsRequired(true);
                entity.Property(x => x.BuyingPrice).IsRequired(true);
                entity.Property(x => x.SalePrice).IsRequired(true);

                entity
                    .HasOne(c => c.CreatedUserCurrencyValue)
                    .WithMany(u => u.CreatedUserCurrencyValues)
                    .HasForeignKey(c => c.CreatedUserId);
                entity
                   .HasOne(c => c.ModifiedUserCurrencyValue)
                   .WithMany(u => u.ModifiedUserCurrencyValues)
                   .HasForeignKey(c => c.ModifiedUserId);
            });
        }
    }
}
