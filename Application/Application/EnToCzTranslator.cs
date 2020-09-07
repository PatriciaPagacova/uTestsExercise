namespace Application
{
    internal class EnToCzTranslator : ITranslator
    {
        public string Translate(string input)
        {
            return input?
                .Replace("Error", "Chyba")
                .Replace("Thanks", "Podekovani")
                .Replace("Warning", "Varovani")
                .Replace("This is email of type", "Tohle je email typu");
        }

        public string TargetLanguageName => "Czech";
    }
}
