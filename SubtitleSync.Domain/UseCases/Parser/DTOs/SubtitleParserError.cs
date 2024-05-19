namespace SubtitleSync.Domain.UseCases.Parser.DTOs;
public record SubtitleParserError(int SubtitleSequenceNumber, string Reason)
{
}
