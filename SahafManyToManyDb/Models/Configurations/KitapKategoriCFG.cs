using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SahafManyToManyDb.Models.Configurations
{
    /// <summary>
    /// KitapKategori sınıfının yapılandırılması için kullanılan sınıf.
    /// </summary>
    public class KitapKategoriCFG : IEntityTypeConfiguration<KitapKategori>
    {
        public void Configure(EntityTypeBuilder<KitapKategori> builder)
        {
            builder.HasKey(kk => new { kk.KitapId, kk.KategoriId }); // many to many ilişki için composite key
        }
    }
}
