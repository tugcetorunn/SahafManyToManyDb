using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SahafManyToManyDb.Models;
using System.Reflection;

namespace SahafManyToManyDb.Data
{
    /// <summary>
    /// veritabanının kurulması için oluşturulan IdentityDbContext sınıfından miras alan dbcontext
    /// </summary>
    public class SahafDbContext : IdentityDbContext<Yazar>
    {
        public SahafDbContext()
        {
        }

        public SahafDbContext(DbContextOptions<SahafDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// veritabanında kullanılacak tablolar
        /// </summary>
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KitapKategori> KitapKategori { get; set; }

        /// <summary>
        /// veritabanı oluşurken yapılacak işlemler
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
