using SubtitleSync.Domain.ValueObjects;

namespace SubtitleSync.Domain.Entities;
public class SubtitleLine
{
    public Number Number { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    public string Text { get; private set; }

    public SubtitleLine(int number, TimeSpan startTime, TimeSpan endTime, string text)
    {
        Duration durationValueObject = new(startTime, endTime);

        Number = new(number);
        StartTime = durationValueObject.StartTime;
        EndTime = durationValueObject.EndTime;
        Text = text;
    }

    internal void ApplyOffset(TimeSpan offset)
    {
        StartTime = StartTime.Add(offset);
        EndTime = EndTime.Add(offset);
    }
}
