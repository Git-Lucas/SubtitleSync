using SubtitleSync.Domain.Entities;

namespace SubtitleSync.Domain.UseCases.Parser.DTOs;
public record SubtitleParserSuccess(Subtitle Subtitle) : SubtitleParserResult(true)
{
}
