﻿namespace SahafManyToManyDb.ResultViewModels
{
    public class RegisterResult
    {
        public ICollection<string> Hatalar { get; set; } = new List<string>();
    }
}
