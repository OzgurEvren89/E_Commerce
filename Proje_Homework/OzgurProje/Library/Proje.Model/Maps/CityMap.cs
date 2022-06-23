using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    class CityMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.HasExtended();

                entity.Property(x => x.CityCode).IsRequired(true);
                entity.Property(x => x.CityName).HasMaxLength(50).IsRequired(true);
                   

            });
        }
    }
}
