using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data.Config
{
    public class PaperSizeConfiguration : IEntityTypeConfiguration<PaperSize>
    {
        public void Configure(EntityTypeBuilder<PaperSize> builder)
        {
            builder.ToTable(DbContextConsts.DbTablePrefix + nameof(PaperSize));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .IsRequired()
               .ValueGeneratedNever();

            builder.Property(e => e.Format)
               .IsRequired()
               .HasMaxLength(8);

            builder.Property(e => e.Width)
               .IsRequired();

            builder.Property(e => e.Height)
               .IsRequired();

            builder.Property(e => e.Use)
                .HasMaxLength(200);
        }
    }
}
