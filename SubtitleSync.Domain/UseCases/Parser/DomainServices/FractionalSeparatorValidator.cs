namespace SubtitleSync.Domain.UseCases.Parser.DomainServices;
public static class FractionalSeparatorValidator
{
    private static char[] SupportedFractionalSeparators => [','];

    public static void Execute(char fractionalSeparator)
    {
        if (!SupportedFractionalSeparators.Contains(fractionalSeparator))
        {
            throw new ArgumentException(
                $"Separador fracionário não suportado pela aplicação. " +
                $"Suportados: {string.Join(" | ", SupportedFractionalSeparators)}");
        }
    }
}
