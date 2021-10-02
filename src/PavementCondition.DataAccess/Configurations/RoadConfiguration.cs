using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PavementCondition.Entity;

namespace PavementCondition.DataAccess.Configurations
{
    public class RoadConfiguration : IEntityTypeConfiguration<Road>
    {
        public void Configure(EntityTypeBuilder<Road> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Number).HasColumnType("varchar(100)").IsRequired();

            builder.Property(e => e.StartPoint).HasColumnType("varchar(100)").IsRequired();

            builder.Property(e => e.EndPoint).HasColumnType("varchar(100)").IsRequired();

            builder.Property(e => e.ServiceOrganization).HasColumnType("varchar(100)").IsRequired();
        }
    }
}