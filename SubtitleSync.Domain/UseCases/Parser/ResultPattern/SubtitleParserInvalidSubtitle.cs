namespace SubtitleSync.Domain.UseCases.Parser.ResultPattern;
public record SubtitleParserInvalidSubtitle(string Reason) : SubtitleParserResult(false)
{
}
