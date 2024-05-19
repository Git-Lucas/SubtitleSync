using SubtitleSync.Domain.UseCases.Writer.DTOs;

namespace SubtitleSync.Domain.UseCases.Writer;
public interface ISubtitleWriter
{
    void Write(SubtitleWriterRequest subtitleWriterRequest);
}
