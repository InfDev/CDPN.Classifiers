using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data.Config
{
    public class AtdCategoryConfiguration : IEntityTypeConfiguration<AtdCategory>
    {
        public void Configure(EntityTypeBuilder<AtdCategory> builder)
        {
            builder.ToTable(DbContextConsts.DbTablePrefix + nameof(AtdCategory));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .HasMaxLength(1)
               .IsRequired()
               .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
