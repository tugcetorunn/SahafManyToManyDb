using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SahafManyToManyDb.Models
{
    /// <summary>
    /// Yazar sınıfı, database de oluşacak aspNetUser tablosunun özelliklerini temsil eder. identityUser sınıfından türeyip ek property tanımlanmak üzere oluşturulmuştur.
    /// </summary>
    public class Yazar : IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        [NotMapped] // Bu property database e eklenmeyecek.
        public string AdSoyad => Ad + " " + Soyad; // Yazarın adı ve soyadı birleştirilerek gösterilir. (önyüz için)
        public string Hakkinda { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; } // Yazarın eklediği kitaplar
    }
}