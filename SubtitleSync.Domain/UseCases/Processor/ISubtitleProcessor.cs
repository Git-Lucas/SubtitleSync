using SubtitleSync.Domain.UseCases.Processor.DTOs;

namespace SubtitleSync.Domain.UseCases.Processor;
public interface ISubtitleProcessor
{
    void ApplyOffset(ApplyOffsetRequest dto);
}
