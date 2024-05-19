using SubtitleSync.Application.UseCases;
using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Writer;
using SubtitleSync.Domain.UseCases.Writer.DTOs;

namespace SubtitleSync.Application.Tests.Integration.UseCases;
public class SubtitleWriterSrtTests
{
    private readonly ISubtitleWriter _subtitleWriter = new SubtitleWriterSrt();

    [Fact]
    public async Task ExecuteAsync_WhenValidSubtitleAndPath_ShouldSaveFile()
    {
        IEnumerable<SubtitleLine> lines =
        [
            new SubtitleLine(number: 1,
                             startTime: TimeSpan.FromSeconds(8),
                             endTime: TimeSpan.FromSeconds(10),
                             text: "- How did he do that?\r\n- Made him an offer he couldn't refuse."),
            new SubtitleLine(number: 2,
                             startTime: TimeSpan.FromSeconds(11),
                             endTime: TimeSpan.FromSeconds(13),
                             text: "- The deal was sealed in a matter of minutes."),
            new SubtitleLine(number: 3,
                             startTime: TimeSpan.FromSeconds(14),
                             endTime: TimeSpan.FromSeconds(16),
                             text: "- Now, everything was set in motion.")
        ];
        Subtitle subtitle = new(lines);
        string pathFile = @"..\..\..\..\..\";
        string expectedFilePath = Path.Combine(pathFile, "SubtitleSync_ProcessedSubtitles.srt");
        SubtitleWriterRequest dto = new(subtitle, pathFile);

        await _subtitleWriter.ExecuteAsync(dto);

        Assert.True(File.Exists(expectedFilePath));
        if (File.Exists(expectedFilePath))
        {
            File.Delete(expectedFilePath);
        }
    }
}
