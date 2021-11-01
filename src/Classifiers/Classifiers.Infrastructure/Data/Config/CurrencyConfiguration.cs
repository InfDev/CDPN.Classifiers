using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data.Config
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable(DbContextConsts.DbTablePrefix + nameof(Currency));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .IsRequired()
               .ValueGeneratedNever();

            builder.HasIndex(e => e.NumericCode).IsUnique();

            builder.Property(e => e.NumericCode)
                .IsRequired();

            //builder.Property(e => e.MinorUnit)
            //    .IsRequired()
            //    .HasDefaultValue(2);

            builder.Property(e => e.Group)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
