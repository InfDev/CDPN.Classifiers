using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data.Config
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(DbContextConsts.DbTablePrefix + nameof(Country));
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Alpha2).IsUnique();
            builder.HasIndex(e => e.Alpha3).IsUnique();

            builder.Property(e => e.Id)
               .IsRequired()
               .ValueGeneratedNever();

            builder.Property(e => e.Alpha2)
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength();

            builder.Property(e => e.Alpha3)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength();

            builder.Property(e => e.Group)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.CurrencyId)
                .HasMaxLength(3);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
