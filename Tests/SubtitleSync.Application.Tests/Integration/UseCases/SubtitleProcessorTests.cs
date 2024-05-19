using SubtitleSync.Application.UseCases;
using SubtitleSync.Domain.Entities;
using SubtitleSync.Domain.UseCases.Processor;
using SubtitleSync.Domain.UseCases.Processor.DTOs;

namespace SubtitleSync.Application.Tests.Integration.UseCases;
public class SubtitleProcessorTests
{
    private readonly ISubtitleProcessor _subtitleProcessor = new SubtitleProcessor();

    [Fact]
    public void ApplyOffset_WhenValidOffset_ReturnsUpdatedSubtitle()
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
                             text: "- The deal was sealed in a matter of minutes.")
        ];
        Subtitle subtitle = new(lines);
        TimeSpan offset = TimeSpan.FromSeconds(1);
        ApplyOffsetRequest dto = new(subtitle, offset);

        _subtitleProcessor.ApplyOffset(dto);

        Assert.Equal(TimeSpan.FromSeconds(9), subtitle.Lines.First(x => x.Number.Value == 1).Duration.StartTime);
        Assert.Equal(TimeSpan.FromSeconds(11), subtitle.Lines.First(x => x.Number.Value == 1).Duration.EndTime);
        Assert.Equal(TimeSpan.FromSeconds(12), subtitle.Lines.First(x => x.Number.Value == 2).Duration.StartTime);
        Assert.Equal(TimeSpan.FromSeconds(14), subtitle.Lines.First(x => x.Number.Value == 2).Duration.EndTime);
    }
}
