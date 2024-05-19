using SubtitleSync.Domain.UseCases.Parser.DomainServices;

namespace SubtitleSync.Domain.Tests.UseCases.Parser.DomainServices;
public class FractionalSeparatorValidatorTests
{
    [Fact]
    public void Execute_WhenNotSupportedSeparator_ThrowsArgumentException()
    {
        char invalidFractionalSeparator = '.';

        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            FractionalSeparatorValidator.Execute(invalidFractionalSeparator));
        Assert.Equal("Separador fracionário não suportado pela aplicação. Suportados: ,", exception.Message);
    }
}
