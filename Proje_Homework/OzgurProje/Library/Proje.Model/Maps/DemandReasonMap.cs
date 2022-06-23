using Microsoft.EntityFrameworkCore;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.Maps.Base;

namespace Proje.Model.Maps
{
    public class DemandReasonMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<DemandReason>(entity =>
            {
                entity.ToTable("DemandReason");

                entity.HasExtended();

                entity.Property(x => x.Reason).HasMaxLength(50).IsRequired(true);             
                
            });
        }
    }
}
