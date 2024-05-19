using SubtitleSync.Domain.UseCases.Parser.DomainServices;

namespace SubtitleSync.Domain.Tests.UseCases.Parser.DomainServices;
public class FileExtensionValidatorTests
{
    [Fact]
    public void Execute_WhenNotSupportedExtension_ThrowsArgumentException()
    {
        string invalidFileExtension = ".txt";

        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            FileExtensionValidator.Execute(invalidFileExtension));
        Assert.Equal("Extensão de arquivo não suportada pela aplicação. Suportados: .srt", exception.Message);
    }
}
