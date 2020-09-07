namespace Application
{
    public interface ITranslator
    {
        string Translate(string input);
        string TargetLanguageName { get; }
    }
}
