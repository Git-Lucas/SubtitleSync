using SubtitleSync.Domain.ValueObjects;

namespace SubtitleSync.Domain.Entities;
public class SubtitleLine
{
    public Number Number { get; private set; }
    public Duration Duration { get; private set; } 
    public string Text { get; private set; }

    public SubtitleLine(int number, TimeSpan startTime, TimeSpan endTime, string text)
    {
        Number = new Number(number);
        Duration = new Duration(startTime, endTime);
        Text = text;
    }

    public SubtitleLine(string numberSrt, string timecodesSrt, char fractionalSeparator, IEnumerable<string> texts)
    {
        Number = Number.CreateFromSrt(numberSrt);
        Duration = Duration.CreateFromSrt(timecodesSrt, fractionalSeparator);
        Text = string.Join("\n", texts);
    }
}
