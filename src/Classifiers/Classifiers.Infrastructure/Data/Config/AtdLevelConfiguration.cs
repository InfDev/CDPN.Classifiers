using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data.Config
{
    public class AtdLevelConfiguration : IEntityTypeConfiguration<AtdLevel>
    {
        public void Configure(EntityTypeBuilder<AtdLevel> builder)
        {
            builder.ToTable(DbContextConsts.DbTablePrefix + nameof(AtdLevel));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .IsRequired()
               .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.InUnitIdStartIndex)
                .IsRequired();

            builder.Property(e => e.InUnitIdEndIndex)
                .IsRequired();
        }
    }
}
