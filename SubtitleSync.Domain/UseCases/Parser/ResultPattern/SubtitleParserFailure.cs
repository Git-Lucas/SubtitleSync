namespace SubtitleSync.Domain.UseCases.Parser.ResultPattern;
public record SubtitleParserFailure(IEnumerable<SubtitleParserError> Errors) : SubtitleParserResult(false)
{
}
