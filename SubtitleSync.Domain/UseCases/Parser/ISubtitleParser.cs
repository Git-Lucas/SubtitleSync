using SubtitleSync.Domain.UseCases.Parser.DTOs;
using SubtitleSync.Domain.UseCases.Parser.ResultPattern;

namespace SubtitleSync.Domain.UseCases.Parser;
public interface ISubtitleParser
{
    Task<SubtitleParserResult> ExecuteAsync(SubtitleParserRequest dto);
}
