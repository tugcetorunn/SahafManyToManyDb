using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SahafManyToManyDb.Models.Configurations
{
    /// <summary>
    /// kitap tablosunun propertylerini ve ilişkilerini yapılandırmak için kullanılır.
    /// </summary>
    public class KitapCFG : IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.HasKey(k => k.KitapId);
            builder.Property(k => k.KitapAdi).IsRequired().HasMaxLength(100);
            builder.Property(k => k.Yayinevi).IsRequired().HasMaxLength(50);
            builder.Property(k => k.ISBN).IsRequired().HasMaxLength(12);
            builder.Property(k => k.Onsoz).HasMaxLength(200);
            builder.Property(k => k.Fiyat).HasColumnType("money");

            builder.HasMany(k => k.Kategoriler)
                .WithOne(k => k.Kitap)
                .HasForeignKey(k => k.KitapId);

        }
    }
}
