namespace SahafManyToManyDb.Models
{
    /// <summary>
    /// KitapKategori sınıfı, kitap ve kategori arasındaki many to many ilişkiyi temsil eder.
    /// </summary>
    public class KitapKategori
    {
        public int KitapId { get; set; }
        public Kitap? Kitap { get; set; }
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
    }
}