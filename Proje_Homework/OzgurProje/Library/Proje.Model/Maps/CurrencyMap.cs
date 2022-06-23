using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    class CurrencyMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.HasExtended();

                entity.Property(x => x.ShortName).HasMaxLength(10).IsRequired(true);
                entity.Property(x => x.LongName).HasMaxLength(50).IsRequired(true);
        
            });
        }
    }
}
