using SubtitleSync.Domain.Entities;

namespace SubtitleSync.Domain.UseCases.Parser.ResultPattern;
public record SubtitleParserSuccess(Subtitle Subtitle) : SubtitleParserResult(true)
{
}
