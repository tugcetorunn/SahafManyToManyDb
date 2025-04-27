using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SahafManyToManyDb.Models.Configurations
{
    /// <summary>
    /// AspnetUsers tablosunun propertylerini ve ilişkilerini yapılandırmak için kullanılır.
    /// </summary>
    public class YazarCFG : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.Property(k => k.UserName).IsRequired().HasMaxLength(50);
            builder.Property(k => k.PasswordHash).IsRequired().HasMaxLength(100);
            builder.Property(k => k.Email).IsRequired().HasMaxLength(80);
            builder.Property(k => k.Ad).IsRequired().HasMaxLength(30);
            builder.Property(k => k.Soyad).IsRequired().HasMaxLength(30);
            builder.Property(k => k.Hakkinda).IsRequired().HasMaxLength(200);

            builder.HasMany(k => k.Kitaplar)
                .WithOne(n => n.Yazar)
                .HasForeignKey(n => n.YazarId);
        }
    }
}
