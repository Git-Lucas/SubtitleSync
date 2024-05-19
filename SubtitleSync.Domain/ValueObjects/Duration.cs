using SubtitleSync.Domain.Extensions;

namespace SubtitleSync.Domain.ValueObjects;
public record Duration
{
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }

    public Duration(TimeSpan startTime, TimeSpan endTime)
    {
        Validate(startTime, endTime);

        StartTime = startTime;
        EndTime = endTime;
    }

    public string ToFormatStr()
    {
        return $"{StartTime.ToFormatSrt()} --> {EndTime.ToFormatSrt()}";
    }

    internal void ApplyOffset(TimeSpan offset)
    {
        StartTime = StartTime.Add(offset);
        EndTime = EndTime.Add(offset);
    }

    private static void Validate(TimeSpan startTime, TimeSpan endTime)
    {
        if (startTime > endTime)
        {
            throw new ArgumentException($"O tempo de início não pode ser maior do que o tempo final. " +
                $"Tempo de início: {startTime} | Tempo final: {endTime}");
        }
    }
}
