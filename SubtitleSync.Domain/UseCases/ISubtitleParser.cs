using SubtitleSync.Domain.Entities;

namespace SubtitleSync.Domain.UseCases;
public interface ISubtitleParser
{
    Subtitle Parse(string filePath);
}
