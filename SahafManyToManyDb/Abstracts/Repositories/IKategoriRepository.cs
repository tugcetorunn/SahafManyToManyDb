using SahafManyToManyDb.Models;

namespace SahafManyToManyDb.Abstracts.Repositories
{
    /// <summary>
    /// Kategori tablosu için özel metodların imzalarını içerecek olan repository arayüzü. örneğin kategoriye ait kitapları listeleme
    /// </summary>
    public interface IKategoriRepository : IRepository<Kategori>
    {
    }
}
