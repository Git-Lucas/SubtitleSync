namespace SubtitleSync.Domain.UseCases.Parser.DomainServices;
public static class FileExtensionValidator
{
    private static readonly string[] SupportedFileExtensions = [".srt"];

    public static void Execute(string fileExtension)
    {
        if (!SupportedFileExtensions.Contains(fileExtension))
        {
            throw new ArgumentException("Extensão de arquivo não suportada pela aplicação. " +
                $"Suportados: {string.Join(" | ", SupportedFileExtensions)}");
        }
    }
}
