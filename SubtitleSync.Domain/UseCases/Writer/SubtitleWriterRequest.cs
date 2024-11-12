using SubtitleSync.Domain.Entities;

namespace SubtitleSync.Domain.UseCases.Writer;
public record SubtitleWriterRequest(Subtitle Subtitle, string PathFile)
{
}
