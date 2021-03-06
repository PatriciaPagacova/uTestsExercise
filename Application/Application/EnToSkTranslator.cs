﻿namespace Application
{
    internal class EnToSkTranslator : ITranslator
    {
        public string Translate(string input)
        {
            return input?
                .Replace("Error", "Chyba")
                .Replace("Thanks", "Podakovanie")
                .Replace("Warning", "Varovanie")
                .Replace("This is email of type", "Toto je email typu");
        }

        public string TargetLanguageName => "Slovak";
    }
}
