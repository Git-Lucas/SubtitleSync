using SubtitleSync.Domain.UseCases.Processor;

namespace SubtitleSync.Application.UseCases;
public static class SubtitleProcessor
{
    public static void ApplyOffset(ApplyOffsetRequest dto)
    {
        dto.Subtitle.ApplyOffset(dto.Offset);
    }
}
