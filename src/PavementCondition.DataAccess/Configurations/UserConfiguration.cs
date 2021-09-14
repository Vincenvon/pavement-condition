using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PavementCondition.Entity;

namespace PavementCondition.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email).HasColumnType("integer");

            builder.Property(e => e.LastName).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.FirstName).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Username).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.PasswordHash).HasColumnType("varchar(100)").IsRequired();

            builder.HasIndex(e => e.Email);
        }
    }
}