using SubtitleSync.Domain.UseCases.Parser.DTOs;

namespace SubtitleSync.Domain.UseCases.Parser;
public interface ISubtitleParser
{
    Task<SubtitleParserResult> ExecuteAsync(SubtitleParserRequest dto);
}
