using SubtitleSync.Domain.Extensions;
using System.Globalization;

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

    public static Duration CreateFromSrt(string timecodesSrt, char fractionalSeparator)
    {
        string format = @$"hh\:mm\:ss\{fractionalSeparator}fff";
        TimeSpan startTime;
        TimeSpan endTime;

        try
        {
            string[] timeParts = timecodesSrt.Split(" --> ");
            startTime = TimeSpan.ParseExact(timeParts[0], format, CultureInfo.InvariantCulture);
            endTime = TimeSpan.ParseExact(timeParts[1], format, CultureInfo.InvariantCulture);
        }
        catch (Exception)
        {
            throw new ArgumentException($"Não foi possível ler o seguinte código temporal: {timecodesSrt}");
        }

        return new Duration(startTime, endTime);
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
