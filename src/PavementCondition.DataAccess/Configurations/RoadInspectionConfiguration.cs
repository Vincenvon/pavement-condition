using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PavementCondition.Entity;

namespace PavementCondition.DataAccess.Configurations
{
    public class RoadInspectionConfiguration : IEntityTypeConfiguration<RoadInspection>
    {
        public void Configure(EntityTypeBuilder<RoadInspection> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Number).HasColumnType("varchar(100)").IsRequired();

            builder.Property(e => e.Engineer).HasColumnType("varchar(200)").IsRequired();

            builder.HasOne<Road>()
                .WithMany()
                .HasForeignKey(e => e.RoadId);
        }
    }
}
