using SubtitleSync.Domain.Entities;

namespace SubtitleSync.Domain.UseCases.Processor;
public record ApplyOffsetRequest(Subtitle Subtitle, TimeSpan Offset)
{
}
