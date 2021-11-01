using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CDPN.Classifiers.Entities;

namespace CDPN.Classifiers.Infrastructure.Data.Config
{
    public class AtdUnitConfiguration : IEntityTypeConfiguration<AtdUnit>
    {
        public void Configure(EntityTypeBuilder<AtdUnit> builder)
        {
            builder.ToTable(DbContextConsts.DbTablePrefix + nameof(AtdUnit));
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.ParentId);

            builder
                .HasOne(u => u.Parent)
                .WithMany(p => p.Childrens)
                .HasForeignKey(u => u.ParentId);

            builder.Property(e => e.Id)
               .HasMaxLength(20)
               .IsRequired()
               .ValueGeneratedNever();

            builder.Property(e => e.ParentId)
               .HasMaxLength(20);

            builder
                .HasOne(u => u.AtdLevel)
                .WithMany(l => l.AtdUnits)
                .HasForeignKey(u => u.AtdLevelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(u => u.AtdCategory)
                .WithMany(c => c.AtdUnits)
                .HasForeignKey(u => u.AtdCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.AtdLevelId)
               .IsRequired();

            builder.Property(e => e.AtdCategoryId)
               .HasMaxLength(1)
               .IsRequired();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
