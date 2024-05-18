namespace SubtitleSync.Domain.ValueObjects;
public record Duration
{
    public TimeSpan StartTime { get; }
    public TimeSpan EndTime { get; }

    public Duration(TimeSpan startTime, TimeSpan endTime)
    {
        Validate(startTime, endTime);

        StartTime = startTime;
        EndTime = endTime;
    }

    private void Validate(TimeSpan startTime, TimeSpan endTime)
    {
        if (startTime > endTime)
        {
            throw new ArgumentException($"O tempo de início não pode ser maior do que o tempo final. Tempo de início: {startTime} | Tempo final: {endTime}");
        }
    }
}
