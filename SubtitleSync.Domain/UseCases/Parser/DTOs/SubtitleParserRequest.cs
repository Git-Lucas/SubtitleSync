using SubtitleSync.Domain.UseCases.Parser.DomainServices;

namespace SubtitleSync.Domain.UseCases.Parser.DTOs;
public record SubtitleParserRequest(string FilePath, char FractionalSeparator)
{
    public void Validate()
    {
        FileExtensionValidator.Execute(Path.GetExtension(FilePath));
        FractionalSeparatorValidator.Execute(FractionalSeparator);
    }
}
