using SubtitleSync.Domain.Entities;

namespace SubtitleSync.Domain.UseCases;
public interface ISubtitleParser
{
    Task<Subtitle> ExecuteAsync(string filePath);
}
