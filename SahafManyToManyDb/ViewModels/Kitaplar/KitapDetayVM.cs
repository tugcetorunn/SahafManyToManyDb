using System.ComponentModel.DataAnnotations;

namespace MVCCore12GenericRepository.ViewModels.Kitaplar
{
    public class KitapDetayVM
    {
        [Display(Name = "Kitap Id")]
        public int KitapId { get; set; }

        [Display(Name = "Kitap Adı")]
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
        public List<string> Kategoriler { get; set; }
        public decimal Fiyat { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        public int SayfaSayisi { get; set; }

        [Display(Name = "Önsöz")]
        public string Onsoz { get; set; }

        [Display(Name = "Basım Sayısı")]
        public int BasimSayisi { get; set; }

        [Display(Name = "Yayınevi")]
        public string Yayinevi { get; set; }
        public string ISBN { get; set; }

    }
}
