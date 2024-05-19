namespace SubtitleSync.Domain.UseCases.Parser.DTOs;
public record SubtitleParserFailure(IEnumerable<SubtitleParserError> Errors) : SubtitleParserResult(false)
{
}
