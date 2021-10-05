using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PavementCondition.Entity;

namespace PavementCondition.DataAccess.Configurations
{
    public class RoadDefectConfiguration : IEntityTypeConfiguration<RoadDefect>
    {
        public void Configure(EntityTypeBuilder<RoadDefect> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne<RoadInspection>()
                .WithMany()
                .HasForeignKey(e => e.RoadInspectionId);

            builder.HasOne<DefectType>()
                .WithMany()
                .HasForeignKey(e => e.DefectTypeId);
        }
    }
}
