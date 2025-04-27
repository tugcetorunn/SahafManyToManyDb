using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SahafManyToManyDb.Models.Configurations
{
    /// <summary>
    /// kategori tablosunun propertylerini ve ilişkilerini yapılandırmak için kullanılır.
    /// </summary>
    public class KategoriCFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasKey(k => k.KategoriId);
            builder.Property(k => k.KategoriAdi).IsRequired().HasMaxLength(50);
            builder.HasMany(k => k.Kitaplar)
                .WithOne(k => k.Kategori)
                .HasForeignKey(k => k.KategoriId);

            // başlangıç verileri ekleniyor
            builder.HasData(new Kategori[]
            {
                new Kategori { KategoriId = 1, KategoriAdi = "Roman" },
                new Kategori { KategoriId = 2, KategoriAdi = "Bilim Kurgu" },
                new Kategori { KategoriId = 3, KategoriAdi = "Kişisel Gelişim" },
                new Kategori { KategoriId = 4, KategoriAdi = "Tarih" },
                new Kategori { KategoriId = 5, KategoriAdi = "Biyografi" }
            });
        }
    }
}
