using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PavementCondition.Entity;

namespace PavementCondition.DataAccess.Configurations
{
    public class DefectTypeConfiguration : IEntityTypeConfiguration<DefectType>
    {
        public void Configure(EntityTypeBuilder<DefectType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).HasColumnType("varchar(100)").IsRequired();

            builder.HasIndex(e => e.Name);
        }
    }
}
