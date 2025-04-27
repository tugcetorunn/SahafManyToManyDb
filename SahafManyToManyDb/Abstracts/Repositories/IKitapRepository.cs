using SahafManyToManyDb.Models;

namespace SahafManyToManyDb.Abstracts.Repositories
{
    /// <summary>
    /// Kitap tablosu için özel metodların imzalarını içerecek olan repository arayüzü
    /// </summary>
    public interface IKitapRepository : IRepository<Kitap>
    {
    }
}
