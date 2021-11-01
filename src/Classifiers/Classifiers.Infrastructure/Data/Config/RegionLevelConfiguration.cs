using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data.Config
{
    public class RegionLevelConfiguration : IEntityTypeConfiguration<RegionLevel>
    {
        public void Configure(EntityTypeBuilder<RegionLevel> builder)
        {
            builder.ToTable(DbContextConsts.DbTablePrefix + nameof(RegionLevel));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .IsRequired()
               .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
