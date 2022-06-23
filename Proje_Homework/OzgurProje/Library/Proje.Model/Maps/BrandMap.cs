using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class BrandMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");

                entity.HasExtended();

                entity.Property(x => x.BrandName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Description).HasMaxLength(255).IsRequired(false);
               
            });
        }
    }
}
