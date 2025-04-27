namespace SahafManyToManyDb.Models
{
    /// <summary>
    /// Kitap sınıfı, database de oluşacak kitap tablosunun özelliklerini temsil eder.
    /// </summary>
    public class Kitap
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public string YazarId { get; set; }
        public Yazar? Yazar { get; set; }
        public string Yayinevi { get; set; }
        public string ISBN { get; set; }
        public ICollection<KitapKategori>? Kategoriler { get; set; } // Kitabın kategorileri
        public int SayfaSayisi { get; set; }
        public int BasimSayisi { get; set; }
        public string Onsoz { get; set; }
        public decimal Fiyat { get; set; }

    }
}
