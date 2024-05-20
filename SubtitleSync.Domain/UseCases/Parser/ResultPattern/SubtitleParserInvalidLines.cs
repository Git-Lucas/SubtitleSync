namespace SubtitleSync.Domain.UseCases.Parser.ResultPattern;
public record SubtitleParserInvalidLines(IEnumerable<InvalidLine> Errors) : SubtitleParserResult(false)
{
}
