using SubtitleSync.Domain.Entities;

namespace SubtitleSync.Domain.UseCases.Writer.DTOs;
public record SubtitleWriterRequest(Subtitle Subtitle, string FullPath)
{
}
