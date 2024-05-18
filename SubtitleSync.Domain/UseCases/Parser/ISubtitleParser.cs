using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Parser.DTOs;

namespace SubtitleSync.Domain.UseCases.Parser;
public interface ISubtitleParser
{
    Task<Subtitle> ExecuteAsync(SubtitleParserRequest dto);
}
