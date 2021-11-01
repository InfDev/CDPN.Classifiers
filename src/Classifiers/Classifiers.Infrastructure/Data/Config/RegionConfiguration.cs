using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data.Config
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable(DbContextConsts.DbTablePrefix + nameof(Region));
            builder.HasKey(e => e.Id);

            builder
                .HasOne(r => r.RegionLevel)
                .WithMany(l => l.Regions)
                .HasForeignKey(r => r.RegionLevelId);

            builder.Property(e => e.Id)
               .IsRequired()
               .ValueGeneratedNever();

            builder.Property(e => e.CountryClassifierId)
               .IsRequired();

            builder.Property(e => e.CountryId)
               .IsRequired();

            builder.Property(e => e.RegionLevelId)
               .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Center)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
