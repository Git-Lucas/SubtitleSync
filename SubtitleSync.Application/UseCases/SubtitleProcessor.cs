using SubtitleSync.Domain.UseCases.Processor;
using SubtitleSync.Domain.UseCases.Processor.DTOs;

namespace SubtitleSync.Application.UseCases;
public class SubtitleProcessor : ISubtitleProcessor
{
    public void ApplyOffset(ApplyOffsetRequest dto)
    {
        dto.Subtitle.ApplyOffset(dto.Offset);
    }
}
