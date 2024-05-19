using SubtitleSync.Domain.Entities;

namespace SubtitleSync.Domain.Tests.Entities;
public class SubtitleTests
{
    [Fact]
    public void Subtitle_WhenConstructor_ShouldSuccessfulyInstantiate()
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

        Assert.NotNull(subtitle);
        Assert.Equal(lines.Count(), subtitle.Lines.Count());
    }

    [Fact]
    public void Subtitle_WhenConstructorWithDuplicatedNumber_ThrowsArgumentException()
    {
        int repeatedNumber = 1;
        IEnumerable<SubtitleLine> lines =
        [
            new SubtitleLine(number: repeatedNumber,
                             startTime: TimeSpan.FromSeconds(8),
                             endTime: TimeSpan.FromSeconds(10),
                             text: "- How did he do that?\r\n- Made him an offer he couldn't refuse."),
            new SubtitleLine(number: repeatedNumber,
                             startTime: TimeSpan.FromSeconds(11),
                             endTime: TimeSpan.FromSeconds(13),
                             text: "- The deal was sealed in a matter of minutes.")
        ];

        ArgumentException exception = Assert.Throws<ArgumentException>(() => new Subtitle(lines));
        Assert.Equal($"O número {repeatedNumber} está repetido.", exception.Message);
    }

    [Fact]
    public void ApplyOffset_WhenOffsetLessThanStartTimeOfFirstSubtitleLine_ThrowsArgumentException()
    {
        TimeSpan startTimeFirstSubtitleLine = TimeSpan.FromSeconds(1);
        TimeSpan invalidOffset = TimeSpan.FromSeconds(-2);
        IEnumerable<SubtitleLine> lines =
        [
            new SubtitleLine(number: 4,
                             startTime: startTimeFirstSubtitleLine,
                             endTime: TimeSpan.FromSeconds(3),
                             text: "- How did he do that?\r\n- Made him an offer he couldn't refuse.")
        ];
        Subtitle subtitle = new(lines);

        ArgumentException exception = Assert.Throws<ArgumentException>(() => subtitle.ApplyOffset(invalidOffset));
        Assert.Equal("A aplicação do deslocamento temporal não pode provocar um tempo de início menor que 0. " +
                     $"Tempo inicial das legendas: 00:00:01 | Deslocamento temporal solicitado: -00:00:02",
                     exception.Message);
    }
}
