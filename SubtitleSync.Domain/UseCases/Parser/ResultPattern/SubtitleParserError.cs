namespace SubtitleSync.Domain.UseCases.Parser.ResultPattern;
public record SubtitleParserError(string SubtitleSequenceNumber, string Reason)
{
}
