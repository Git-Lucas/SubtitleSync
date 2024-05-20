using SubtitleSync.Domain.Entities;

namespace SubtitleSync.Domain.UseCases.Processor.DTOs;
public record ApplyOffsetRequest(Subtitle Subtitle, TimeSpan Offset)
{
}
