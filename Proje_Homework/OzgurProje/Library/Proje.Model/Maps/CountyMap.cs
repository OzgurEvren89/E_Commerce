using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class CountyMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<County>(entity =>
            {
                entity.ToTable("County");

                entity.HasExtended();

                entity.Property(x => x.CountyCode).IsRequired(true);
                entity.Property(x => x.CountyName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.CityCode).IsRequired(true);      

            });
        }
    }
}
