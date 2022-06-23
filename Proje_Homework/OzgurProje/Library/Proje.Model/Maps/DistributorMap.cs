using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model.Maps
{
    public class DistributorMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Distributor>(entity =>
            {
                entity.ToTable("Distributor");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Email).HasMaxLength(255).IsRequired(false);
                entity.Property(x => x.Phone).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.ContactPerson).HasMaxLength(50).IsRequired(false);
         

            });
        }
    }
}
