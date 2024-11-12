using SubtitleSync.Domain.UseCases.Writer;

namespace SubtitleSync.Application.UseCases;
public class SubtitleWriterSrt
{
    private readonly string _fileName = "SubtitleSync_ProcessedSubtitles.srt";

    public async Task ExecuteAsync(SubtitleWriterRequest subtitleWriterRequest)
    {
        string contentSrt = subtitleWriterRequest.Subtitle.ToSrt();
        string fullPath = Path.Combine(subtitleWriterRequest.PathFile, _fileName);
        
        await File.WriteAllTextAsync(fullPath, contentSrt);
    }
}
