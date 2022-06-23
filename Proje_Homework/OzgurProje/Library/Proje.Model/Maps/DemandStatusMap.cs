using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class DemandStatusMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<DemandStatus>(entity =>
            {
                entity.ToTable("DemandStatus");

                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);

            });
        }
    }
}
