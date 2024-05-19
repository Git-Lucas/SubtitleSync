namespace SubtitleSync.Domain.UseCases.Parser.ResultPattern;
public record SubtitleParserError(int SubtitleSequenceNumber, string Reason)
{
}
