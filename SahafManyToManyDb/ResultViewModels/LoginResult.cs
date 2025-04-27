using SahafManyToManyDb.Models;

namespace SahafManyToManyDb.ResultViewModels
{
    /// <summary>
    /// Login işlemi sonrası dönecek olan result model
    /// </summary>
    public class LoginResult
    {
        public Yazar? Yazar { get; set; }
        public string Mesaj { get; set; }

    }
}
