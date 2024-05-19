using SubtitleSync.Domain.ValueObjects;

namespace SubtitleSync.Domain.Entities;
public class SubtitleLine(int number, TimeSpan startTime, TimeSpan endTime, string text)
{
    public Number Number { get; private set; } = new(number);
    public Duration Duration { get; private set; } = new(startTime, endTime);
    public string Text { get; private set; } = text;
}
