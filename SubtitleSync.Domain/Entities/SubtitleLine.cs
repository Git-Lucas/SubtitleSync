using SubtitleSync.Domain.ValueObjects;

namespace SubtitleSync.Domain.Entities;
public class SubtitleLine
{
    public int Number { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; } 
    public string Text { get; private set; } 

    public SubtitleLine(int number, TimeSpan startTime, TimeSpan endTime, string text)
    {
        Duration durationValueObject = new(startTime, endTime);

        Number = number;
        StartTime = durationValueObject.StartTime;
        EndTime = durationValueObject.EndTime;
        Text = text;
    }
}
